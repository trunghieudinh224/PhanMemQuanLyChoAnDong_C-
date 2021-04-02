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
    public partial class formDanhMucNCC : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public formDanhMucNCC()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienNCC();
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


        public string NCCDuocChon;
        //HÀM KHI CHỌN VÀO MỘT NHÀ CUNG CẤP TRONG dataGridViewDSNCC
        private void dataGridViewDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewDSNCC.CurrentCell.RowIndex;

            if (row >= 0)
            {
                NCCDuocChon = textBoxMaNCC.Text = dataGridViewDSNCC.Rows[row].Cells[0].Value.ToString();
                textBoxNCC.Text = dataGridViewDSNCC.Rows[row].Cells[1].Value.ToString();
                textBoxDiaChiNCC.Text = dataGridViewDSNCC.Rows[row].Cells[2].Value.ToString();
                textBoxSDTNCC.Text = dataGridViewDSNCC.Rows[row].Cells[3].Value.ToString();
            }
        }

        //HÀM REFRESH CÁC TEXTBOX
        void RF()
        {
            textBoxMaNCC.Text = "";
            textBoxNCC.Text = "";
            textBoxDiaChiNCC.Text = "";
            textBoxSDTNCC.Text = "";
        }
        
        public int TC = 0;
        //HÀM HIỂN THỊ THÔNG BÁO THÀNH CÔNG
        private void timerTC_Tick(object sender, EventArgs e)
        {
            TC++;
            if (TC == 1)
            {
                timerTC.Stop();
                pictureBoxTC.Visible = false;
                timerTC.Enabled = false;
                TC = 0;
            }
        }

        //HÀM HIỂN THỊ DANH SÁCH NHÀ CUNG CẤP
        void HienNCC()
        {
            connection.Open();
            string query = "select MaNCC, TenNCC, DiaChiNCC, SDTNCC from NCC where TrangThai = 'On'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSNCC.DataSource = dt;
            connection.Close();
        }

        //HÀM TÌM KIẾM NHÀ CUNG CẤP
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            string query = "select MaNCC, TenNCC, DiaChiNCC, SDTNCC from NCC where MaNCC like ('%" + textBoxTimKiem.Text + "%') or TenNCC like ('%" + textBoxTimKiem.Text + "%') or DiaChiNCC like ('%" + textBoxTimKiem.Text + "%') or SDTNCC like ('%" + textBoxTimKiem.Text + "%')";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSNCC.DataSource = dt;
            connection.Close();
        }

        //HÀM THÊM NHÀ CUNG CẤP
        private void buttonThemNCC_Click(object sender, EventArgs e)
        {
            //nếu người dùng nhập chưa đủ thông tin
            if (textBoxMaNCC.Text == "" || textBoxSDTNCC.Text == "" || textBoxNCC.Text == "" || textBoxDiaChiNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin NCC !!!","Thông báo");
            }
            //nếu người dùng nhập đầy đủ thông tin
            else
            {
                //kiểm tra nhà cung cấp vừa nhập với các nhà cung cấp đang ẩn trong cơ sở dữ liệu
                connection.Open();
                string queryCheckNCC = "select count(MaNCC) from NCC where MaNCC = '"+textBoxMaNCC.Text+"' and TrangThai = 'Off'";
                OleDbCommand cmdCheckNCC = new OleDbCommand(queryCheckNCC,connection);
                int CheckNNC = Convert.ToInt32(cmdCheckNCC.ExecuteScalar());
                connection.Close();

                //nếu nhà cung cấp vừa nhập đã tồn tại 
                if (CheckNNC == 1)      
                {
                    //cập nhật trạng thái nhà cung cấp đó thành 'On'
                    connection.Open();
                    string queryCapNhatTrangThai = "update NCC set TrangThai = 'On', TenNCC = '"+textBoxNCC.Text+"', DiaChiNCC = '"+textBoxDiaChiNCC.Text+"', SDTNCC = '"+textBoxSDTNCC.Text+"' where MaNCC = '" + textBoxMaNCC.Text + "'";
                    OleDbCommand cmdCapNhatTrangThai = new OleDbCommand(queryCapNhatTrangThai,connection);
                    cmdCapNhatTrangThai.ExecuteNonQuery();
                    connection.Close();                    
                }
                //nếu nhà cung cấp vừa nhập chưa có trong cơ sở dữ liệu
                else       
                {
                    //kiểm tra nhà cung cấp vừa nhập có trùng với các nhà cung cấp hiện tại hay không
                    connection.Open();
                    string queryCheckNCCMoi = "select count(MaNCC) from NCC where MaNCC = '"+textBoxMaNCC.Text+"' and TrangThai = 'On'";
                    OleDbCommand cmdCheckNCCMoi = new OleDbCommand(queryCheckNCCMoi, connection);
                    int CheckNNCMoi = Convert.ToInt32(cmdCheckNCCMoi.ExecuteScalar());
                    connection.Close();

                    //nếu nhà cung cấp vừa nhập không trùng
                    if (CheckNNCMoi == 0)
                    {
                        connection.Open();
                        string queryThemNCC = "insert into NCC (MaNCC, TenNCC, DiaChiNCC, SDTNCC, TrangThai) values ('"+textBoxMaNCC.Text+"', '"+textBoxNCC.Text+"', '"+textBoxDiaChiNCC.Text+"', '"+textBoxSDTNCC.Text+"', 'On')";
                        OleDbCommand cmdThemNCC = new OleDbCommand(queryThemNCC, connection);
                        cmdThemNCC.ExecuteNonQuery();
                        connection.Close();

                        pictureBoxTC.Visible = true;
                        timerTC.Start();
                        RF();
                        HienNCC();
                    }
                    //nếu nhà cung cấp vừa nhập trùng
                    else
                    {
                        MessageBox.Show("Nhà cung cấp đã tồn tại, vui lòng kiểm tra lại thông tin !!!", "Thông báo");
                    }
                }
            }
        }

        //HÀM CẬP NHẬT NHÀ CUNG CẤP
        private void buttonCapNhatNCC_Click(object sender, EventArgs e)
        {
            //kiểm tra nhà cung cấp hiện tại có trùng với mã nhà cung cấp cũ nào trong hệ thống không
            connection.Open();
            string queryCheckNCCcu = "select count(MaNCC) from NCC where MaNCC = '" + textBoxMaNCC.Text + "' and TrangThai = 'Off'";
            OleDbCommand cmdCheckNCCcu = new OleDbCommand(queryCheckNCCcu, connection);
            int CheckNCCcu = Convert.ToInt32(cmdCheckNCCcu.ExecuteScalar());
            connection.Close();

            //nếu không trùng với mã nhà cung cấp cũ nào
            if (CheckNCCcu == 0)        
            {
                //cập nhật thông tin mới cho nhà cung cấp
                connection.Open();
                string queryCapNhatNCC = "update NCC set MaNCC = '" + textBoxMaNCC.Text + "', TenNCC = '" + textBoxNCC.Text + "', DiaChiNCC = '" + textBoxDiaChiNCC.Text + "', SDTNCC = '" + textBoxSDTNCC.Text + "' where MaNCC = '" + NCCDuocChon + "'";
                OleDbCommand cmdCapNhatNCC = new OleDbCommand(queryCapNhatNCC, connection);
                cmdCapNhatNCC.ExecuteNonQuery();
                connection.Close();

                pictureBoxTC.Visible = true;
                timerTC.Start();
                RF();
                HienNCC();
            }
            //nếu nhà cung cấp hiện tại trùng với nhà cung cấp cũ trrong hệ thống
            else        
            {
                //ẩn nhà cung cấp hiện tại khỏi danh sách NCC
                connection.Open();

                string queryAnNCC = "update NCC set TrangThai = 'Off' where MaNCC = '" + NCCDuocChon + "'";
                OleDbCommand cmdAnNCC = new OleDbCommand(queryAnNCC, connection);
                cmdAnNCC.ExecuteNonQuery();

                //cập nhật trạng thái NCC cũ thành 'On' để có thể sử dụng
                string queryCapNhatNCC = "update NCC set TrangThai = 'On', MaNCC = '" + textBoxMaNCC.Text + "', TenNCC = '" + textBoxNCC.Text + "', DiaChiNCC = '" + textBoxDiaChiNCC.Text + "', SDTNCC = '" + textBoxSDTNCC.Text + "' where MaNCC = '" + textBoxMaNCC.Text + "'";
                OleDbCommand cmdCapNhatNCC = new OleDbCommand(queryCapNhatNCC, connection);
                cmdCapNhatNCC.ExecuteNonQuery();

                connection.Close();

                pictureBoxTC.Visible = true;
                timerTC.Start();
                RF();
                HienNCC();
            }            
        }

        //HÀM XÓA NHÀ CUNG CẤP
        private void buttonXoaNCC_Click(object sender, EventArgs e)
        {
            //ẩn nhà cung cấp cần xóa khỏi danh sách
            connection.Open();
            string query = "update NCC set TrangThai = 'Off' where MaNCC = '"+ NCCDuocChon + "'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            pictureBoxTC.Visible = true;
            timerTC.Start();
            RF();
            HienNCC();
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMaNCC
        private void textBoxMaNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
           && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxSDTNCC
        private void textBoxSDTNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxNCC
        private void textBoxNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTimKiem
        private void textBoxTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
