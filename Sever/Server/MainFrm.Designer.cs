namespace ChatDemo
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.LbIp = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.LbPort = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtKing = new System.Windows.Forms.TextBox();
            this.txtQueen = new System.Windows.Forms.TextBox();
            this.txtJack = new System.Windows.Forms.TextBox();
            this.lblKing = new System.Windows.Forms.Label();
            this.lblQueen = new System.Windows.Forms.Label();
            this.lblJack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(412, 16);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(50, 20);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "啟動";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LbIp
            // 
            this.LbIp.AutoSize = true;
            this.LbIp.Location = new System.Drawing.Point(28, 17);
            this.LbIp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbIp.Name = "LbIp";
            this.LbIp.Size = new System.Drawing.Size(18, 12);
            this.LbIp.TabIndex = 1;
            this.LbIp.Text = "IP:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(71, 15);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(98, 22);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.10.68";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(261, 15);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(110, 22);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "6000";
            // 
            // LbPort
            // 
            this.LbPort.AutoSize = true;
            this.LbPort.Location = new System.Drawing.Point(197, 19);
            this.LbPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbPort.Name = "LbPort";
            this.LbPort.Size = new System.Drawing.Size(27, 12);
            this.LbPort.TabIndex = 3;
            this.LbPort.Text = "Port:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(30, 50);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(433, 193);
            this.txtLog.TabIndex = 5;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(412, 264);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(50, 19);
            this.btnSendMsg.TabIndex = 6;
            this.btnSendMsg.Text = "發送";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtKing
            // 
            this.txtKing.Location = new System.Drawing.Point(107, 264);
            this.txtKing.Margin = new System.Windows.Forms.Padding(2);
            this.txtKing.Name = "txtKing";
            this.txtKing.Size = new System.Drawing.Size(282, 22);
            this.txtKing.TabIndex = 7;
            // 
            // txtQueen
            // 
            this.txtQueen.Location = new System.Drawing.Point(107, 294);
            this.txtQueen.Margin = new System.Windows.Forms.Padding(2);
            this.txtQueen.Name = "txtQueen";
            this.txtQueen.Size = new System.Drawing.Size(282, 22);
            this.txtQueen.TabIndex = 8;
            // 
            // txtJack
            // 
            this.txtJack.Location = new System.Drawing.Point(107, 324);
            this.txtJack.Margin = new System.Windows.Forms.Padding(2);
            this.txtJack.Name = "txtJack";
            this.txtJack.Size = new System.Drawing.Size(282, 22);
            this.txtJack.TabIndex = 9;
            // 
            // lblKing
            // 
            this.lblKing.AutoSize = true;
            this.lblKing.Location = new System.Drawing.Point(29, 267);
            this.lblKing.Name = "lblKing";
            this.lblKing.Size = new System.Drawing.Size(66, 12);
            this.lblKing.TabIndex = 10;
            this.lblKing.Text = "KingNumber";
            // 
            // lblQueen
            // 
            this.lblQueen.AutoSize = true;
            this.lblQueen.Location = new System.Drawing.Point(29, 297);
            this.lblQueen.Name = "lblQueen";
            this.lblQueen.Size = new System.Drawing.Size(73, 12);
            this.lblQueen.TabIndex = 11;
            this.lblQueen.Text = "QueenNumber";
            // 
            // lblJack
            // 
            this.lblJack.AutoSize = true;
            this.lblJack.Location = new System.Drawing.Point(29, 327);
            this.lblJack.Name = "lblJack";
            this.lblJack.Size = new System.Drawing.Size(63, 12);
            this.lblJack.TabIndex = 12;
            this.lblJack.Text = "JackNumber";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 357);
            this.Controls.Add(this.lblJack);
            this.Controls.Add(this.lblQueen);
            this.Controls.Add(this.lblKing);
            this.Controls.Add(this.txtJack);
            this.Controls.Add(this.txtQueen);
            this.Controls.Add(this.txtKing);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.LbPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.LbIp);
            this.Controls.Add(this.BtnStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrm";
            this.Text = "Sever";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label LbIp;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label LbPort;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtKing;
        private System.Windows.Forms.TextBox txtQueen;
        private System.Windows.Forms.TextBox txtJack;
        private System.Windows.Forms.Label lblKing;
        private System.Windows.Forms.Label lblQueen;
        private System.Windows.Forms.Label lblJack;
    }
}