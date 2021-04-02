namespace QUANLYBANQUANAO
{
    partial class formDangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDangNhap));
            this.labelTaiKhoan = new System.Windows.Forms.Label();
            this.textBoxTaiKhoan = new System.Windows.Forms.TextBox();
            this.textBoxMatKhau = new System.Windows.Forms.TextBox();
            this.labelMatKhau = new System.Windows.Forms.Label();
            this.buttonDangNhap = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelTenSap = new System.Windows.Forms.Label();
            this.labelAnDong = new System.Windows.Forms.Label();
            this.labelDiaChi1 = new System.Windows.Forms.Label();
            this.labelDiaChi2 = new System.Windows.Forms.Label();
            this.labelSDT1 = new System.Windows.Forms.Label();
            this.labelSDT2 = new System.Windows.Forms.Label();
            this.timerTenSap = new System.Windows.Forms.Timer(this.components);
            this.panelThanhTieuDe = new System.Windows.Forms.Panel();
            this.labelTieuDeForm = new System.Windows.Forms.Label();
            this.buttonX = new System.Windows.Forms.Button();
            this.pictureBoxIconThanhTieuDe = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelThanhTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTaiKhoan
            // 
            this.labelTaiKhoan.AutoSize = true;
            this.labelTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTaiKhoan.Location = new System.Drawing.Point(46, 414);
            this.labelTaiKhoan.Name = "labelTaiKhoan";
            this.labelTaiKhoan.Size = new System.Drawing.Size(129, 29);
            this.labelTaiKhoan.TabIndex = 1;
            this.labelTaiKhoan.Text = "Tài khoản:";
            // 
            // textBoxTaiKhoan
            // 
            this.textBoxTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxTaiKhoan.Location = new System.Drawing.Point(181, 409);
            this.textBoxTaiKhoan.Name = "textBoxTaiKhoan";
            this.textBoxTaiKhoan.Size = new System.Drawing.Size(262, 34);
            this.textBoxTaiKhoan.TabIndex = 1;
            this.textBoxTaiKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTaiKhoan_KeyPress);
            // 
            // textBoxMatKhau
            // 
            this.textBoxMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxMatKhau.Location = new System.Drawing.Point(181, 456);
            this.textBoxMatKhau.Name = "textBoxMatKhau";
            this.textBoxMatKhau.Size = new System.Drawing.Size(262, 34);
            this.textBoxMatKhau.TabIndex = 2;
            this.textBoxMatKhau.UseSystemPasswordChar = true;
            this.textBoxMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMatKhau_KeyPress);
            // 
            // labelMatKhau
            // 
            this.labelMatKhau.AutoSize = true;
            this.labelMatKhau.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelMatKhau.Location = new System.Drawing.Point(46, 461);
            this.labelMatKhau.Name = "labelMatKhau";
            this.labelMatKhau.Size = new System.Drawing.Size(125, 29);
            this.labelMatKhau.TabIndex = 3;
            this.labelMatKhau.Text = "Mật khẩu:";
            // 
            // buttonDangNhap
            // 
            this.buttonDangNhap.BackColor = System.Drawing.Color.Red;
            this.buttonDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonDangNhap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDangNhap.Location = new System.Drawing.Point(186, 502);
            this.buttonDangNhap.Name = "buttonDangNhap";
            this.buttonDangNhap.Size = new System.Drawing.Size(126, 40);
            this.buttonDangNhap.TabIndex = 3;
            this.buttonDangNhap.Text = "Đăng nhập";
            this.buttonDangNhap.UseVisualStyleBackColor = false;
            this.buttonDangNhap.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.Red;
            this.buttonThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThoat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonThoat.Location = new System.Drawing.Point(322, 502);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(126, 40);
            this.buttonThoat.TabIndex = 4;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = false;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(2, 51);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(504, 348);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelTenSap
            // 
            this.labelTenSap.AutoSize = true;
            this.labelTenSap.Font = new System.Drawing.Font("Modern No. 20", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenSap.ForeColor = System.Drawing.Color.DarkRed;
            this.labelTenSap.Location = new System.Drawing.Point(46, 88);
            this.labelTenSap.Name = "labelTenSap";
            this.labelTenSap.Size = new System.Drawing.Size(384, 34);
            this.labelTenSap.TabIndex = 9;
            this.labelTenSap.Text = "LỢI DUNG (THIỆN VY)";
            // 
            // labelAnDong
            // 
            this.labelAnDong.AutoSize = true;
            this.labelAnDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelAnDong.Location = new System.Drawing.Point(7, 59);
            this.labelAnDong.Name = "labelAnDong";
            this.labelAnDong.Size = new System.Drawing.Size(455, 23);
            this.labelAnDong.TabIndex = 10;
            this.labelAnDong.Text = "TRUNG TÂM THƯƠNG MẠI DỊCH VỤ AN ĐÔNG";
            // 
            // labelDiaChi1
            // 
            this.labelDiaChi1.AutoSize = true;
            this.labelDiaChi1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDiaChi1.Location = new System.Drawing.Point(11, 128);
            this.labelDiaChi1.Name = "labelDiaChi1";
            this.labelDiaChi1.Size = new System.Drawing.Size(167, 23);
            this.labelDiaChi1.TabIndex = 11;
            this.labelDiaChi1.Text = "Sạp: C65-66 Lầu 1";
            // 
            // labelDiaChi2
            // 
            this.labelDiaChi2.AutoSize = true;
            this.labelDiaChi2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDiaChi2.Location = new System.Drawing.Point(57, 153);
            this.labelDiaChi2.Name = "labelDiaChi2";
            this.labelDiaChi2.Size = new System.Drawing.Size(124, 23);
            this.labelDiaChi2.TabIndex = 12;
            this.labelDiaChi2.Text = "C54-55 Lầu 1";
            // 
            // labelSDT1
            // 
            this.labelSDT1.AutoSize = true;
            this.labelSDT1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelSDT1.Location = new System.Drawing.Point(273, 128);
            this.labelSDT1.Name = "labelSDT1";
            this.labelSDT1.Size = new System.Drawing.Size(210, 23);
            this.labelSDT1.TabIndex = 13;
            this.labelSDT1.Text = "ĐT: 0903.972.674 (Mai)";
            // 
            // labelSDT2
            // 
            this.labelSDT2.AutoSize = true;
            this.labelSDT2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelSDT2.Location = new System.Drawing.Point(313, 153);
            this.labelSDT2.Name = "labelSDT2";
            this.labelSDT2.Size = new System.Drawing.Size(172, 23);
            this.labelSDT2.TabIndex = 14;
            this.labelSDT2.Text = "0906.363.120 (Mai)";
            // 
            // timerTenSap
            // 
            this.timerTenSap.Interval = 300;
            this.timerTenSap.Tick += new System.EventHandler(this.timerTenSap_Tick);
            // 
            // panelThanhTieuDe
            // 
            this.panelThanhTieuDe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelThanhTieuDe.Controls.Add(this.labelTieuDeForm);
            this.panelThanhTieuDe.Controls.Add(this.buttonX);
            this.panelThanhTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThanhTieuDe.Location = new System.Drawing.Point(0, 0);
            this.panelThanhTieuDe.MinimumSize = new System.Drawing.Size(535, 35);
            this.panelThanhTieuDe.Name = "panelThanhTieuDe";
            this.panelThanhTieuDe.Size = new System.Drawing.Size(535, 35);
            this.panelThanhTieuDe.TabIndex = 15;
            this.panelThanhTieuDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelThanhTieuDe_MouseDown);
            this.panelThanhTieuDe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelThanhTieuDe_MouseMove);
            this.panelThanhTieuDe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelThanhTieuDe_MouseUp);
            // 
            // labelTieuDeForm
            // 
            this.labelTieuDeForm.AutoSize = true;
            this.labelTieuDeForm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTieuDeForm.Location = new System.Drawing.Point(44, 6);
            this.labelTieuDeForm.Name = "labelTieuDeForm";
            this.labelTieuDeForm.Size = new System.Drawing.Size(128, 23);
            this.labelTieuDeForm.TabIndex = 92;
            this.labelTieuDeForm.Text = "ĐĂNG NHẬP";
            // 
            // buttonX
            // 
            this.buttonX.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonX.FlatAppearance.BorderSize = 0;
            this.buttonX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonX.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonX.Location = new System.Drawing.Point(454, 0);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(55, 34);
            this.buttonX.TabIndex = 5;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = false;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            this.buttonX.MouseLeave += new System.EventHandler(this.buttonX_MouseLeave);
            this.buttonX.MouseHover += new System.EventHandler(this.buttonX_MouseHover);
            // 
            // pictureBoxIconThanhTieuDe
            // 
            this.pictureBoxIconThanhTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxIconThanhTieuDe.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIconThanhTieuDe.Image")));
            this.pictureBoxIconThanhTieuDe.Location = new System.Drawing.Point(9, 3);
            this.pictureBoxIconThanhTieuDe.Name = "pictureBoxIconThanhTieuDe";
            this.pictureBoxIconThanhTieuDe.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxIconThanhTieuDe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIconThanhTieuDe.TabIndex = 16;
            this.pictureBoxIconThanhTieuDe.TabStop = false;
            // 
            // formDangNhap
            // 
            this.AcceptButton = this.buttonDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(508, 550);
            this.Controls.Add(this.pictureBoxIconThanhTieuDe);
            this.Controls.Add(this.panelThanhTieuDe);
            this.Controls.Add(this.labelAnDong);
            this.Controls.Add(this.labelSDT2);
            this.Controls.Add(this.labelSDT1);
            this.Controls.Add(this.labelDiaChi2);
            this.Controls.Add(this.labelDiaChi1);
            this.Controls.Add(this.labelTenSap);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonDangNhap);
            this.Controls.Add(this.textBoxMatKhau);
            this.Controls.Add(this.labelMatKhau);
            this.Controls.Add(this.textBoxTaiKhoan);
            this.Controls.Add(this.labelTaiKhoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formDangNhap_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelThanhTieuDe.ResumeLayout(false);
            this.panelThanhTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTaiKhoan;
        private System.Windows.Forms.TextBox textBoxTaiKhoan;
        private System.Windows.Forms.TextBox textBoxMatKhau;
        private System.Windows.Forms.Label labelMatKhau;
        private System.Windows.Forms.Button buttonDangNhap;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTenSap;
        private System.Windows.Forms.Label labelAnDong;
        private System.Windows.Forms.Label labelDiaChi1;
        private System.Windows.Forms.Label labelDiaChi2;
        private System.Windows.Forms.Label labelSDT1;
        private System.Windows.Forms.Label labelSDT2;
        private System.Windows.Forms.Timer timerTenSap;
        private System.Windows.Forms.Panel panelThanhTieuDe;
        private System.Windows.Forms.PictureBox pictureBoxIconThanhTieuDe;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Label labelTieuDeForm;
    }
}