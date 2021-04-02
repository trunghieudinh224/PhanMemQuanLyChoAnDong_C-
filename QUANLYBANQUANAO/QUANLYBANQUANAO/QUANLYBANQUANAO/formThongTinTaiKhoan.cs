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
    public partial class formThongTinTaiKhoan : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public formThongTinTaiKhoan()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            MauTabTTTK();

            ThongTin_TabTTTK();
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

        //HÀM HIỂN THỊ MÀU NÚT MẶC ĐỊNH
        void MauNut()
        {
            buttonTTTK.BackColor = Color.SandyBrown;
            buttonMK.BackColor = Color.SandyBrown;
        }
        





        //----------MỤC THÔNG TIN TÀI KHOẢN----------
        //HÀM TÙY CHỈNH HIỂN THỊ TAB THÔNG TIN TÀI KHOẢN
        void MauTabTTTK()
        {
            buttonTTTK.BackColor = Color.SaddleBrown;
            buttonMK.BackColor = Color.SandyBrown;
            buttonMK.ForeColor = Color.DarkGray;
            buttonTTTK.ForeColor = Color.White;
            panelTTTK.Visible = true;
            panelMK.Visible = false;
        }

        //HÀM KHI CLICK VÀO TAB THÔNG TIN TÀI KHOẢN
        private void buttonTTTK_Click(object sender, EventArgs e)
        {
            MauNut();
            MauTabTTTK();
            ThongTin_TabTTTK();
        }

        //HÀM HIỂN THỊ THÔNG TIN TÀI KHOẢN
        void ThongTin_TabTTTK()
        {
            connection.Open();
            string query = "select Username, TenHienThi, SDT from TaiKhoan where Username = '"+formDangNhap.username+"'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            textBoxTaiKhoan.Text = dt.Rows[0].ItemArray[0].ToString();
            textBoxTenHienThi.Text = dt.Rows[0].ItemArray[1].ToString();
            textBoxSDT.Text = dt.Rows[0].ItemArray[2].ToString();
        }

        //HÀM XỬ LÝ DỮ LIỆU KHI THAY ĐỔI DỮ LIỆU TRONG textBoxTenHienThi
        private void textBoxTenHienThi_TextChanged(object sender, EventArgs e)
        {
            labelLoiTTTK.Visible = false;
            //nếu textBoxTenHienThi có dữ liệu
            if (textBoxTenHienThi.Text != "")
            {
                //lấy tên hiển thị theo textBoxTaiKhoan
                connection.Open();
                string query = "select TenHienThi from TaiKhoan where Username = '" + textBoxTaiKhoan.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                string TenHienThi = cmd.ExecuteScalar().ToString();
                connection.Close();

                //nếu tên hiển thị người dùng nhập trùng với tên hiển thị đẫ có trong hệ thống
                if (textBoxTenHienThi.Text == TenHienThi)
                {
                    textBoxTenHienThi.BackColor = Color.White;
                    buttonCapNhatTTTK.Enabled = true;
                }
                //nếu tên hiển thị người dùng nhập chưa tồn tại trong hệ thống
                else if (textBoxTenHienThi.Text != TenHienThi)
                {
                    connection.Open();
                    string queryTonTai = "select count(TenHienThi) from TaiKhoan where TenHienThi = '" + textBoxTenHienThi.Text + "'";
                    OleDbCommand cmdTonTai = new OleDbCommand(queryTonTai, connection);
                    int TonTai = Convert.ToInt32(cmdTonTai.ExecuteScalar().ToString());
                    connection.Close();

                    if (TonTai > 0)
                    {
                        textBoxTenHienThi.BackColor = Color.LightGray;
                        buttonCapNhatTTTK.Enabled = false;
                    }
                    else if (TonTai == 0)
                    {
                        textBoxTenHienThi.BackColor = Color.White;
                        buttonCapNhatTTTK.Enabled = true;
                    }
                }
            }
            else
            {
                textBoxTenHienThi.BackColor = Color.LightGray;
                buttonCapNhatTTTK.Enabled = false;
            }
        }

        //HÀM KIỂM TRA DỮ LIỆU CỦA SDT NGƯỜI DÙNG
        private void textBoxSDT_TextChanged(object sender, EventArgs e)
        {
            labelLoiTTTK.Visible = false;
            if (textBoxSDT.Text != "")
            {
                textBoxSDT.BackColor = Color.White;
                buttonCapNhatTTTK.Enabled = true;
            }
            else
            {
                textBoxSDT.BackColor = Color.LightGray;
                buttonCapNhatTTTK.Enabled = false;
            }
        }

        //HÀM KHI CLICK VÀO NÚT CẬP NHẬT THÔNG TIN TÀI KHOẢN
        private void buttonCapNhatTTTK_Click(object sender, EventArgs e)
        {
            //nếu người dùng chưa nhập mật khẩu
            if (textBoxMatKhau.Text == "")
            {
                labelLoiTTTK.Text = "Bạn phải nhập mật khẩu !!!";
                labelLoiTTTK.Visible = true;
            }
            //nếu người dùng đã nhập mật khẩu
            else
            {
                //kiểm tra mật khẩu người dùng nhập
                connection.Open();
                string query = "select count(Username) from TaiKhoan where Username = '" + textBoxTaiKhoan.Text + "' and MatKhau = '" + textBoxMatKhau.Text + "' ";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                int CheckMK = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                connection.Close();

                //nếu mật khẩu đúng
                if (CheckMK == 1)
                {
                    connection.Open();
                    string queryCapNhatTenHienThi = "update TaiKhoan set TenHienThi = '" + textBoxTenHienThi.Text + "', SDT = '" + textBoxSDT.Text + "' where Username = '" + textBoxTaiKhoan.Text + "'";
                    OleDbCommand cmdCapNhatTenHienThi = new OleDbCommand(queryCapNhatTenHienThi, connection);
                    cmdCapNhatTenHienThi.ExecuteNonQuery();
                    connection.Close();

                    ThongTin_TabTTTK();
                    labelLoiTTTK.Text = "Đã cập nhật thành công.";
                    labelLoiTTTK.Visible = true;
                }
                //nếu sai mật khẩu
                else if (CheckMK != 1)
                {
                    labelLoiTTTK.Text = "Mật khẩu chưa đúng, nhập lại !!!";
                    labelLoiTTTK.Visible = true;
                }
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxSDT
        private void textBoxSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
 
        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTenHienThi
        private void textBoxTenHienThi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMatKhau
        private void textBoxMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }





        //----------MỤC MẬT KHẨU----------
        //HÀM TÙY CHỈNH HIỂN THỊ TAB MẬT KHẨU
        void MauTabMK()
        {
            buttonMK.BackColor = Color.SaddleBrown;
            buttonTTTK.BackColor = Color.SandyBrown;
            buttonMK.ForeColor = Color.White;
            buttonTTTK.ForeColor = Color.DarkGray;
            panelMK.Visible = true;
            panelTTTK.Visible = false;
        }

        //HÀM KHI CLICK VÀO TAB MẬT KHẨU
        private void buttonMK_Click(object sender, EventArgs e)
        {
            MauNut();
            MauTabMK();
        }

        //HÀM KHI NGƯỜI DÙNG NHẬP MẬT KHẨU MỚI
        private void textBoxMKMoi_TextChanged(object sender, EventArgs e)
        {
            labelLoiMK.Visible = false;
            if (textBoxMKMoi.Text != "" && textBoxMKHienTai.Text != "" && textBoxNhapLai.Text != "")
            {
                buttonCapNhatMK.Enabled = true;
            }
            else
            {
                buttonCapNhatMK.Enabled = false; 
            }
        }

        //HÀM KHI NGƯỜI DÙNG NHẬP MẬT KHẨU HIỆN TẠI
        private void textBoxMKHienTai_TextChanged(object sender, EventArgs e)
        {
            labelLoiMK.Visible = false;
            if (textBoxMKMoi.Text != "" && textBoxMKHienTai.Text != "" && textBoxNhapLai.Text != "")
            {
                buttonCapNhatMK.Enabled = true;
            }
            else
            {
                buttonCapNhatMK.Enabled = false;
            }
        }

        //HÀM XÁC NHẬN MẬT KHẨU MỚI
        private void textBoxNhapLai_TextChanged(object sender, EventArgs e)
        {
            labelLoiMK.Visible = false;
            if (textBoxMKMoi.Text != "" && textBoxMKHienTai.Text != "" && textBoxNhapLai.Text != "")
            {
                if (textBoxNhapLai.Text ==  textBoxMKMoi.Text)
                {
                    buttonCapNhatMK.Enabled = true;
                    textBoxNhapLai.BackColor = Color.White;
                }
                else if(textBoxNhapLai.Text != textBoxMKMoi.Text)
                {
                    buttonCapNhatMK.Enabled = false;
                    textBoxNhapLai.BackColor = Color.LightGray;
                }
            }
            else
            {
                buttonCapNhatMK.Enabled = false;
            }
        }

        //HÀM KHI CLICK VÀO NÚT CẬP NHẬT MẬT KHẨU
        private void buttonCapNhatMK_Click(object sender, EventArgs e)
        {
            //kiểm tra hệ thống có tồn tại tài khoản với mật khẩu hiện tại mà người dùng nhập không
            connection.Open();
            string query = "select count(Username) from TaiKhoan where Username = '"+ formDangNhap.username +"' and MatKhau = '"+ textBoxMKHienTai.Text +"'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            int CheckMK = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            connection.Close();

            //nếu tồn tại 
            if (CheckMK > 0)
            {
                connection.Open();
                string queryCapNhatMK = "update TaiKhoan set MatKhau = '"+ textBoxMKMoi.Text +"' where Username = '"+ formDangNhap.username +"'";
                OleDbCommand cmdCapNhatMK = new OleDbCommand(queryCapNhatMK, connection);
                cmdCapNhatMK.ExecuteNonQuery();
                connection.Close();

                labelLoiMK.Text = "Cập nhật thành công.";
                labelLoiMK.Visible = true;
            }
            //nếu không tồn tại
            else
            {
                labelLoiMK.Text = "Mật khẩu hiện tại chưa đúng !";
                labelLoiMK.Visible = true;
            }           
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMKHienTai
        private void textBoxMKHienTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMKMoi
        private void textBoxMKMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxNhapLai
        private void textBoxNhapLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
