namespace QUANLYBANQUANAO
{
    partial class formDanhSachKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDanhSachKhachHang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelThanhTieuDe = new System.Windows.Forms.Panel();
            this.labelTieuDeForm = new System.Windows.Forms.Label();
            this.buttonAn = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.pictureBoxIconThanhTieuDe = new System.Windows.Forms.PictureBox();
            this.dataGridViewDSKH = new System.Windows.Forms.DataGridView();
            this.ColumnTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSDTKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDSKH = new System.Windows.Forms.Label();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBoxIconTimKiem = new System.Windows.Forms.PictureBox();
            this.buttonThemMoi = new System.Windows.Forms.Button();
            this.buttonXoaKhachHang = new System.Windows.Forms.Button();
            this.pictureBoxXoaKhachHang = new System.Windows.Forms.PictureBox();
            this.timerXoaKhachHang = new System.Windows.Forms.Timer(this.components);
            this.panelThanhTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXoaKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelThanhTieuDe
            // 
            this.panelThanhTieuDe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelThanhTieuDe.Controls.Add(this.labelTieuDeForm);
            this.panelThanhTieuDe.Controls.Add(this.buttonAn);
            this.panelThanhTieuDe.Controls.Add(this.buttonX);
            this.panelThanhTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThanhTieuDe.Location = new System.Drawing.Point(0, 0);
            this.panelThanhTieuDe.MinimumSize = new System.Drawing.Size(535, 35);
            this.panelThanhTieuDe.Name = "panelThanhTieuDe";
            this.panelThanhTieuDe.Size = new System.Drawing.Size(711, 35);
            this.panelThanhTieuDe.TabIndex = 17;
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
            this.labelTieuDeForm.Size = new System.Drawing.Size(267, 23);
            this.labelTieuDeForm.TabIndex = 92;
            this.labelTieuDeForm.Text = "DANH SÁCH KHÁCH HÀNG";
            // 
            // buttonAn
            // 
            this.buttonAn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonAn.FlatAppearance.BorderSize = 0;
            this.buttonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonAn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAn.Location = new System.Drawing.Point(597, 0);
            this.buttonAn.Name = "buttonAn";
            this.buttonAn.Size = new System.Drawing.Size(55, 33);
            this.buttonAn.TabIndex = 49;
            this.buttonAn.Text = "___";
            this.buttonAn.UseVisualStyleBackColor = false;
            this.buttonAn.Click += new System.EventHandler(this.buttonAn_Click);
            this.buttonAn.MouseLeave += new System.EventHandler(this.buttonAn_MouseLeave);
            this.buttonAn.MouseHover += new System.EventHandler(this.buttonAn_MouseHover);
            // 
            // buttonX
            // 
            this.buttonX.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonX.FlatAppearance.BorderSize = 0;
            this.buttonX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonX.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonX.Location = new System.Drawing.Point(656, 0);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(55, 34);
            this.buttonX.TabIndex = 48;
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
            this.pictureBoxIconThanhTieuDe.TabIndex = 18;
            this.pictureBoxIconThanhTieuDe.TabStop = false;
            // 
            // dataGridViewDSKH
            // 
            this.dataGridViewDSKH.AllowDrop = true;
            this.dataGridViewDSKH.AllowUserToAddRows = false;
            this.dataGridViewDSKH.AllowUserToDeleteRows = false;
            this.dataGridViewDSKH.AllowUserToResizeColumns = false;
            this.dataGridViewDSKH.AllowUserToResizeRows = false;
            this.dataGridViewDSKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDSKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewDSKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTenKH,
            this.ColumnSDTKH,
            this.ColumnDiaChi});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDSKH.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewDSKH.Location = new System.Drawing.Point(3, 80);
            this.dataGridViewDSKH.MultiSelect = false;
            this.dataGridViewDSKH.Name = "dataGridViewDSKH";
            this.dataGridViewDSKH.ReadOnly = true;
            this.dataGridViewDSKH.RowHeadersVisible = false;
            this.dataGridViewDSKH.RowHeadersWidth = 51;
            this.dataGridViewDSKH.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDSKH.RowTemplate.Height = 29;
            this.dataGridViewDSKH.RowTemplate.ReadOnly = true;
            this.dataGridViewDSKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDSKH.Size = new System.Drawing.Size(705, 282);
            this.dataGridViewDSKH.TabIndex = 25;
            this.dataGridViewDSKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSKH_CellClick);
            this.dataGridViewDSKH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSKH_CellDoubleClick);
            // 
            // ColumnTenKH
            // 
            this.ColumnTenKH.DataPropertyName = "HoTenKhachHang";
            this.ColumnTenKH.FillWeight = 109.8931F;
            this.ColumnTenKH.HeaderText = "Tên KH";
            this.ColumnTenKH.MinimumWidth = 6;
            this.ColumnTenKH.Name = "ColumnTenKH";
            this.ColumnTenKH.ReadOnly = true;
            // 
            // ColumnSDTKH
            // 
            this.ColumnSDTKH.DataPropertyName = "SDTKhachHang";
            this.ColumnSDTKH.FillWeight = 80.21391F;
            this.ColumnSDTKH.HeaderText = "SĐT KH";
            this.ColumnSDTKH.MinimumWidth = 6;
            this.ColumnSDTKH.Name = "ColumnSDTKH";
            this.ColumnSDTKH.ReadOnly = true;
            // 
            // ColumnDiaChi
            // 
            this.ColumnDiaChi.DataPropertyName = "DiaChiKhachHang";
            this.ColumnDiaChi.FillWeight = 109.8931F;
            this.ColumnDiaChi.HeaderText = "Địa Chỉ";
            this.ColumnDiaChi.MinimumWidth = 6;
            this.ColumnDiaChi.Name = "ColumnDiaChi";
            this.ColumnDiaChi.ReadOnly = true;
            // 
            // labelDSKH
            // 
            this.labelDSKH.AutoSize = true;
            this.labelDSKH.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDSKH.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDSKH.Location = new System.Drawing.Point(-2, 52);
            this.labelDSKH.Name = "labelDSKH";
            this.labelDSKH.Size = new System.Drawing.Size(305, 25);
            this.labelDSKH.TabIndex = 26;
            this.labelDSKH.Text = "DANH SÁCH KHÁCH HÀNG";
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(438, 43);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(175, 33);
            this.textBoxTimKiem.TabIndex = 36;
            this.textBoxTimKiem.TextChanged += new System.EventHandler(this.textBoxTimKiem_TextChanged);
            // 
            // pictureBoxIconTimKiem
            // 
            this.pictureBoxIconTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIconTimKiem.Image")));
            this.pictureBoxIconTimKiem.Location = new System.Drawing.Point(399, 43);
            this.pictureBoxIconTimKiem.Name = "pictureBoxIconTimKiem";
            this.pictureBoxIconTimKiem.Size = new System.Drawing.Size(37, 34);
            this.pictureBoxIconTimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIconTimKiem.TabIndex = 37;
            this.pictureBoxIconTimKiem.TabStop = false;
            // 
            // buttonThemMoi
            // 
            this.buttonThemMoi.BackColor = System.Drawing.Color.Transparent;
            this.buttonThemMoi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonThemMoi.BackgroundImage")));
            this.buttonThemMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonThemMoi.FlatAppearance.BorderSize = 0;
            this.buttonThemMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.buttonThemMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThemMoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold);
            this.buttonThemMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonThemMoi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonThemMoi.Location = new System.Drawing.Point(623, 42);
            this.buttonThemMoi.Name = "buttonThemMoi";
            this.buttonThemMoi.Size = new System.Drawing.Size(38, 34);
            this.buttonThemMoi.TabIndex = 100;
            this.buttonThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonThemMoi.UseVisualStyleBackColor = false;
            this.buttonThemMoi.Click += new System.EventHandler(this.buttonThemMoi_Click);
            // 
            // buttonXoaKhachHang
            // 
            this.buttonXoaKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.buttonXoaKhachHang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonXoaKhachHang.BackgroundImage")));
            this.buttonXoaKhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonXoaKhachHang.FlatAppearance.BorderSize = 0;
            this.buttonXoaKhachHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.buttonXoaKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXoaKhachHang.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold);
            this.buttonXoaKhachHang.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonXoaKhachHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonXoaKhachHang.Location = new System.Drawing.Point(670, 42);
            this.buttonXoaKhachHang.Name = "buttonXoaKhachHang";
            this.buttonXoaKhachHang.Size = new System.Drawing.Size(38, 34);
            this.buttonXoaKhachHang.TabIndex = 101;
            this.buttonXoaKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonXoaKhachHang.UseVisualStyleBackColor = false;
            this.buttonXoaKhachHang.Click += new System.EventHandler(this.buttonXoaKhachHang_Click);
            // 
            // pictureBoxXoaKhachHang
            // 
            this.pictureBoxXoaKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxXoaKhachHang.Image")));
            this.pictureBoxXoaKhachHang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxXoaKhachHang.Location = new System.Drawing.Point(313, 48);
            this.pictureBoxXoaKhachHang.Name = "pictureBoxXoaKhachHang";
            this.pictureBoxXoaKhachHang.Size = new System.Drawing.Size(55, 30);
            this.pictureBoxXoaKhachHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxXoaKhachHang.TabIndex = 102;
            this.pictureBoxXoaKhachHang.TabStop = false;
            this.pictureBoxXoaKhachHang.Visible = false;
            // 
            // timerXoaKhachHang
            // 
            this.timerXoaKhachHang.Interval = 1500;
            this.timerXoaKhachHang.Tick += new System.EventHandler(this.timerXoaKhachHang_Tick);
            // 
            // formDanhSachKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(711, 364);
            this.Controls.Add(this.labelDSKH);
            this.Controls.Add(this.pictureBoxXoaKhachHang);
            this.Controls.Add(this.buttonXoaKhachHang);
            this.Controls.Add(this.buttonThemMoi);
            this.Controls.Add(this.textBoxTimKiem);
            this.Controls.Add(this.pictureBoxIconTimKiem);
            this.Controls.Add(this.dataGridViewDSKH);
            this.Controls.Add(this.pictureBoxIconThanhTieuDe);
            this.Controls.Add(this.panelThanhTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formDanhSachKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formDanhSachKhachHang";
            this.panelThanhTieuDe.ResumeLayout(false);
            this.panelThanhTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXoaKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelThanhTieuDe;
        private System.Windows.Forms.Label labelTieuDeForm;
        private System.Windows.Forms.Button buttonAn;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.PictureBox pictureBoxIconThanhTieuDe;
        private System.Windows.Forms.DataGridView dataGridViewDSKH;
        private System.Windows.Forms.Label labelDSKH;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.PictureBox pictureBoxIconTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSDTKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaChi;
        private System.Windows.Forms.Button buttonThemMoi;
        private System.Windows.Forms.Button buttonXoaKhachHang;
        private System.Windows.Forms.PictureBox pictureBoxXoaKhachHang;
        private System.Windows.Forms.Timer timerXoaKhachHang;
    }
}