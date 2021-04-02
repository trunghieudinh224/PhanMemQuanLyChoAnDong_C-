using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace QUANLYBANQUANAO
{
    public partial class formDanhMucSanPham : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public formDanhMucSanPham()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienThiDanhMuc();
        }

        //HÀM KHI CLICK NÚT ẨN
        private void buttonAn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //HÀM KHI CLICK NÚT ẨN
        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //HÀM KHI RÊ CHUỘT VÀO NÚT ẨN
        private void buttonAn_MouseHover(object sender, EventArgs e)
        {
            buttonAn.BackColor = Color.RoyalBlue;
        }

        //HÀM KHI RÊ CHUỘT RỜI KHỎI NÚT ẨN
        private void buttonAn_MouseLeave(object sender, EventArgs e)
        {
            buttonAn.BackColor = Color.CornflowerBlue;
        }

        //HÀM KHI RÊ CHUỘT VÀO NÚT X
        private void buttonX_MouseHover(object sender, EventArgs e)
        {
            buttonX.BackColor = Color.Red;
        }

        //HÀM KHI RÊ CHUỘT RỜI KHỎI NÚT X
        private void buttonX_MouseLeave(object sender, EventArgs e)
        {
            buttonX.BackColor = Color.CornflowerBlue;
        }

        int mov;
        int movX;
        int movY;
        //HÀM DI CHUYỂN FORM
        private void panelThanhTieuDe_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        //HÀM DI CHUYỂN FORM
        private void panelThanhTieuDe_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        //HÀM DI CHUYỂN FORM
        private void panelThanhTieuDe_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        //HÀM HIỂN THỊ DANH SÁCH NCC
        void HienThiDanhMuc()
        {
            connection.Open();

            string query = "select DanhMuc from DanhMuc";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDanhMuc.DataSource = dt;
            dataGridViewDanhMuc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            connection.Close();
        }

        //HÀM KIỂM TRA THÔNG TIN NHÀ CUNG CẤP ĐƯỢC NHẬP VÀO TỪ NGƯỜI DÙNG
        void CheckNCC()
        {
            connection.Open();

            string query = "select count(DanhMuc) from DanhMuc where DanhMuc = '" + textBoxDanhMuc.Text + "'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            int check = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            if (check > 0)
            {
                labelLoi.Visible = true;
                textBoxDanhMuc.BackColor = Color.LightGray;
                buttonCapNhat.Enabled = false;
                buttonThem.Enabled = false;
            }
            else
            {
                labelLoi.Visible = false;
                textBoxDanhMuc.BackColor = Color.White;
                buttonCapNhat.Enabled = true;
                buttonThem.Enabled = true;
            }
        }

        //HÀM KIỂM TRA THÔNG TIN NCC KHI NHẬP VÀO textBoxDanhMuc
        private void textBoxDanhMuc_TextChanged(object sender, EventArgs e)
        {
            CheckNCC();
        }

        //HÀM KHI NHẤN NÚT THÊM DANH MỤC
        private void buttonThem_Click(object sender, EventArgs e)
        {
            connection.Open();

            string query = "insert into DanhMuc(DanhMuc) values ('"+textBoxDanhMuc.Text+"') ";
            OleDbCommand cmd = new OleDbCommand(query,connection);
            cmd.ExecuteNonQuery();
            pictureBoxTC.Visible = true;
            timerTC.Start();
            connection.Close();
            textBoxDanhMuc.Text = "";
            HienThiDanhMuc();
        }

        public int TC = 0;
        //HÀM THÔNG BÁO THÀNH CÔNG
        private void timerTC_Tick(object sender, EventArgs e)
        {
            TC++;
            if (TC == 2)
            {
                timerTC.Stop();
                pictureBoxTC.Visible = false;
                timerTC.Enabled = false;
                TC = 0;
            }
        }

        public string DanhMucDuocChon;
        //HÀM LẤY THÔNG TIN KHI CHỌN VÀO 1 DANH MỤC TRONG dataGridViewDanhMuc
        private void dataGridViewDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewDanhMuc.CurrentCell.RowIndex;

            if (row >= 0)
            {
                textBoxDanhMuc.Text = dataGridViewDanhMuc.Rows[row].Cells[0].Value.ToString();
                DanhMucDuocChon = dataGridViewDanhMuc.Rows[row].Cells[0].Value.ToString();
            }
        }

        //HÀM CẬP NHẬT DANH MỤC
        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            connection.Open();

            string query = "update DanhMuc set DanhMuc = '" + textBoxDanhMuc.Text + "' where DanhMuc = '"+ DanhMucDuocChon +"' ";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.ExecuteNonQuery();
            pictureBoxTC.Visible = true;
            timerTC.Start();
            connection.Close();
            textBoxDanhMuc.Text = "";
            HienThiDanhMuc();
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxDanhMuc
        private void textBoxDanhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
