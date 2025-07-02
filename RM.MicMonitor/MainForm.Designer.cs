namespace RM.MicMonitor
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            labelNumOfCount = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "修正回数：";
            // 
            // labelNumOfCount
            // 
            labelNumOfCount.AutoSize = true;
            labelNumOfCount.Location = new Point(102, 9);
            labelNumOfCount.Name = "labelNumOfCount";
            labelNumOfCount.Size = new Size(17, 20);
            labelNumOfCount.TabIndex = 1;
            labelNumOfCount.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 37);
            Controls.Add(labelNumOfCount);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "マイク監視";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelNumOfCount;
    }
}
