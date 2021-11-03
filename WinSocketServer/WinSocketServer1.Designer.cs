
namespace WinSocketServer
{
    partial class WinSocketServer1
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
            this.btnModify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvalue = new System.Windows.Forms.TextBox();
            this.txtBvalue = new System.Windows.Forms.TextBox();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnShowCon = new System.Windows.Forms.Button();
            this.lblListen = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(349, 12);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(94, 29);
            this.btnModify.TabIndex = 0;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "监听地址";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(87, 13);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(256, 27);
            this.txtIPAddress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "a：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "b：";
            // 
            // txtAvalue
            // 
            this.txtAvalue.Location = new System.Drawing.Point(87, 53);
            this.txtAvalue.Name = "txtAvalue";
            this.txtAvalue.Size = new System.Drawing.Size(206, 27);
            this.txtAvalue.TabIndex = 5;
            // 
            // txtBvalue
            // 
            this.txtBvalue.Location = new System.Drawing.Point(87, 89);
            this.txtBvalue.Name = "txtBvalue";
            this.txtBvalue.Size = new System.Drawing.Size(206, 27);
            this.txtBvalue.TabIndex = 6;
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBroadcast.Location = new System.Drawing.Point(314, 56);
            this.btnBroadcast.Name = "btnBroadcast";
            this.btnBroadcast.Size = new System.Drawing.Size(129, 56);
            this.btnBroadcast.TabIndex = 7;
            this.btnBroadcast.Text = "广播";
            this.btnBroadcast.UseVisualStyleBackColor = true;
            this.btnBroadcast.Click += new System.EventHandler(this.btnBroadcast_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOpenServer);
            this.panel1.Location = new System.Drawing.Point(473, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 113);
            this.panel1.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(24, 70);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭监听";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Location = new System.Drawing.Point(24, 13);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(94, 29);
            this.btnOpenServer.TabIndex = 10;
            this.btnOpenServer.Text = "开启监听";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 142);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(776, 296);
            this.txtInfo.TabIndex = 11;
            // 
            // btnShowCon
            // 
            this.btnShowCon.Location = new System.Drawing.Point(656, 66);
            this.btnShowCon.Name = "btnShowCon";
            this.btnShowCon.Size = new System.Drawing.Size(118, 46);
            this.btnShowCon.TabIndex = 12;
            this.btnShowCon.Text = "显示当前连接";
            this.btnShowCon.UseVisualStyleBackColor = true;
            // 
            // lblListen
            // 
            this.lblListen.AutoSize = true;
            this.lblListen.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblListen.Location = new System.Drawing.Point(628, 21);
            this.lblListen.Name = "lblListen";
            this.lblListen.Size = new System.Drawing.Size(159, 19);
            this.lblListen.TabIndex = 13;
            this.lblListen.Text = "服务器当前状态：开启";
            this.lblListen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WinSocketServer1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblListen);
            this.Controls.Add(this.btnShowCon);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBroadcast);
            this.Controls.Add(this.txtBvalue);
            this.Controls.Add(this.txtAvalue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModify);
            this.Name = "WinSocketServer1";
            this.Text = "Win_Socker服务器";
            this.Load += new System.EventHandler(this.WinSockerServer1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAvalue;
        private System.Windows.Forms.TextBox txtBvalue;
        private System.Windows.Forms.Button btnBroadcast;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnShowCon;
        private System.Windows.Forms.Label lblListen;
    }
}

