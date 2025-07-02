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
        private readonly string _iconText = "Mic�Ď�";

        public MainForm()
        {
            InitializeComponent();
            this.Icon = new Icon("MicCheckIcon.ico");

            // �^�X�N�g���C�A�C�R��
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
                        new ToolStripMenuItem("�I��", null, (s, e) => Application.Exit()),
                        new ToolStripMenuItem("�\��/��\��", null, (s, e) => FormVisible()),
                    }
                }
            };

            // �}�C�N�擾
            enumerator = new MMDeviceEnumerator();
            mic = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);

            // �Ď��p�^�C�}�[
            checkTimer = new System.Timers.Timer(2000); // 2�b����
            checkTimer.Elapsed += CheckMicMute;
            checkTimer.Start();

            // �E�B���h�E��\�����Ȃ�
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
                        // UI�X���b�h�Ƀ��x���X�V�˗�
                        this.Invoke((Action)(() =>
                        {
                            labelNumOfCount.Text = _countered.ToString();
                        }));
                         
                        trayIcon.Text = _iconText + "__�C���񐔁F" + _countered.ToString();
                    }
                    mic?.Dispose();
                }
               
            }
            catch (InvalidCastException ex)
            {
                // �f�o�C�X�������ꍇ��^�s��v���͉������Ȃ��i���O�����L�^�������ꍇ�́���L�����j
                // File.AppendAllText("mic_monitor_log.txt", DateTime.Now + " " + ex.Message + Environment.NewLine);
                Debug.WriteLine("InvalidCastException");
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // ���ُ̈펞�����S�ɖ��� or ���O�����c��
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
