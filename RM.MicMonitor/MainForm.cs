using System;
using System.Windows.Forms;
using System.Timers;
using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace RM.MicMonitor
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private System.Timers.Timer checkTimer;
        private MMDeviceEnumerator enumerator;
        private MMDevice mic;
        private int _countered =0;
        private readonly string _iconText = "Mic監視";

        public MainForm()
        {
            InitializeComponent();
            this.Icon = new Icon("MicCheckIcon.ico");

            // タスクトレイアイコン
            trayIcon = new NotifyIcon()
            {
                Text = _iconText,
                //Icon = SystemIcons.Application,
                Icon = new Icon("MicCheckIcon.ico"),
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items =
                    {
                        new ToolStripMenuItem("終了", null, (s, e) => Application.Exit()),
                        new ToolStripMenuItem("表示/非表示", null, (s, e) => FormVisible()),
                    }
                }
            };

            // マイク取得
            enumerator = new MMDeviceEnumerator();
            mic = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);

            // 監視用タイマー
            checkTimer = new System.Timers.Timer(2000); // 2秒ごと
            checkTimer.Elapsed += CheckMicMute;
            checkTimer.Start();

            // ウィンドウを表示しない
            //ShowInTaskbar = false;
            //WindowState = FormWindowState.Minimized;
            //Visible = false;
        }

        private void FormVisible()
        {
            if (Visible == true)
            {
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
                Visible = false;
                return;
            }
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            Visible = true;
        }

        private void CheckMicMute(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var enumerator = new MMDeviceEnumerator())
                {
                    var mic = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
                    if (mic != null && mic.AudioEndpointVolume.Mute)
                    {
                        mic.AudioEndpointVolume.Mute = false;
                        _countered++;
                        // UIスレッドにラベル更新依頼
                        this.Invoke((Action)(() =>
                        {
                            labelNumOfCount.Text = _countered.ToString();
                        }));
                         
                        trayIcon.Text = _iconText + "__修正回数：" + _countered.ToString();
                    }
                    mic?.Dispose();
                }
               
            }
            catch (InvalidCastException ex)
            {
                // デバイスが無い場合や型不一致時は何もしない（ログだけ記録したい場合は↓を有効化）
                // File.AppendAllText("mic_monitor_log.txt", DateTime.Now + " " + ex.Message + Environment.NewLine);
                Debug.WriteLine("InvalidCastException");
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // 他の異常時も安全に無視 or ログだけ残す
                // File.AppendAllText("mic_monitor_log.txt", DateTime.Now + " " + ex.Message + Environment.NewLine);
                Debug.WriteLine("Exception");
                Debug.WriteLine(ex.Message);
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            checkTimer?.Stop();
            checkTimer?.Dispose();
            mic?.Dispose();
            enumerator?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
