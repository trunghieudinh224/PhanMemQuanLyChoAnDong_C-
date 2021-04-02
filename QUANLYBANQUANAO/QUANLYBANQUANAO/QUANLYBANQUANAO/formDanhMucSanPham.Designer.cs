namespace QUANLYBANQUANAO
{
    partial class formDanhMucSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDanhMucSanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelThanhTieuDe = new System.Windows.Forms.Panel();
            this.labelTieuDeForm = new System.Windows.Forms.Label();
            this.buttonAn = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.pictureBoxIconThanhTieuDe = new System.Windows.Forms.PictureBox();
            this.dataGridViewDanhMuc = new System.Windows.Forms.DataGridView();
            this.ColumnDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxDanhMuc = new System.Windows.Forms.TextBox();
            this.labelDanhMuc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonCapNhat = new System.Windows.Forms.Button();
            this.labelLoi = new System.Windows.Forms.Label();
            this.pictureBoxTC = new System.Windows.Forms.PictureBox();
            this.timerTC = new System.Windows.Forms.Timer(this.components);
            this.panelDuoi = new System.Windows.Forms.Panel();
            this.panelPhai = new System.Windows.Forms.Panel();
            this.panelTrai = new System.Windows.Forms.Panel();
            this.panelThanhTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTC)).BeginInit();
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
            this.panelThanhTieuDe.Size = new System.Drawing.Size(535, 35);
            this.panelThanhTieuDe.TabIndex = 61;
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
            this.labelTieuDeForm.Size = new System.Drawing.Size(118, 23);
            this.labelTieuDeForm.TabIndex = 92;
            this.labelTieuDeForm.Text = "DANH MỤC";
            // 
            // buttonAn
            // 
            this.buttonAn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonAn.FlatAppearance.BorderSize = 0;
            this.buttonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonAn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAn.Location = new System.Drawing.Point(285, 0);
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
            this.buttonX.Location = new System.Drawing.Point(340, 0);
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
            this.pictureBoxIconThanhTieuDe.TabIndex = 62;
            this.pictureBoxIconThanhTieuDe.TabStop = false;
            // 
            // dataGridViewDanhMuc
            // 
            this.dataGridViewDanhMuc.AllowDrop = true;
            this.dataGridViewDanhMuc.AllowUserToAddRows = false;
            this.dataGridViewDanhMuc.AllowUserToDeleteRows = false;
            this.dataGridViewDanhMuc.AllowUserToResizeColumns = false;
            this.dataGridViewDanhMuc.AllowUserToResizeRows = false;
            this.dataGridViewDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDanhMuc.ColumnHeadersHeight = 29;
            this.dataGridViewDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDanhMuc});
            this.dataGridViewDanhMuc.Location = new System.Drawing.Point(8, 123);
            this.dataGridViewDanhMuc.MultiSelect = false;
            this.dataGridViewDanhMuc.Name = "dataGridViewDanhMuc";
            this.dataGridViewDanhMuc.ReadOnly = true;
            this.dataGridViewDanhMuc.RowHeadersVisible = false;
            this.dataGridViewDanhMuc.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dataGridViewDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDanhMuc.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dataGridViewDanhMuc.RowTemplate.Height = 31;
            this.dataGridViewDanhMuc.RowTemplate.ReadOnly = true;
            this.dataGridViewDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDanhMuc.Size = new System.Drawing.Size(377, 141);
            this.dataGridViewDanhMuc.TabIndex = 66;
            this.dataGridViewDanhMuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDanhMuc_CellClick);
            // 
            // ColumnDanhMuc
            // 
            this.ColumnDanhMuc.DataPropertyName = "DanhMuc";
            this.ColumnDanhMuc.HeaderText = "Danh mục";
            this.ColumnDanhMuc.MinimumWidth = 6;
            this.ColumnDanhMuc.Name = "ColumnDanhMuc";
            this.ColumnDanhMuc.ReadOnly = true;
            this.ColumnDanhMuc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // textBoxDanhMuc
            // 
            this.textBoxDanhMuc.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxDanhMuc.Location = new System.Drawing.Point(136, 41);
            this.textBoxDanhMuc.Name = "textBoxDanhMuc";
            this.textBoxDanhMuc.Size = new System.Drawing.Size(140, 33);
            this.textBoxDanhMuc.TabIndex = 68;
            this.textBoxDanhMuc.TextChanged += new System.EventHandler(this.textBoxDanhMuc_TextChanged);
            this.textBoxDanhMuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDanhMuc_KeyPress);
            // 
            // labelDanhMuc
            // 
            this.labelDanhMuc.AutoSize = true;
            this.labelDanhMuc.BackColor = System.Drawing.Color.AntiqueWhite;
            this.labelDanhMuc.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDanhMuc.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDanhMuc.Location = new System.Drawing.Point(3, 51);
            this.labelDanhMuc.Name = "labelDanhMuc";
            this.labelDanhMuc.Size = new System.Drawing.Size(116, 25);
            this.labelDanhMuc.TabIndex = 67;
            this.labelDanhMuc.Text = "Danh mục:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(3, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 69;
            this.label1.Text = "Danh mục hiện tại";
            // 
            // buttonThem
            // 
            this.buttonThem.BackColor = System.Drawing.Color.Red;
            this.buttonThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonThem.BackgroundImage")));
            this.buttonThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonThem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonThem.Location = new System.Drawing.Point(281, 41);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(50, 34);
            this.buttonThem.TabIndex = 70;
            this.buttonThem.UseVisualStyleBackColor = false;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonCapNhat
            // 
            this.buttonCapNhat.BackColor = System.Drawing.Color.Red;
            this.buttonCapNhat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCapNhat.BackgroundImage")));
            this.buttonCapNhat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCapNhat.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonCapNhat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCapNhat.Location = new System.Drawing.Point(336, 41);
            this.buttonCapNhat.Name = "buttonCapNhat";
            this.buttonCapNhat.Size = new System.Drawing.Size(50, 34);
            this.buttonCapNhat.TabIndex = 71;
            this.buttonCapNhat.UseVisualStyleBackColor = false;
            this.buttonCapNhat.Click += new System.EventHandler(this.buttonCapNhat_Click);
            // 
            // labelLoi
            // 
            this.labelLoi.AutoSize = true;
            this.labelLoi.BackColor = System.Drawing.Color.AntiqueWhite;
            this.labelLoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelLoi.ForeColor = System.Drawing.Color.Red;
            this.labelLoi.Location = new System.Drawing.Point(115, 41);
            this.labelLoi.Name = "labelLoi";
            this.labelLoi.Size = new System.Drawing.Size(23, 25);
            this.labelLoi.TabIndex = 72;
            this.labelLoi.Text = "*";
            this.labelLoi.Visible = false;
            // 
            // pictureBoxTC
            // 
            this.pictureBoxTC.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTC.Image")));
            this.pictureBoxTC.Location = new System.Drawing.Point(346, 95);
            this.pictureBoxTC.Name = "pictureBoxTC";
            this.pictureBoxTC.Size = new System.Drawing.Size(48, 28);
            this.pictureBoxTC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTC.TabIndex = 73;
            this.pictureBoxTC.TabStop = false;
            this.pictureBoxTC.Visible = false;
            // 
            // timerTC
            // 
            this.timerTC.Interval = 1000;
            this.timerTC.Tick += new System.EventHandler(this.timerTC_Tick);
            // 
            // panelDuoi
            // 
            this.panelDuoi.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDuoi.Location = new System.Drawing.Point(6, 267);
            this.panelDuoi.Name = "panelDuoi";
            this.panelDuoi.Size = new System.Drawing.Size(383, 6);
            this.panelDuoi.TabIndex = 102;
            // 
            // panelPhai
            // 
            this.panelPhai.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelPhai.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPhai.Location = new System.Drawing.Point(389, 35);
            this.panelPhai.Name = "panelPhai";
            this.panelPhai.Size = new System.Drawing.Size(6, 238);
            this.panelPhai.TabIndex = 101;
            // 
            // panelTrai
            // 
            this.panelTrai.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelTrai.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTrai.Location = new System.Drawing.Point(0, 35);
            this.panelTrai.Name = "panelTrai";
            this.panelTrai.Size = new System.Drawing.Size(6, 238);
            this.panelTrai.TabIndex = 100;
            // 
            // formDanhMucSanPham
            // 
            this.AcceptButton = this.buttonCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(395, 273);
            this.Controls.Add(this.panelDuoi);
            this.Controls.Add(this.panelPhai);
            this.Controls.Add(this.panelTrai);
            this.Controls.Add(this.labelDanhMuc);
            this.Controls.Add(this.dataGridViewDanhMuc);
            this.Controls.Add(this.textBoxDanhMuc);
            this.Controls.Add(this.labelLoi);
            this.Controls.Add(this.buttonCapNhat);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxIconThanhTieuDe);
            this.Controls.Add(this.panelThanhTieuDe);
            this.Controls.Add(this.pictureBoxTC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formDanhMucSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formDanhMucSanPham";
            this.panelThanhTieuDe.ResumeLayout(false);
            this.panelThanhTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIconThanhTieuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelThanhTieuDe;
        private System.Windows.Forms.Label labelTieuDeForm;
        private System.Windows.Forms.PictureBox pictureBoxIconThanhTieuDe;
        private System.Windows.Forms.DataGridView dataGridViewDanhMuc;
        private System.Windows.Forms.TextBox textBoxDanhMuc;
        private System.Windows.Forms.Label labelDanhMuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDanhMuc;
        private System.Windows.Forms.Button buttonCapNhat;
        private System.Windows.Forms.Button buttonAn;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Label labelLoi;
        private System.Windows.Forms.PictureBox pictureBoxTC;
        private System.Windows.Forms.Timer timerTC;
        private System.Windows.Forms.Panel panelDuoi;
        private System.Windows.Forms.Panel panelPhai;
        private System.Windows.Forms.Panel panelTrai;
    }
}