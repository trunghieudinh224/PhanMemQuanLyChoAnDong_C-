namespace QUANLYBANQUANAO
{
    partial class formDanhMucNCC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDanhMucNCC));
            this.textBoxMaNCC = new System.Windows.Forms.TextBox();
            this.labelMaNCC = new System.Windows.Forms.Label();
            this.textBoxSDTNCC = new System.Windows.Forms.TextBox();
            this.labelDiaChiNCC = new System.Windows.Forms.Label();
            this.labelSDTNCC = new System.Windows.Forms.Label();
            this.labelNCC = new System.Windows.Forms.Label();
            this.textBoxDiaChiNCC = new System.Windows.Forms.TextBox();
            this.textBoxNCC = new System.Windows.Forms.TextBox();
            this.dataGridViewDSNCC = new System.Windows.Forms.DataGridView();
            this.ColumnMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaChiNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSDTNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonThemNCC = new System.Windows.Forms.Button();
            this.buttonXoaNCC = new System.Windows.Forms.Button();
            this.buttonCapNhatNCC = new System.Windows.Forms.Button();
            this.labelDSNCC = new System.Windows.Forms.Label();
            this.pictureBoxTC = new System.Windows.Forms.PictureBox();
            this.buttonX = new System.Windows.Forms.Button();
            this.labelTieuDeForm = new System.Windows.Forms.Label();
            this.buttonAn = new System.Windows.Forms.Button();
            this.pictureBoxIconThanhTieuDe = new System.Windows.Forms.PictureBox();
            this.panelThanhTieuDe = new System.Windows.Forms.Panel();
            this.timerTC = new System.Windows.Forms.Timer(this.components);
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBoxIconTimKiem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).BeginInit();
            this.panelThanhTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMaNCC
            // 
            this.textBoxMaNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxMaNCC.Location = new System.Drawing.Point(116, 42);
            this.textBoxMaNCC.Name = "textBoxMaNCC";
            this.textBoxMaNCC.Size = new System.Drawing.Size(158, 30);
            this.textBoxMaNCC.TabIndex = 98;
            this.textBoxMaNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaNCC_KeyPress);
            // 
            // labelMaNCC
            // 
            this.labelMaNCC.AutoSize = true;
            this.labelMaNCC.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelMaNCC.Location = new System.Drawing.Point(-2, 46);
            this.labelMaNCC.Name = "labelMaNCC";
            this.labelMaNCC.Size = new System.Drawing.Size(112, 26);
            this.labelMaNCC.TabIndex = 97;
            this.labelMaNCC.Text = "Mã NCC:";
            // 
            // textBoxSDTNCC
            // 
            this.textBoxSDTNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxSDTNCC.Location = new System.Drawing.Point(426, 42);
            this.textBoxSDTNCC.Name = "textBoxSDTNCC";
            this.textBoxSDTNCC.Size = new System.Drawing.Size(140, 30);
            this.textBoxSDTNCC.TabIndex = 95;
            this.textBoxSDTNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSDTNCC_KeyPress);
            // 
            // labelDiaChiNCC
            // 
            this.labelDiaChiNCC.AutoSize = true;
            this.labelDiaChiNCC.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDiaChiNCC.Location = new System.Drawing.Point(-2, 126);
            this.labelDiaChiNCC.Name = "labelDiaChiNCC";
            this.labelDiaChiNCC.Size = new System.Drawing.Size(150, 26);
            this.labelDiaChiNCC.TabIndex = 92;
            this.labelDiaChiNCC.Text = "Địa chỉ NCC:";
            // 
            // labelSDTNCC
            // 
            this.labelSDTNCC.AutoSize = true;
            this.labelSDTNCC.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelSDTNCC.Location = new System.Drawing.Point(290, 46);
            this.labelSDTNCC.Name = "labelSDTNCC";
            this.labelSDTNCC.Size = new System.Drawing.Size(122, 26);
            this.labelSDTNCC.TabIndex = 91;
            this.labelSDTNCC.Text = "SĐT NCC:";
            // 
            // labelNCC
            // 
            this.labelNCC.AutoSize = true;
            this.labelNCC.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelNCC.Location = new System.Drawing.Point(-2, 86);
            this.labelNCC.Name = "labelNCC";
            this.labelNCC.Size = new System.Drawing.Size(159, 26);
            this.labelNCC.TabIndex = 90;
            this.labelNCC.Text = "Nhà cung cấp:";
            // 
            // textBoxDiaChiNCC
            // 
            this.textBoxDiaChiNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxDiaChiNCC.Location = new System.Drawing.Point(163, 122);
            this.textBoxDiaChiNCC.Name = "textBoxDiaChiNCC";
            this.textBoxDiaChiNCC.Size = new System.Drawing.Size(404, 30);
            this.textBoxDiaChiNCC.TabIndex = 96;
            // 
            // textBoxNCC
            // 
            this.textBoxNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxNCC.Location = new System.Drawing.Point(163, 82);
            this.textBoxNCC.Name = "textBoxNCC";
            this.textBoxNCC.Size = new System.Drawing.Size(404, 30);
            this.textBoxNCC.TabIndex = 99;
            this.textBoxNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNCC_KeyPress);
            // 
            // dataGridViewDSNCC
            // 
            this.dataGridViewDSNCC.AllowDrop = true;
            this.dataGridViewDSNCC.AllowUserToAddRows = false;
            this.dataGridViewDSNCC.AllowUserToDeleteRows = false;
            this.dataGridViewDSNCC.AllowUserToResizeColumns = false;
            this.dataGridViewDSNCC.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDSNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDSNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSNCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMaNCC,
            this.ColumnTenNCC,
            this.ColumnDiaChiNCC,
            this.ColumnSDTNCC});
            this.dataGridViewDSNCC.Location = new System.Drawing.Point(3, 204);
            this.dataGridViewDSNCC.MultiSelect = false;
            this.dataGridViewDSNCC.Name = "dataGridViewDSNCC";
            this.dataGridViewDSNCC.ReadOnly = true;
            this.dataGridViewDSNCC.RowHeadersVisible = false;
            this.dataGridViewDSNCC.RowHeadersWidth = 51;
            this.dataGridViewDSNCC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDSNCC.RowTemplate.Height = 24;
            this.dataGridViewDSNCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDSNCC.Size = new System.Drawing.Size(782, 216);
            this.dataGridViewDSNCC.TabIndex = 100;
            this.dataGridViewDSNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSNCC_CellClick);
            // 
            // ColumnMaNCC
            // 
            this.ColumnMaNCC.DataPropertyName = "MaNCC";
            this.ColumnMaNCC.HeaderText = "Mã NCC";
            this.ColumnMaNCC.MinimumWidth = 6;
            this.ColumnMaNCC.Name = "ColumnMaNCC";
            this.ColumnMaNCC.ReadOnly = true;
            this.ColumnMaNCC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnMaNCC.Width = 115;
            // 
            // ColumnTenNCC
            // 
            this.ColumnTenNCC.DataPropertyName = "TenNCC";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnTenNCC.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnTenNCC.HeaderText = "Tên NCC";
            this.ColumnTenNCC.MinimumWidth = 6;
            this.ColumnTenNCC.Name = "ColumnTenNCC";
            this.ColumnTenNCC.ReadOnly = true;
            this.ColumnTenNCC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnTenNCC.Width = 280;
            // 
            // ColumnDiaChiNCC
            // 
            this.ColumnDiaChiNCC.DataPropertyName = "DiaChiNCC";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnDiaChiNCC.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnDiaChiNCC.HeaderText = "Địa chỉ NCC";
            this.ColumnDiaChiNCC.MinimumWidth = 6;
            this.ColumnDiaChiNCC.Name = "ColumnDiaChiNCC";
            this.ColumnDiaChiNCC.ReadOnly = true;
            this.ColumnDiaChiNCC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDiaChiNCC.Width = 250;
            // 
            // ColumnSDTNCC
            // 
            this.ColumnSDTNCC.DataPropertyName = "SDTNCC";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSDTNCC.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnSDTNCC.HeaderText = "SDT NCC";
            this.ColumnSDTNCC.MinimumWidth = 6;
            this.ColumnSDTNCC.Name = "ColumnSDTNCC";
            this.ColumnSDTNCC.ReadOnly = true;
            this.ColumnSDTNCC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSDTNCC.Width = 125;
            // 
            // buttonThemNCC
            // 
            this.buttonThemNCC.BackColor = System.Drawing.Color.Red;
            this.buttonThemNCC.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThemNCC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonThemNCC.Location = new System.Drawing.Point(572, 37);
            this.buttonThemNCC.Name = "buttonThemNCC";
            this.buttonThemNCC.Size = new System.Drawing.Size(213, 38);
            this.buttonThemNCC.TabIndex = 101;
            this.buttonThemNCC.Text = "Thêm NCC";
            this.buttonThemNCC.UseVisualStyleBackColor = false;
            this.buttonThemNCC.Click += new System.EventHandler(this.buttonThemNCC_Click);
            // 
            // buttonXoaNCC
            // 
            this.buttonXoaNCC.BackColor = System.Drawing.Color.Red;
            this.buttonXoaNCC.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonXoaNCC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonXoaNCC.Location = new System.Drawing.Point(573, 77);
            this.buttonXoaNCC.Name = "buttonXoaNCC";
            this.buttonXoaNCC.Size = new System.Drawing.Size(212, 38);
            this.buttonXoaNCC.TabIndex = 102;
            this.buttonXoaNCC.Text = "Xóa NCC";
            this.buttonXoaNCC.UseVisualStyleBackColor = false;
            this.buttonXoaNCC.Click += new System.EventHandler(this.buttonXoaNCC_Click);
            // 
            // buttonCapNhatNCC
            // 
            this.buttonCapNhatNCC.BackColor = System.Drawing.Color.Red;
            this.buttonCapNhatNCC.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonCapNhatNCC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCapNhatNCC.Location = new System.Drawing.Point(573, 117);
            this.buttonCapNhatNCC.Name = "buttonCapNhatNCC";
            this.buttonCapNhatNCC.Size = new System.Drawing.Size(212, 38);
            this.buttonCapNhatNCC.TabIndex = 103;
            this.buttonCapNhatNCC.Text = "Cập nhật NCC";
            this.buttonCapNhatNCC.UseVisualStyleBackColor = false;
            this.buttonCapNhatNCC.Click += new System.EventHandler(this.buttonCapNhatNCC_Click);
            // 
            // labelDSNCC
            // 
            this.labelDSNCC.AutoSize = true;
            this.labelDSNCC.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDSNCC.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDSNCC.Location = new System.Drawing.Point(-2, 175);
            this.labelDSNCC.Name = "labelDSNCC";
            this.labelDSNCC.Size = new System.Drawing.Size(343, 26);
            this.labelDSNCC.TabIndex = 104;
            this.labelDSNCC.Text = "DANH SÁCH NHÀ CUNG CẤP";
            // 
            // pictureBoxTC
            // 
            this.pictureBoxTC.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pictureBoxTC.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTC.Image")));
            this.pictureBoxTC.Location = new System.Drawing.Point(349, 159);
            this.pictureBoxTC.Name = "pictureBoxTC";
            this.pictureBoxTC.Size = new System.Drawing.Size(58, 55);
            this.pictureBoxTC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTC.TabIndex = 105;
            this.pictureBoxTC.TabStop = false;
            this.pictureBoxTC.Visible = false;
            // 
            // buttonX
            // 
            this.buttonX.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonX.FlatAppearance.BorderSize = 0;
            this.buttonX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonX.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonX.Location = new System.Drawing.Point(732, 0);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(55, 34);
            this.buttonX.TabIndex = 50;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = false;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            this.buttonX.MouseLeave += new System.EventHandler(this.buttonX_MouseLeave);
            this.buttonX.MouseHover += new System.EventHandler(this.buttonX_MouseHover);
            // 
            // labelTieuDeForm
            // 
            this.labelTieuDeForm.AutoSize = true;
            this.labelTieuDeForm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTieuDeForm.Location = new System.Drawing.Point(44, 6);
            this.labelTieuDeForm.Name = "labelTieuDeForm";
            this.labelTieuDeForm.Size = new System.Drawing.Size(165, 23);
            this.labelTieuDeForm.TabIndex = 92;
            this.labelTieuDeForm.Text = "DANH MỤC NCC";
            // 
            // buttonAn
            // 
            this.buttonAn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonAn.FlatAppearance.BorderSize = 0;
            this.buttonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonAn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAn.Location = new System.Drawing.Point(673, 0);
            this.buttonAn.Name = "buttonAn";
            this.buttonAn.Size = new System.Drawing.Size(55, 33);
            this.buttonAn.TabIndex = 51;
            this.buttonAn.Text = "___";
            this.buttonAn.UseVisualStyleBackColor = false;
            this.buttonAn.Click += new System.EventHandler(this.buttonAn_Click);
            this.buttonAn.MouseLeave += new System.EventHandler(this.buttonAn_MouseLeave);
            this.buttonAn.MouseHover += new System.EventHandler(this.buttonAn_MouseHover);
            // 
            // pictureBoxIconThanhTieuDe
            // 
            this.pictureBoxIconThanhTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxIconThanhTieuDe.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIconThanhTieuDe.Image")));
            this.pictureBoxIconThanhTieuDe.Location = new System.Drawing.Point(9, 3);
            this.pictureBoxIconThanhTieuDe.Name = "pictureBoxIconThanhTieuDe";
            this.pictureBoxIconThanhTieuDe.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxIconThanhTieuDe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIconThanhTieuDe.TabIndex = 93;
            this.pictureBoxIconThanhTieuDe.TabStop = false;
            // 
            // panelThanhTieuDe
            // 
            this.panelThanhTieuDe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelThanhTieuDe.Controls.Add(this.pictureBoxIconThanhTieuDe);
            this.panelThanhTieuDe.Controls.Add(this.buttonAn);
            this.panelThanhTieuDe.Controls.Add(this.labelTieuDeForm);
            this.panelThanhTieuDe.Controls.Add(this.buttonX);
            this.panelThanhTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThanhTieuDe.Location = new System.Drawing.Point(0, 0);
            this.panelThanhTieuDe.MinimumSize = new System.Drawing.Size(535, 35);
            this.panelThanhTieuDe.Name = "panelThanhTieuDe";
            this.panelThanhTieuDe.Size = new System.Drawing.Size(787, 35);
            this.panelThanhTieuDe.TabIndex = 52;
            this.panelThanhTieuDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelThanhTieuDe_MouseDown);
            this.panelThanhTieuDe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelThanhTieuDe_MouseMove);
            this.panelThanhTieuDe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelThanhTieuDe_MouseUp);
            // 
            // timerTC
            // 
            this.timerTC.Interval = 1000;
            this.timerTC.Tick += new System.EventHandler(this.timerTC_Tick);
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(617, 167);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(167, 30);
            this.textBoxTimKiem.TabIndex = 106;
            this.textBoxTimKiem.TextChanged += new System.EventHandler(this.textBoxTimKiem_TextChanged);
            this.textBoxTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTimKiem_KeyPress);
            // 
            // pictureBoxIconTimKiem
            // 
            this.pictureBoxIconTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIconTimKiem.Image")));
            this.pictureBoxIconTimKiem.Location = new System.Drawing.Point(582, 167);
            this.pictureBoxIconTimKiem.Name = "pictureBoxIconTimKiem";
            this.pictureBoxIconTimKiem.Size = new System.Drawing.Size(37, 33);
            this.pictureBoxIconTimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIconTimKiem.TabIndex = 107;
            this.pictureBoxIconTimKiem.TabStop = false;
            // 
            // formDanhMucNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(787, 423);
            this.Controls.Add(this.textBoxTimKiem);
            this.Controls.Add(this.pictureBoxIconTimKiem);
            this.Controls.Add(this.labelDSNCC);
            this.Controls.Add(this.buttonCapNhatNCC);
            this.Controls.Add(this.dataGridViewDSNCC);
            this.Controls.Add(this.pictureBoxTC);
            this.Controls.Add(this.buttonXoaNCC);
            this.Controls.Add(this.buttonThemNCC);
            this.Controls.Add(this.textBoxNCC);
            this.Controls.Add(this.textBoxMaNCC);
            this.Controls.Add(this.labelMaNCC);
            this.Controls.Add(this.textBoxDiaChiNCC);
            this.Controls.Add(this.textBoxSDTNCC);
            this.Controls.Add(this.labelDiaChiNCC);
            this.Controls.Add(this.labelSDTNCC);
            this.Controls.Add(this.labelNCC);
            this.Controls.Add(this.panelThanhTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formDanhMucNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formDanhMucNCC";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).EndInit();
            this.panelThanhTieuDe.ResumeLayout(false);
            this.panelThanhTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMaNCC;
        private System.Windows.Forms.Label labelMaNCC;
        private System.Windows.Forms.TextBox textBoxSDTNCC;
        private System.Windows.Forms.Label labelDiaChiNCC;
        private System.Windows.Forms.Label labelSDTNCC;
        private System.Windows.Forms.Label labelNCC;
        private System.Windows.Forms.TextBox textBoxDiaChiNCC;
        private System.Windows.Forms.TextBox textBoxNCC;
        private System.Windows.Forms.DataGridView dataGridViewDSNCC;
        private System.Windows.Forms.Button buttonThemNCC;
        private System.Windows.Forms.Button buttonXoaNCC;
        private System.Windows.Forms.Button buttonCapNhatNCC;
        private System.Windows.Forms.Label labelDSNCC;
        private System.Windows.Forms.PictureBox pictureBoxTC;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Label labelTieuDeForm;
        private System.Windows.Forms.Button buttonAn;
        private System.Windows.Forms.PictureBox pictureBoxIconThanhTieuDe;
        private System.Windows.Forms.Panel panelThanhTieuDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaChiNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSDTNCC;
        private System.Windows.Forms.Timer timerTC;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.PictureBox pictureBoxIconTimKiem;
    }
}