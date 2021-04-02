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
    public partial class formTaiKhoanSanPham : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();
        formNhapHang f = new formNhapHang();

        public formTaiKhoanSanPham()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;    

            HienDanhSachTaiKhoanMacDinh();

            HienSanPham();

            cbbDanhMuc();
        }

        //HÀM KHI CLICK NÚT ẨN
        private void buttonAn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        //HÀM KHI CLICK NÚT X
        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Close();
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





        //----------MỤC DANH SÁCH TÀI KHOẢN----------
        //HÀM HIỂN THỊ DANH SÁCH TÀI KHOẢN
        void HienDanhSachTaiKhoanMacDinh()
        {
            connection.Open();

            string query = "select Username, MatKhau, TenHienThi, SDT, LoaiTaiKhoan, AnhNhanVien from TaiKhoan where TrangThai = 'On'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewTaiKhoan.DataSource = dt;
            dataGridViewTaiKhoan.Columns[0].Width = 150;
            dataGridViewTaiKhoan.Columns[1].Width = 150;
            dataGridViewTaiKhoan.Columns[2].Width = 150;
            dataGridViewTaiKhoan.Columns[3].Width = 150;
            dataGridViewTaiKhoan.Columns[4].Width = 170;
            dataGridViewTaiKhoan.Columns[5].Visible = false;

            connection.Close();
        }

        public string TaiKhoanDuocChon = "";
        //HÀM KHI CHỌN 1 TÀI KHOẢN TRONG dataGridViewTaiKhoan
        private void dataGridViewTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxNhanVien.Image = null;
            int row = dataGridViewTaiKhoan.CurrentCell.RowIndex;

            if (row >=0)
            {
                TaiKhoanDuocChon = dataGridViewTaiKhoan.Rows[row].Cells[0].Value.ToString();
                textBoxTaiKhoan.Text = dataGridViewTaiKhoan.Rows[row].Cells[0].Value.ToString();
                textBoxMatKhau.Text = dataGridViewTaiKhoan.Rows[row].Cells[1].Value.ToString();
                textBoxTenHienThi.Text = dataGridViewTaiKhoan.Rows[row].Cells[2].Value.ToString();
                textBoxSDT.Text = dataGridViewTaiKhoan.Rows[row].Cells[3].Value.ToString();
                numericUpDownLoaiTaiKhoan.Value = Convert.ToInt32(dataGridViewTaiKhoan.Rows[row].Cells[4].Value);
                linkHinh = dataGridViewTaiKhoan.Rows[row].Cells[5].Value.ToString();
            }

            if (linkHinh == "")
            {
                pictureBoxNhanVien.Image = null;
            }
            else
            {
                pictureBoxNhanVien.Image = Image.FromFile(linkHinh);
            }
        }

        //HÀM TÌM KIẾM TÀI KHOẢN
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string TKtim = textBoxTimKiem.Text;
            if (TKtim != "")
            {
                connection.Open();
                string query = "select Username, MatKhau, TenHienThi, SDT, LoaiTaiKhoan, AnhNhanVien from TaiKhoan where TrangThai = 'On' and (Username like ('%" + TKtim + "%') or MatKhau like ('%" + TKtim + "%') or TenHienThi like ('%" + TKtim + "%') or SDT like ('%" + TKtim + "%'))";
                da = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewTaiKhoan.DataSource = dt;

                dataGridViewTaiKhoan.Columns[0].Width = 150;
                dataGridViewTaiKhoan.Columns[1].Width = 150;
                dataGridViewTaiKhoan.Columns[2].Width = 150;
                dataGridViewTaiKhoan.Columns[3].Width = 150;
                dataGridViewTaiKhoan.Columns[4].Width = 170;
                dataGridViewTaiKhoan.Columns[5].Visible = false;
                connection.Close();
            }

            //
            else
            {
                HienDanhSachTaiKhoanMacDinh();
            }
        }

        public string linkHinh;
        //HÀM THÊM HÌNH NHÂN VIÊN
        private void buttonThemAnhNhanVien_Click(object sender, EventArgs e)
        {
            linkHinh = "";
            using (OpenFileDialog fileHinh = new OpenFileDialog())
            {
                if (fileHinh.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBoxNhanVien.Image = Image.FromFile(fileHinh.FileName);
                        linkHinh = fileHinh.FileName.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng chọn lại file thuộc loại hình ảnh !!!", "Thông báo");
                    }
                }

            }
        }

        //HÀM XÓA HÌNH NHÂN VIÊN
        private void buttonXoaAnhNhanVien_Click(object sender, EventArgs e)
        {
            if (pictureBoxNhanVien.Image != null)
            {
                pictureBoxNhanVien.Image = null;
                linkHinh = "";
            }
        }

        //HÀM REFRESH LẠI CÁC THÔNG TIN TAB TÀI KHOẢN
        void RF()
        {
            textBoxTimKiem.Text = "";
            textBoxTaiKhoan.Text = "";
            textBoxMatKhau.Text = "";
            textBoxTenHienThi.Text = "";
            textBoxSDT.Text = "";
            numericUpDownLoaiTaiKhoan.Value = 1;
            pictureBoxNhanVien.Image = null;
        }

        //HÀM KHI CLICK VÀO NÚT REFRESH
        private void buttonRefesh_Click(object sender, EventArgs e)
        {
            RF();
        }

        //HÀM THÊM TÀI KHOẢN
        private void buttonThem_Click(object sender, EventArgs e)
        {
            //nếu người dùng nhập đầy đủ thông tin
            if (textBoxTaiKhoan.Text != "" && textBoxMatKhau.Text != "" && textBoxTenHienThi.Text != "" && textBoxSDT.Text != "" )
            {
                //kiểm tra các tài khoản đang ẩn trong hệ thống
                connection.Open();
                string queryTKTonTai = "select count(Username) from TaiKhoan where Username = '" + textBoxTaiKhoan.Text + "' and TrangThai = 'Off'";
                OleDbCommand cmdTKTonTai = new OleDbCommand(queryTKTonTai, connection);
                int TKTonTai = Convert.ToInt32(cmdTKTonTai.ExecuteScalar());
                connection.Close();

                //nếu đã tồn tại
                if (TKTonTai > 0)
                {
                    //kiểm tra tên hiển thị của tài khoản người dùng vừa nhập
                    connection.Open();
                    string queryCheckTenHienThi = "select count(TenHienThi) from TaiKhoan where TenHienThi = '" + textBoxTenHienThi.Text + "' and TrangThai='On'";
                    OleDbCommand cmdCheckTenHienThi = new OleDbCommand(queryCheckTenHienThi, connection);
                    int CheckTenHienThi = Convert.ToInt32(cmdCheckTenHienThi.ExecuteScalar());
                    connection.Close();

                    //nếu tên hiển thị đã tồn tại
                    if (CheckTenHienThi > 0)
                    {
                        labelLoiTenHienThi.Visible = true;
                        timerTenHienThi.Start();
                    }
                    //nếu tên hiển thị chưa tồn tại
                    if (CheckTenHienThi == 0)
                    {
                        //nếu tài khoản vừa tạo là của nhân viên thì tạo thêm mục tính lương cho nhân viên đó
                        if (numericUpDownLoaiTaiKhoan.Value.ToString() == "1")      
                        {
                            ThemLuongNV();
                        }

                        //cập nhật lại trạng thái 'On' để có thể sủ dụng tài khoản
                        connection.Open();      
                        string query = "Update TaiKhoan set MatKhau='" + textBoxMatKhau.Text + "', TenHienThi='" + textBoxTenHienThi.Text + "', SDT='" + textBoxSDT.Text + "', LoaiTaiKhoan='" + numericUpDownLoaiTaiKhoan.Value.ToString() + "', TrangThai='On', Thang = " + Convert.ToInt32(DateTime.Now.ToString("MM")) + ", Nam = " + Convert.ToInt32(DateTime.Now.ToString("yyyy")) + ", AnhNhanVien = '"+linkHinh+"' where Username ='" + textBoxTaiKhoan.Text + "'";
                        OleDbCommand cmd = new OleDbCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        HienDanhSachTaiKhoanMacDinh();
                        RF();
                    }
                }

                //nếu không tồn tại
                if (TKTonTai == 0)
                {
                    //kiểm tra tài khoản vừa nhập với các tài khoản đang sử dụng
                    connection.Open();
                    string queryCheckUsername = "select count(Username) from TaiKhoan where Username = '" + textBoxTaiKhoan.Text + "' and TrangThai='On'";
                    OleDbCommand cmdCheckUsername = new OleDbCommand(queryCheckUsername, connection);
                    int CheckUsername = Convert.ToInt32(cmdCheckUsername.ExecuteScalar());
                    connection.Close();

                    //nếu tài khoản đã tồn tại và TrangThai = 'On'
                    if (CheckUsername > 0)
                    {
                        labelLoiTaiKhoan.Visible = true;
                        timerTaiKhoan.Start();
                    }
                    //nếu tài khoản chưa tồn tại
                    if (CheckUsername == 0)
                    {
                        //kiểm tra tên hiển thị vừa nhập
                        connection.Open();
                        string queryCheckTenHienThi = "select count(TenHienThi) from TaiKhoan where TenHienThi = '" + textBoxTenHienThi.Text + "' and TrangThai='On'";
                        OleDbCommand cmdCheckTenHienThi = new OleDbCommand(queryCheckTenHienThi, connection);
                        int CheckTenHienThi = Convert.ToInt32(cmdCheckTenHienThi.ExecuteScalar());
                        connection.Close();

                        //nếu tên hiển thị vừa nhập đã tồn tại
                        if (CheckTenHienThi > 0)
                        {
                            labelLoiTenHienThi.Visible = true;
                            timerTenHienThi.Start();
                        }
                        //nếu tên hiển thị chưa tồn tại
                        if (CheckTenHienThi == 0)
                        {
                            //thêm tài khoản vào hệ thống
                            connection.Open();
                            string query = "insert into TaiKhoan (Username, MatKhau, TenHienThi, SDT, LoaiTaiKhoan, Thang, Nam, TrangThai, AnhNhanVien) values ('" + textBoxTaiKhoan.Text + "', '" + textBoxMatKhau.Text + "', '" + textBoxTenHienThi.Text + "', '" + textBoxSDT.Text + "', '" + numericUpDownLoaiTaiKhoan.Value.ToString() + "', '" + Convert.ToInt32(DateTime.Now.ToString("MM")) + "', '" + Convert.ToInt32(DateTime.Now.ToString("yyyy")) + "', 'On', '"+linkHinh+"')";
                            OleDbCommand cmd = new OleDbCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            //nếu tài khoản vừa tạo là của nhân viên thì tạo thêm mục tính lương cho nhân viên đó
                            if (numericUpDownLoaiTaiKhoan.Value.ToString() == "1")     
                            {
                                ThemLuongNV();
                            }                         

                            HienDanhSachTaiKhoanMacDinh();
                            RF();   
                        }
                    }
                }                  
            }

            else
            {
                MessageBox.Show("Bạn phải nhập đủ thông tin","Thông báo");
            }
        }

        //HÀM THÊM THÔNG TIN LƯƠNG CHO NHÂN VIÊN MỚI
        void ThemLuongNV()
        {
            connection.Open();

            //kiểm tra xem tháng hiện tại có tất cả thông tin lương của toàn bộ nhân viên hay không
            string querySLNV = "select Username from TaiKhoan where LoaiTaiKhoan = '1' and TrangThai = 'On' ";
            da = new OleDbDataAdapter(querySLNV, connection);
            DataTable dtSLNV = new DataTable();
            da.Fill(dtSLNV);

            //kiểm tra xem thông tin lương nhân viên trong bảng lương có tồn tại hay không
            string queryCheckSLThongTinNV = "select Username from GioCongVaLuongNhanVien where Thang = " + Convert.ToInt32(DateTime.Now.ToString("MM")) + " and Nam = " + Convert.ToInt32(DateTime.Now.ToString("yyyy")) + " ";
            da = new OleDbDataAdapter(queryCheckSLThongTinNV, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            connection.Close();

            //nếu đã có thông tin lương nhân viên của các nhân viên hiện tại (trừ nhân viên mới)
            if (dt.Rows.Count > 0)
            {
                connection.Open();
                string queryThemLuongThangHienTai = "insert into GioCongVaLuongNhanVien (Username, Nam, Thang) values ('" + textBoxTaiKhoan.Text + "', " + Convert.ToInt32(DateTime.Now.Year.ToString()) + ", " + Convert.ToInt32(DateTime.Now.Month.ToString()) + ")";
                OleDbCommand cmdThemLuongThangHienTai = new OleDbCommand(queryThemLuongThangHienTai, connection);
                cmdThemLuongThangHienTai.ExecuteNonQuery();
                connection.Close();
            }
            //nếu chưa có thông tin lương của toàn bộ nhân viên hiện tại và nhân viên mới
            else if (dt.Rows.Count == 0)
            {
                for (int i = 0; i < dtSLNV.Rows.Count; i++)
                {
                    connection.Open();
                    string queryThemLuongThangHienTai = "insert into GioCongVaLuongNhanVien (Username, Nam, Thang) values ('" + dtSLNV.Rows[i].ItemArray[0].ToString() + "', " + Convert.ToInt32(DateTime.Now.Year.ToString()) + ", " + Convert.ToInt32(DateTime.Now.Month.ToString()) + ")";
                    OleDbCommand cmdThemLuongThangHienTai = new OleDbCommand(queryThemLuongThangHienTai, connection);
                    cmdThemLuongThangHienTai.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        //HÀM SỬA TÀI KHOẢN
        private void buttonSua_Click(object sender, EventArgs e)
        {
            //nếu người dùng nhập đầy đủ thông tin
            if (textBoxTaiKhoan.Text != "" && textBoxMatKhau.Text != "" && textBoxTenHienThi.Text != "" && textBoxSDT.Text != "")
            {
                //kiểm tra tài khoản có tồn tại hay không
                connection.Open();                
                string queryCheckUsername = "select count(Username) from TaiKhoan where Username = '" + textBoxTaiKhoan.Text + "' and TrangThai = 'On'";
                OleDbCommand cmdCheckUsername = new OleDbCommand(queryCheckUsername, connection);
                int CheckUsername = Convert.ToInt32(cmdCheckUsername.ExecuteScalar());
                connection.Close();

                //nếu tài khoản tồn tại
                if (CheckUsername > 0)
                {
                    //lấy tên hiển thị hiện tại của textBoxTaiKhoan
                    connection.Open();
                    string queryCheckTenHienThiCu = "select TenHienThi from TaiKhoan where Username = '"+textBoxTaiKhoan.Text+"' and TrangThai='On'";
                    OleDbCommand cmdCheckTenHienThiCu = new OleDbCommand(queryCheckTenHienThiCu, connection);
                    string CheckTenHienThiCu = cmdCheckTenHienThiCu.ExecuteScalar().ToString();
                    connection.Close();

                    //nếu tên hiển thị người dùng muốn đổi khác với tên hiển thị hiện tại của tài khoản
                    if (CheckTenHienThiCu != textBoxTenHienThi.Text)
                    {
                        //kiểm tra tên hiển thị người dùng vừa nhập xem có trùng với các tên hiển thị khác trong hệ thống hay không
                        connection.Open();
                        string queryCheckTenHienThi = "select count(TenHienThi) from TaiKhoan where TenHienThi = '" + textBoxTenHienThi.Text + "'  and TrangThai='On'";
                        OleDbCommand cmdCheckTenHienThi = new OleDbCommand(queryCheckTenHienThi, connection);
                        int CheckTenHienThi = Convert.ToInt32(cmdCheckTenHienThi.ExecuteScalar());
                        connection.Close();

                        //nếu tên hiển thị người dùng vừa nhập đã tồn tại
                        if (CheckTenHienThi > 0)
                        {
                            labelLoiTenHienThi.Visible = true;
                            timerTenHienThi.Start();
                        }

                        //nếu tên hiển thị người dùng vừa nhập chưa có
                        if (CheckTenHienThi == 0)
                        {
                            //cập nhật tài khoản
                            connection.Open();
                            string query = "update TaiKhoan set MatKhau='" + textBoxMatKhau.Text + "', TenHienThi='" + textBoxTenHienThi.Text + "', SDT='" + textBoxSDT.Text + "', LoaiTaiKhoan='" + numericUpDownLoaiTaiKhoan.Value.ToString() + "', AnhNhanVien = '"+linkHinh+"' where Username = '" + textBoxTaiKhoan.Text + "'  and TrangThai='On'";
                            OleDbCommand cmd = new OleDbCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            HienDanhSachTaiKhoanMacDinh();

                            pictureBoxThongBaoTKTC.Visible = true;
                            timerTTTK.Start();
                        }
                    }

                    //nếu tên hiển thị người dùng muốn đổi == tên hiển thị hiện tại của tài khoản
                    if (CheckTenHienThiCu == textBoxTenHienThi.Text) 
                    {
                        //cập nhật tài khoản
                        connection.Open();
                        string query = "update TaiKhoan set MatKhau='" + textBoxMatKhau.Text + "', SDT='" + textBoxSDT.Text + "', LoaiTaiKhoan='" + numericUpDownLoaiTaiKhoan.Value.ToString() + "', AnhNhanVien = '" + linkHinh + "' where Username = '" + textBoxTaiKhoan.Text + "' and TrangThai='On'";
                        OleDbCommand cmd = new OleDbCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        HienDanhSachTaiKhoanMacDinh();

                        pictureBoxThongBaoTKTC.Visible = true;
                        timerTTTK.Start();
                    }           
                }
                //nếu tài khoản không tồn tại
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại, vui lòng xem lại !!!", "Thông báo");
                }
            }
            //nếu người dùng nhập chưa đủ thông tin
            else
            {
                MessageBox.Show("Bạn phải nhập đủ thông tin", "Thông báo");
            }
        }

        //HÀM XÓA TÀI KHOẢN
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.OK)
            {
                //nếu người dùng nhập đầy đủ thông tin
                if (textBoxTaiKhoan.Text != "" && textBoxMatKhau.Text != "" && textBoxTenHienThi.Text != "" && textBoxSDT.Text != "")
                {
                    //kiểm tra xem tài khoản xem có tồn tại hay không
                    connection.Open();
                    string queryCheckUsername = "select count(Username) from TaiKhoan where Username = '" + textBoxTaiKhoan.Text + "' and TrangThai = 'On'";
                    OleDbCommand cmdCheckUsername = new OleDbCommand(queryCheckUsername, connection);
                    int CheckUsername = Convert.ToInt32(cmdCheckUsername.ExecuteScalar());
                    connection.Close();

                    //nếu tài khoản tồn tại
                    if (CheckUsername > 0)
                    {
                        //chuyển trạng thái tài khoản thành 'Off' và ẩn tài khoản 
                        connection.Open();
                        string query = "Update TaiKhoan set TrangThai='Off' where Username ='" + textBoxTaiKhoan.Text + "'";
                        OleDbCommand cmd = new OleDbCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        HienDanhSachTaiKhoanMacDinh();
                        RF();
                        pictureBoxThongBaoTKTC.Visible = true;
                        timerTTTK.Start();
                    }
                    //nếu tài khoản không tồn tại
                    else
                    {
                        MessageBox.Show("Tài khoản bạn xóa không tồn tại trong hệ thống", "Thông báo");
                    }
                }
                //nếu chưa nhập đủ thông tin
                else
                {
                    MessageBox.Show("Bạn phải nhập đủ thông tin tài khoản cần xóa", "Thông báo");
                }
            }
        }

        public int TTTK = 0;
        //HÀM THÔNG BÁO ĐÃ THỰC HIỆN THÀNH CÔNG
        private void timerTTTK_Tick(object sender, EventArgs e)
        {
            TTTK++;
            if (TTTK == 2)
            {
                timerTTTK.Stop();
                pictureBoxThongBaoTKTC.Visible = false;
                timerTTTK.Enabled = false;
                TTTK = 0;
            }
        }

        public int countTaiKhoan = 0;
        //HÀM HIỂN THỊ LỖI KHI TÀI KHOẢN KHÔNG HỢP LỆ
        private void timerTaiKhoan_Tick(object sender, EventArgs e)
        {
            countTaiKhoan++;
            if (countTaiKhoan == 2)
            {
                timerTaiKhoan.Stop();
                labelLoiTaiKhoan.Visible = false;
                timerTaiKhoan.Enabled = false;
                countTaiKhoan = 0;
            }
        }

        public int countTenHienThi = 0;
        //HÀM HIỂN THỊ LỖI KHI TÊN HIỂN THỊ KHÔNG HỢP LỆ
        private void timerTenHienThi_Tick(object sender, EventArgs e)
        {
            countTenHienThi++;
            if (countTenHienThi == 2)
            {
                timerTenHienThi.Stop();
                labelLoiTenHienThi.Visible = false;
                timerTenHienThi.Enabled = false;
                countTenHienThi = 0;
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTaiKhoan
        private void textBoxTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
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

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTenHienThi
        private void textBoxTenHienThi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxSDT
        private void textBoxSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }





        //----------MỤC DANH SÁCH SẢN PHẨM----------
        //HÀM HIỆN DANH SÁCH SẢN PHẨM
        void HienSanPham()
        {
            connection.Open();

            string query = "select MaSP, TenSP, GiaGoc, GiaBan, DanhMuc, SoLuongTon, AnhSanPham from SanPham where TrangThai = 'ban' order by MaSP";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewSanPham.DataSource = dt;
            dataGridViewSanPham.Columns[0].Width = 150;
            dataGridViewSanPham.Columns[1].Width = 150;
            dataGridViewSanPham.Columns[2].Width = 150;
            dataGridViewSanPham.Columns[3].Width = 150;
            dataGridViewSanPham.Columns[4].Width = 170;
            dataGridViewSanPham.Columns[5].Width = 170;
            dataGridViewSanPham.Columns[6].Visible = false;
            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            connection.Close();
        }

        //HÀM TÌM KIẾM SẢN PHẨM
        private void textBoxTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            string SPtim = textBoxTimKiemSP.Text;
            connection.Open();

            string query = "select MaSP, TenSP, GiaGoc, GiaBan, DanhMuc, SoLuongTon, AnhSanPham from SanPham where TrangThai = 'ban' and (MaSP like ('%" + SPtim + "%') or TenSP like ('%" + SPtim + "%') or GiaGoc like ('%" + SPtim + "%') or GiaBan like ('%" + SPtim + "%') or DanhMuc like ('%" + SPtim + "%') or SoLuongTon like ('%" + SPtim + "%')) order by MaSP";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewSanPham.DataSource = dt;
            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[6].Visible = false;
            dataGridViewSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            connection.Close();
        }

        //HÀM HIỂN THỊ THÔNG TIN DANH MỤC
        void cbbDanhMuc()
        {
            connection.Open();
            string query = "select  DanhMuc from DanhMuc";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DanhMuc", typeof(string));
            dt.Rows.Add("--");
            dt.Load(reader);

            comboBoxDanhMuc.ValueMember = "DanhMuc";
            comboBoxDanhMuc.DisplayMember = "DanhMuc";
            comboBoxDanhMuc.DataSource = dt;

            connection.Close();
        }

        //HÀM CHI CHỌN VÀO 1 SẢN PHẨM TRONG DANH SÁCH
        private void dataGridViewSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewSanPham.CurrentCell.RowIndex;

            if (row >= 0)
            {
                textBoxMaSP.Text = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                textBoxTenSP.Text = dataGridViewSanPham.Rows[row].Cells[1].Value.ToString();
                numericUpDownGiaGoc.Value = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value);
                numericUpDownGiaBan.Value = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value);

                int kqcbb=0;
                for (int i = 0; i < comboBoxDanhMuc.Items.Count; i ++)
                {
                    if (comboBoxDanhMuc.GetItemText(comboBoxDanhMuc.Items[i]) == dataGridViewSanPham.Rows[row].Cells[4].Value.ToString())
                    {
                        kqcbb = i;
                    }
                }
                comboBoxDanhMuc.SelectedIndex = kqcbb;
                numericUpDownSLTon.Value = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[5].Value);

                linkHinhSanPham = dataGridViewSanPham.Rows[row].Cells[6].Value.ToString();
            }

            if (linkHinhSanPham != "")
            {
                pictureBoxHinhSanPham.Image = Image.FromFile(linkHinhSanPham);
            }

            else
            {
                pictureBoxHinhSanPham.Image = null;
            }
        }

        public string linkHinhSanPham;
        //HÀM THÊM HÌNH ẢNH CHO SẢN PHẨM
        private void buttonThemHinhSanPham_Click(object sender, EventArgs e)
        {
            linkHinhSanPham = "";
            using (OpenFileDialog fileHinh = new OpenFileDialog())
            {
                if (fileHinh.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBoxHinhSanPham.Image = Image.FromFile(fileHinh.FileName);
                        linkHinhSanPham = fileHinh.FileName.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng chọn lại file thuộc loại hình ảnh !!!", "Thông báo");
                    }
                }

            }
        }

        //HÀM XÓA HÌNH ẢNH SẢN PHẨM
        private void buttonXoaHinhSanPham_Click(object sender, EventArgs e)
        {
            if (pictureBoxHinhSanPham.Image != null)
            {
                pictureBoxHinhSanPham.Image = null;
                linkHinhSanPham = "";
            }
        }

        //HÀM REFRESH THÔNG TIN TAB QUẢN LÝ SẢN PHẨM
        void RFSP()
        {
            textBoxTimKiemSP.Text = "";
            textBoxMaSP.Text = "";
            textBoxTenSP.Text = "";
            numericUpDownGiaGoc.Value = 0;
            numericUpDownGiaBan.Value = 0;
            comboBoxDanhMuc.SelectedIndex = 0;
            numericUpDownSLTon.Value = 0;
            HienSanPham();
        }

        //HÀM KHI CLICK VÀO NÚT REFRESH
        private void buttonRefeshSP_Click(object sender, EventArgs e)
        {
            RFSP();
        }
  
        //HÀM THÊM SẢN PHẨM
        private void buttonThemSP_Click(object sender, EventArgs e)
        {
            //nếu người dùng chưa nhập đầy đủ thông tin
            if (textBoxMaSP.Text == "" || textBoxTenSP.Text == "")
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin sản phẩm !!!", "Thông báo");
            }
            //nếu người dùng nhập đủ thông tin
            else
            {
                //kiểm tra sản phẩm có tồn tại ở trong danh sách các sản phẩm đang ẩn hay không
                connection.Open();
                string queryCheckMaSPkhongban = "select count(MaSP) from SanPham where MaSP = '" + textBoxMaSP.Text + "' and TrangThai = 'khongban'";
                OleDbCommand cmdCheckMaSPkhongban = new OleDbCommand(queryCheckMaSPkhongban, connection);
                int CheckMaSPkhongban = Convert.ToInt32(cmdCheckMaSPkhongban.ExecuteScalar());
                connection.Close();

                //nếu sản phẩm đã tồn tại
                if (CheckMaSPkhongban > 0)
                {
                    //kiểm tra tên sản phẩm với tên những sản phẩm đang bán
                    connection.Open();
                    string queryCheckTenSPban = "select count(TenSP) from SanPham where TenSP = '" + textBoxTenSP.Text + "' and TrangThai = 'ban'";
                    OleDbCommand cmdCheckTenSPban = new OleDbCommand(queryCheckTenSPban, connection);
                    int CheckTenSPban = Convert.ToInt32(cmdCheckTenSPban.ExecuteScalar());
                    connection.Close();

                    //nếu tên sản phẩm đã tồn tại
                    if (CheckTenSPban > 0)
                    {
                        labelLoiTenSP.Visible = true;
                        timerLoiTenSP.Start();
                    }

                    //nếu tên sản phẩm không tồn tại
                    if (CheckTenSPban == 0)
                    {
                        //nếu chưa chọn danh mục
                        if (comboBoxDanhMuc.SelectedIndex == 0)
                        {
                            labelLoiDanhMucSP.Visible = true;
                            timerLoiDanhMucSP.Start();
                        }
                        //nếu đãcchọn danh mục
                        if (comboBoxDanhMuc.SelectedIndex != 0)
                        {
                            //chuyển trạng thái sản phẩm thành 'ban'
                            connection.Open();
                            string query = "update SanPham set TenSP = '" + textBoxTenSP.Text + "', GiaGoc = " + numericUpDownGiaGoc.Value + ", GiaBan = " + numericUpDownGiaBan.Value + ",DanhMuc = '" + comboBoxDanhMuc.GetItemText(this.comboBoxDanhMuc.SelectedItem) + "', SoLuongTon = " + numericUpDownSLTon.Value + ", TrangThai= 'ban', AnhSanPham = '"+ linkHinhSanPham + "' where MaSP = '" + textBoxMaSP.Text + "'";
                            OleDbCommand cmd = new OleDbCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            pictureBoxThongBaoSPTC.Visible = true;
                            timerTCSP.Start();

                            HienSanPham();
                            RFSP();
                        }
                    }
                }

                //nếu sản phẩm chưa tồn tại
                if (CheckMaSPkhongban == 0)
                {
                    //kiểm tra mã sản phẩm có trùng với các sản phẩm đang bán không
                    connection.Open();
                    string queryCheckMaSPban = "select count(MaSP) from SanPham where MaSP = '" + textBoxMaSP.Text + "' and TrangThai = 'ban'";
                    OleDbCommand cmdCheckMaSPban = new OleDbCommand(queryCheckMaSPban, connection);
                    int CheckMaSPban = Convert.ToInt32(cmdCheckMaSPban.ExecuteScalar());
                    connection.Close();

                    //nếu mã sản phẩm đã tồn tại
                    if (CheckMaSPban > 0)
                    {
                        labelLoiMaSP.Visible = true;
                        timerLoiMaSP.Start();
                    }

                    //nếu mã sản phẩm chưa tồn tại
                    if (CheckMaSPban == 0)
                    {
                        //kiểm tra tên sản phẩm vừa nhập với tên của những sản phẩm đang bán
                        connection.Open();
                        string queryCheckTenSPban = "select count(TenSP) from SanPham where TenSP = '" + textBoxTenSP.Text + "' and TrangThai = 'ban'";
                        OleDbCommand cmdCheckTenSPban = new OleDbCommand(queryCheckTenSPban, connection);
                        int CheckTenSPban = Convert.ToInt32(cmdCheckTenSPban.ExecuteScalar());
                        connection.Close();

                        //nếu tên sản phẩm bị trùng
                        if (CheckTenSPban > 0)
                        {
                            labelLoiTenSP.Visible = true;
                            timerLoiTenSP.Start();
                        }
                        //nếu tên sản phẩm không trùng
                        if (CheckTenSPban == 0)
                        {
                            //nếu chưa chọn danh mục
                            if (comboBoxDanhMuc.SelectedIndex == 0)
                            {
                                labelLoiDanhMucSP.Visible = true;
                                timerLoiDanhMucSP.Start();
                            }
                            //nếu đã chọn danh mục
                            if (comboBoxDanhMuc.SelectedIndex != 0)
                            {
                                //thêm sản phẩm vào hệ thống
                                connection.Open();
                                string query = "insert into SanPham (MaSP,TenSP,GiaGoc,GiaBan,DanhMuc,SoLuongTon,TrangThai,AnhSanPham) values ('" + textBoxMaSP.Text + "', '" + textBoxTenSP.Text + "', " + numericUpDownGiaGoc.Value + ", " + numericUpDownGiaBan.Value + ", '" + comboBoxDanhMuc.GetItemText(this.comboBoxDanhMuc.SelectedItem) + "', " + numericUpDownSLTon.Value + ", 'ban', '"+linkHinhSanPham+"')";
                                OleDbCommand cmd = new OleDbCommand(query, connection);
                                cmd.ExecuteNonQuery();
                                connection.Close();

                                pictureBoxThongBaoSPTC.Visible = true;
                                timerTCSP.Start();

                                HienSanPham();
                                RFSP();
                            }
                        }
                    }
                }
            }           
        }

        //HÀM SỬA SẢN PHẨM
        private void buttonSuaSP_Click(object sender, EventArgs e)
        {
            //nếu chưa nhập đủ thông tin 
            if (textBoxMaSP.Text == "" || textBoxTenSP.Text == "")
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin sản phẩm !!!","Thông báo");
            }
            
            //nếu đã nhập đủ thông tin
            else
            {
                //lấy tên sản phẩm với mã sản phẩm của textBoxMaSP
                connection.Open();
                string queryTenCu = "select TenSP from SanPham where MaSP = '"+textBoxMaSP.Text+"' ";
                OleDbCommand cmdTenCu = new OleDbCommand(queryTenCu, connection);
                string TenCu = cmdTenCu.ExecuteScalar().ToString();
                connection.Close();

                //nếu tên sản phẩm mới khác tên sản phẩm hiện tại
                if (textBoxTenSP.Text != TenCu)
                {
                    //kiểm tra tên sản phẩm mới có trùng với các tên sản phẩm đang bán hay không
                    connection.Open();
                    string queryCheckTenSPban = "select count(TenSP) from SanPham where TenSP = '" + textBoxTenSP.Text + "' and TrangThai = 'ban'";
                    OleDbCommand cmdCheckTenSPban = new OleDbCommand(queryCheckTenSPban, connection);
                    int CheckTenSPban = Convert.ToInt32(cmdCheckTenSPban.ExecuteScalar());
                    connection.Close();

                    //nếu tên sản phẩm mới bị trùng
                    if (CheckTenSPban > 0)
                    {
                        labelLoiTenSP.Visible = true;
                        timerLoiTenSP.Start();
                    }

                    //nếu tên sản phẩm mới không trùng
                    else if (CheckTenSPban == 0)
                    {
                        //nếu chưa chọn danh mục
                        if (comboBoxDanhMuc.SelectedIndex == 0)
                        {
                            labelLoiDanhMucSP.Visible = true;
                            timerLoiDanhMucSP.Start();
                        }
                        //nếu đã chọn danh mục
                        if (comboBoxDanhMuc.SelectedIndex != 0)
                        {
                            //cập nhật sản phẩm
                            connection.Open();
                            string query = "update SanPham set TenSP = '" + textBoxTenSP.Text + "', GiaGoc = " + numericUpDownGiaGoc.Value + ", GiaBan = " + numericUpDownGiaBan.Value + ",DanhMuc = '" + comboBoxDanhMuc.GetItemText(this.comboBoxDanhMuc.SelectedItem) + "', SoLuongTon = " + numericUpDownSLTon.Value + ", TrangThai= 'ban', AnhSanPham = '" + linkHinhSanPham + "' where MaSP = '" + textBoxMaSP.Text + "'";
                            OleDbCommand cmd = new OleDbCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            pictureBoxThongBaoSPTC.Visible = true;
                            timerTCSP.Start();

                            HienSanPham();
                        }
                    }
                }
                //nếu tên sản phẩm mới trùng với tên sản phẩm hiện tại
                else
                {
                    //nếu chưa chọn danh mục
                    if (comboBoxDanhMuc.SelectedIndex == 0)
                    {
                        labelLoiDanhMucSP.Visible = true;
                        timerLoiDanhMucSP.Start();
                    }
                    //nếu đã chọn danh mục
                    if (comboBoxDanhMuc.SelectedIndex != 0)
                    {
                        //cập nhật sản phẩm
                        connection.Open();
                        string query = "update SanPham set GiaGoc = " + numericUpDownGiaGoc.Value + ", GiaBan = " + numericUpDownGiaBan.Value + ",DanhMuc = '" + comboBoxDanhMuc.GetItemText(this.comboBoxDanhMuc.SelectedItem) + "', SoLuongTon = " + numericUpDownSLTon.Value + ", TrangThai= 'ban', AnhSanPham = '" + linkHinhSanPham + "' where MaSP = '" + textBoxMaSP.Text + "'";
                        OleDbCommand cmd = new OleDbCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        pictureBoxThongBaoSPTC.Visible = true;
                        timerTCSP.Start();

                        HienSanPham();
                    }
                }
            }       
        }

        //HÀM XÓA SẢN PHẨM
        private void buttonXoaSP_Click(object sender, EventArgs e)
        {
            //nếu chưa có thông tin sản phẩm cần xóa
            if (textBoxMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa !!!", "Thông báo");
            }
            //nếu đã có thông tin sản phẩm cần xóa
            else
            {
                //chuyển trạng thái sản phẩm thành 'khongban' và ẩn khỏi danh sách
                connection.Open();
                string query = "update SanPham set TrangThai= 'khongban' where MaSP = '" + textBoxMaSP.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.ExecuteNonQuery();


                pictureBoxThongBaoSPTC.Visible = true;
                timerTCSP.Start();

                connection.Close();
                HienSanPham();
                RFSP();
            }
        }

        //HÀM KHI NHẤN NÚT THÊM DANH MỤC
        private void buttonThemDanhMuc_Click(object sender, EventArgs e)
        {
            formDanhMucSanPham f = new formDanhMucSanPham();
            f.ShowDialog();
            cbbDanhMuc();
        }

        //HÀM KHI NHẤN NÚT DANH SÁCH SẢN PHẨM
        private void buttonDSPN_Click(object sender, EventArgs e)
        {
            formNhapHang f = new formNhapHang();
            f.ShowDialog();
            HienSanPham();
        }

        public int countSP = 0;
        //HÀM THÔNG BÁO THÀNH CÔNG CỦA TAB DANH SÁCH SẢN PHẨM
        private void timerTCSP_Tick(object sender, EventArgs e)
        {
            countSP++;
            if (countSP == 2)
            {
                timerTCSP.Stop();
                pictureBoxThongBaoSPTC.Visible = false;
                timerTCSP.Enabled = false;
                countSP = 0;
            }
        }

        public int LoiMaSP = 0;
        //HÀM THÔNG BÁO LỖI MÃ SẢN PHẨM
        private void timerLoiMaSP_Tick(object sender, EventArgs e)
        {
            LoiMaSP++;
            if (LoiMaSP == 2)
            {
                timerLoiMaSP.Stop();
                labelLoiMaSP.Visible = false;
                timerLoiMaSP.Enabled = false;
                LoiMaSP = 0;
            }
        }

        public int LoiTenSP = 0;
        //HÀM THÔNG BÁO LỖI TÊN SẢN PHẨM
        private void timerLoiTenSP_Tick(object sender, EventArgs e)
        {
            LoiTenSP++;
            if (LoiTenSP == 2)
            {
                timerLoiTenSP.Stop();
                labelLoiTenSP.Visible = false;
                timerLoiTenSP.Enabled = false;
                LoiTenSP = 0;
            }
        }

        public int LoiDanhMucSP = 0;
        //HÀM THÔNG BÁO LỖI CHƯA CHỌN DANH MỤC
        private void timerLoiDanhMucSP_Tick(object sender, EventArgs e)
        {
            LoiDanhMucSP++;
            if (LoiDanhMucSP == 2)
            {
                timerLoiDanhMucSP.Stop();
                labelLoiDanhMucSP.Visible = false;
                timerLoiDanhMucSP.Enabled = false;
                LoiDanhMucSP = 0;
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMaSP
        private void textBoxMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTenSP
        private void textBoxTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
