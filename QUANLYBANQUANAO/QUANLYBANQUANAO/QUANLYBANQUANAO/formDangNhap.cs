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
    public partial class formDangNhap : Form
    {
        //chuỗi kết nối của phần mềm
        public static string connectionSTR = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\database.mdb"; 
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();
        public static string username;
        public formDangNhap()
        {
            InitializeComponent();

            LoadFormGioiThieu();

            connection.ConnectionString = connectionSTR;

            TenSap();
        }

        //HÀM HIỂN THỊ FORM GIỚI THIỆU
        void LoadFormGioiThieu()
        {
            formGioiThieu f = new formGioiThieu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        //HÀM KHI CLICK VÀO NÚT X
        private void buttonX_Click(object sender, EventArgs e)
        {
            Application.Exit();
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


        //HÀM TIMER TÊN SẠP
        void TenSap()
        {
            timerTenSap.Start();
        }

        //HÀM THỰC HIỆN HIỆU ỨNG NHẤP NHÁY CHO TÊN SẠP
        private void timerTenSap_Tick(object sender, EventArgs e)
        {
            if (labelTenSap.ForeColor == Color.DarkRed)
            {
                labelTenSap.ForeColor = Color.Teal;
            }
            else
            {
                labelTenSap.ForeColor = Color.DarkRed;
            }
        }

        //HÀM KHI THỰC HIỆN ĐĂNG NHẬP
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "select count (Username) from TaiKhoan where Username = '"+textBoxTaiKhoan.Text+"' and MatKhau = '"+textBoxMatKhau.Text+"'";           
            OleDbCommand cmd = new OleDbCommand(query,connection);
            int kq = Convert.ToInt32(cmd.ExecuteScalar());
            if (kq>0)
            {
                username = textBoxTaiKhoan.Text;
                formBanHang f = new formBanHang();
                textBoxTaiKhoan.Text = "";
                textBoxMatKhau.Text = "";
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo");
            }

            connection.Close();

        }

        //HÀM KHI CLICK VÀO NÚT THOÁT
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //HÀM ĐÓNG FORM
        private void formDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMatKhau
        private void textBoxMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTaiKhoan
        private void textBoxTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
