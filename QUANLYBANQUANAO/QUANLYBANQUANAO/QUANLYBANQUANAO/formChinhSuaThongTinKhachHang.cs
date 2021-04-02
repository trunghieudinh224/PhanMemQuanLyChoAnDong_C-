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
    public partial class formChinhSuaThongTinKhachHang : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();
        public formChinhSuaThongTinKhachHang()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienThiPanel();

            PanelCapNhatKH();
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

        //HÀM HIỂN THỊ PANEL
        void HienThiPanel()
        {
            if (formDanhSachKhachHang.LuaChonTuyChinh == "CapNhat")
            {
                panelCapNhat.Visible = true;
                panelThem.Visible = false;
                labelTieuDeForm.Text = "CẬP NHẬT THÔNG TIN KHÁCH HÀNG";
            }
            else
            {
                panelCapNhat.Visible = false;
                panelThem.Visible = true;
                labelTieuDeForm.Text = "THÊM THÔNG TIN KHÁCH HÀNG MỚI";
            }
        }





        //----------CÁC HÀM DÙNG CHUNG----------
        //HÀM KIỂM TRA SDT KHÁCH HÀNG MỚI VỚI LOẠI TÀI KHOẢN khachquen
        public int KiemTraSDT_KhachQuen(TextBox tb)
        {
            connection.Open();
            string queryKiemTraSDT_KQ = "select count(SDTKhachHang) from KhachHang where SDTKhachHang = '" + tb.Text + "' and LoaiKhachHang = 'khachquen'";
            OleDbCommand cmdKiemTraSDT_KQ = new OleDbCommand(queryKiemTraSDT_KQ, connection);
            int KiemTraSDT_KQ = Convert.ToInt32(cmdKiemTraSDT_KQ.ExecuteScalar());
            connection.Close();

            return KiemTraSDT_KQ;
        }

        //HÀM KIỂM TRA SDT KHÁCH HÀNG MỚI VỚI LOẠI TÀI KHOẢN khachvanglai
        public int KiemTraSDT_KhachVangLai(TextBox tb)
        {
            //kiểm tra sdt khách hàng mới với loại khachvanglai
            connection.Open();
            string queryKiemTraSDT_KVL = "select count(SDTKhachHang) from KhachHang where SDTKhachHang = '" + tb.Text + "' and LoaiKhachHang = 'khachvanglai'";
            OleDbCommand cmdKiemTraSDT_KVL = new OleDbCommand(queryKiemTraSDT_KVL, connection);
            int KiemTraSDT_KVL = Convert.ToInt32(cmdKiemTraSDT_KVL.ExecuteScalar());
            connection.Close();

            return KiemTraSDT_KVL;
        }

        //HÀM KIỂM TRA TÊN KHÁCH HÀNG MỚI VỚI LOẠI TÀI KHOẢN khachquen
        public int KiemTraTen_KhachQuen(TextBox tb)
        {
            //kiểm tra tên khách hàng mới với loại khachquen
            connection.Open();
            string queryKiemTraTen_KQ = "select count(HoTenKhachHang) from KhachHang where HoTenKhachHang = '" + tb.Text + "' and LoaiKhachHang = 'khachquen'";
            OleDbCommand cmdKiemTraTen_KQ = new OleDbCommand(queryKiemTraTen_KQ, connection);
            int KiemTraTen_KQ = Convert.ToInt32(cmdKiemTraTen_KQ.ExecuteScalar());
            connection.Close();

            return KiemTraTen_KQ;
        }





        //----------CẬP NHẬT THÔNG TIN MỚI CỦA KHÁCH HÀNG----------
        //HÀM CẬP NHẬT THÔNG TIN HIỆN TẠI SAU KHI CẬP NHẬT DỮ LIỆU MỚI
        void PanelCapNhatKH()
        {
            textBoxTenHienTai.Text = formDanhSachKhachHang.TenKhachHang_HienTai;
            textBoxSDTHienTai.Text = formDanhSachKhachHang.SDTKhachHang_HienTai;
            textBoxDiaChiHienTai.Text = formDanhSachKhachHang.DiaChiKhachHang_HienTai;
        }

        //HÀM CẬP NHẬT THÔNG TIN KHÁCH HÀNG
        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            textBoxSDTThayDoi.BackColor = Color.White;
            textBoxTenKhachThayDoi.BackColor = Color.White;
            //nếu nhập đủ thông tin cần cập nhật
            if (textBoxSDTThayDoi.Text != "" && textBoxTenKhachThayDoi.Text != "")
            {
                //nếu thông tin mới giống hệt thông tin cũ
                if (textBoxSDTThayDoi.Text == textBoxSDTHienTai.Text && textBoxTenKhachThayDoi.Text == textBoxTenHienTai.Text && textBoxDiaChiThayDoi.Text == textBoxDiaChiHienTai.Text)
                {
                    pictureBoxCheckCapNhat.Visible = true;
                    timerCheckCapNhat.Start();
                }

                //nếu thông tin mới khác thông tin cũ
                else
                {
                    //nếu thông tin mới khác tên khách hàng
                    if (textBoxSDTThayDoi.Text == textBoxSDTHienTai.Text && textBoxTenKhachThayDoi.Text != textBoxTenHienTai.Text)
                    {
                        //nếu tên mới không trùng tên khách hàng với loại khachquen
                        if (KiemTraTen_KhachQuen(textBoxTenKhachThayDoi) == 0)
                        {
                            connection.Open();
                            string query = "update KhachHang set HoTenKhachHang = '" + textBoxTenKhachThayDoi.Text + "' where SDTKhachHang = '" + textBoxSDTThayDoi.Text + "'";
                            OleDbCommand cmd = new OleDbCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            pictureBoxCheckCapNhat.Visible = true;
                            timerCheckCapNhat.Start();
                        }

                        //nếu tên mới trùng với tên khách hàng với loại khachquen
                        else
                        {
                            textBoxTenKhachThayDoi.BackColor = Color.Silver;
                            MessageBox.Show("Tên khách hàng đã tồn tại, vui lòng nhập lại !!!", "Thông báo");
                        }
                    }

                    //nếu thông tin mới khác SDT khách hàng
                    else if (textBoxSDTThayDoi.Text != textBoxSDTHienTai.Text && textBoxTenKhachThayDoi.Text == textBoxTenHienTai.Text)
                    {
                        //nếu sdt khách mới không trùng với các sdt khách hàng loại khachquen
                        if (KiemTraSDT_KhachQuen(textBoxSDTThayDoi) == 0)
                        {
                            //nếu sdt mới không trùng với các sdt khách hàng loại khachvanglai
                            if (KiemTraSDT_KhachVangLai(textBoxSDTThayDoi) == 0)
                            {
                                connection.Open();
                                string query = "update KhachHang set SDTKhachHang = '" + textBoxSDTThayDoi.Text + "' where SDTKhachHang = '" + textBoxSDTHienTai.Text + "'";
                                OleDbCommand cmd = new OleDbCommand(query, connection);
                                cmd.ExecuteNonQuery();
                                connection.Close();

                                pictureBoxCheckCapNhat.Visible = true;
                                timerCheckCapNhat.Start();
                            }

                            //nếu sdt mới trùng với các sdt khách hàng loại khachvanglai
                            else
                            {
                                connection.Open();
                                //ẩn khách hàng hiện tại
                                string queryAnKhach = "update KhachHang set LoaiKhachHang = 'khachvanglai' where SDTKhachHang = '" + textBoxSDTHienTai.Text + "'";
                                OleDbCommand cmdAnKhach = new OleDbCommand(queryAnKhach, connection);
                                cmdAnKhach.ExecuteNonQuery();

                                //hiện khách hàng trùng thông tin khách thay đổi
                                string query = "update KhachHang set LoaiKhachHang = 'khachquen', HoTenKhachHang = '"+ textBoxTenKhachThayDoi.Text +"', DiaChiKhachHang = '"+ textBoxDiaChiThayDoi.Text +"' where SDTKhachHang = '" + textBoxSDTThayDoi.Text + "'";
                                OleDbCommand cmd = new OleDbCommand(query, connection);
                                cmd.ExecuteNonQuery();
                                connection.Close();

                                pictureBoxCheckCapNhat.Visible = true;
                                timerCheckCapNhat.Start();
                            }
                        }

                        //nếu sdt khách mới trùng với các sdt khách hàng loại khachquen
                        else
                        {
                            textBoxSDTThayDoi.BackColor = Color.Silver;
                            MessageBox.Show("SDT khách đã tồn tai, vui lòng nhập l !!!", "Thông báo");
                        }
                    }

                    //nếu thông tin mới khác sdt và khác tên khách hàng
                    else if (textBoxSDTThayDoi.Text != textBoxSDTHienTai.Text && textBoxTenKhachThayDoi.Text != textBoxTenHienTai.Text)
                    {
                        //nếu sdt khách mới không trùng với sdt khách hàng loại khachquen
                        if (KiemTraSDT_KhachQuen(textBoxSDTThayDoi) == 0)
                        {
                            //nếu sdt mới không trùng với các sdt khách hàng loại khachvanglai
                            if (KiemTraSDT_KhachVangLai(textBoxSDTThayDoi) == 0)
                            {
                                //nếu tên mới không trùng tên khách hàng với loại khachquen
                                if (KiemTraTen_KhachQuen(textBoxTenKhachThayDoi) == 0)
                                {
                                    connection.Open();
                                    string query = "update KhachHang set SDTKhachHang = '" + textBoxSDTThayDoi.Text + "', HoTenKhachHang = '" + textBoxTenKhachThayDoi.Text + "', DiaChiKhachHang = '" + textBoxDiaChiThayDoi.Text + "' where SDTKhachHang = '" + textBoxSDTHienTai.Text + "'";
                                    OleDbCommand cmd = new OleDbCommand(query, connection);
                                    cmd.ExecuteNonQuery();
                                    connection.Close();

                                    pictureBoxCheckCapNhat.Visible = true;
                                    timerCheckCapNhat.Start();
                                }

                                //nếu tên mới trùng với tên khách hàng với loại khachquen
                                else
                                {
                                    MessageBox.Show("Tên khách hàng đã tồn tại, vui lòng nhập lại !!!", "Thông báo");
                                }
                            }

                            //nếu sdt mới trùng với các sdt khách hàng loại khachvanglai
                            else
                            {
                                //nếu tên khách mới không trùng với tên khách hàng loại khachquen
                                if (KiemTraTen_KhachQuen(textBoxTenKhachThayDoi) == 0)
                                {
                                    connection.Open();
                                    //ẩn khách hàng hiện tại
                                    string queryAnKhach = "update KhachHang set LoaiKhachHang = 'khachvanglai' where SDTKhachHang = '" + textBoxSDTHienTai.Text + "'";
                                    OleDbCommand cmdAnKhach = new OleDbCommand(queryAnKhach, connection);
                                    cmdAnKhach.ExecuteNonQuery();
                                    
                                    //hiện khách hàng vừa cập nhật
                                    string query = "update KhachHang set LoaiKhachHang = 'khachquen', HoTenKhachHang = '" + textBoxTenKhachThayDoi.Text + "', DiaChiKhachHang = '" + textBoxDiaChiThayDoi.Text + "' where SDTKhachHang = '" + textBoxSDTThayDoi.Text + "'";
                                    OleDbCommand cmd = new OleDbCommand(query, connection);
                                    cmd.ExecuteNonQuery();
                                    connection.Close();

                                    pictureBoxCheckCapNhat.Visible = true;
                                    timerCheckCapNhat.Start();
                                }

                                //nếu tên khách mới trùng với tên khách hàng loại khachquen
                                else
                                {
                                    textBoxTenKhachThayDoi.BackColor = Color.Silver;
                                    MessageBox.Show("Tên khách đã tồn tại, vui lòng nhập lại !!!", "Thông báo");
                                }
                            }
                        }

                        //nếu sdt khách mới trùng với sdt khách hàng loại khachquen
                        else
                        {
                            textBoxSDTThayDoi.BackColor = Color.Silver;
                            MessageBox.Show("SDT khách đã tồn tại, vui lòng nhập lại !!!", "Thông báo");
                        }
                    }
                }
            }
            //nếu chưa nhập đủ thông tin cập nhật
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin khách mới !!!","Thông báo");
            }
        }

        public int TC_CheckCapNhat = 0;
        //HÀM HIỂN THỊ CẬP NHẬT THÀNH CÔNG VÀ CẬP NHẬT THÔNG TIN KHÁCH HÀNG THAY ĐỔI VÀO TEXTBOX
        private void timerCheckCapNhat_Tick(object sender, EventArgs e)
        {
            TC_CheckCapNhat++;
            if (TC_CheckCapNhat == 1)
            {
                timerCheckCapNhat.Stop();
                pictureBoxCheckCapNhat.Visible = false;
                timerCheckCapNhat.Enabled = false;
                TC_CheckCapNhat = 0;
            }
            textBoxSDTHienTai.Text = textBoxSDTThayDoi.Text;
            textBoxTenHienTai.Text = textBoxTenKhachThayDoi.Text;
            textBoxDiaChiHienTai.Text = textBoxDiaChiThayDoi.Text;
        }





        //----------CẬP NHẬT THÔNG TIN MỚI CỦA KHÁCH HÀNG----------
        //HÀM THÊM MỚI KHÁCH HÀNG
        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            textBoxSDTMoi.BackColor = Color.White;
            textBoxTenMoi.BackColor = Color.White;
            //nếu người dùng nhập đầy đủ thông tin
            if (textBoxSDTMoi.Text != "" && textBoxTenMoi.Text != "")
            {
                //nếu sdt khách hàng mới chưa có trong danh sách khách hàng loại khachvanglai
                if (KiemTraSDT_KhachVangLai(textBoxSDTMoi) == 0)
                {
                    //nếu sdt khách hàng mới chưa có trong danh sách khách hàng loại khachquen
                    if (KiemTraSDT_KhachQuen(textBoxSDTMoi) == 0)
                    {
                        //nếu tên khách hàng mới chưa có trong danh sách khách hàng khachquen
                        if (KiemTraTen_KhachQuen(textBoxTenMoi) == 0)
                        {
                            connection.Open();
                            string query = "insert into KhachHang (SDTKhachHang, HoTenKhachHang, DiaChiKhachHang, LoaiKhachHang) values ('"+ textBoxSDTMoi .Text+ "', '"+ textBoxTenMoi .Text+ "', '"+textBoxDiaChiMoi.Text+"', 'khachquen')";
                            OleDbCommand cmd = new OleDbCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            pictureBoxCheckThemMoi.Visible = true;
                            timerCheckThemMoi.Start();
                        }

                        //nếu tên khách hàng mới tồn tại trong danh sách khách hàng khachquen
                        else
                        {
                            textBoxTenMoi.BackColor = Color.Silver;
                            MessageBox.Show("Tên khách đã tồn tại , vui lòng nhập lại !!!", "Thông báo");
                        }
                    }

                    //nếu sdt khách hàng mới đã tồn tại trong danh sách khách hàng loại khachquen
                    else
                    {
                        textBoxSDTMoi.BackColor = Color.Silver;
                        MessageBox.Show("SDT khách đã tồn tại , vui lòng nhập lại !!!", "Thông báo");
                    }
                }

                // nếu sdt khách hàng mới đã tồn tại trong danh sách khách hàng loại khachvanglai
                else
                {
                    //nếu tên khách hàng mới chưa có trong danh sách khách hàng khachquen
                    if (KiemTraTen_KhachQuen(textBoxTenMoi) == 0)
                    {
                        //chuyển khách hàng từ khachvanglai thành khachquen
                        connection.Open();
                        string query = "update KhachHang set LoaiKhachHang = 'khachquen', HoTenKhachHang = '" + textBoxTenMoi.Text + "', DiaChiKhachHang = '" + textBoxDiaChiMoi.Text + "' where SDTKhachHang = '" + textBoxSDTMoi.Text + "'";
                        OleDbCommand cmd = new OleDbCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        pictureBoxCheckThemMoi.Visible = true;
                        timerCheckThemMoi.Start();
                    }

                    //nếu tên khách hàng mới tồn tại trong danh sách khách hàng khachquen
                    else
                    {
                        textBoxTenMoi.BackColor = Color.Silver;
                        MessageBox.Show("Tên khách đã tồn tại , vui lòng nhập lại !!!", "Thông báo");
                    }
                }
            }

            //nếu người dùng nhập chưa đủ thông tin
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !!!", "Thông báo");
            }
        }

        public int TC_CheckThemMoi = 0;
        //HÀM HIỂN THỊ CẬP NHẬT THÀNH CÔNG VÀ CẬP NHẬT THÔNG TIN KHÁCH HÀNG THAY ĐỔI VÀO TEXTBOX
        private void timerCheckThemMoi_Tick(object sender, EventArgs e)
        {
            TC_CheckThemMoi++;
            if (TC_CheckThemMoi == 1)
            {
                timerCheckThemMoi.Stop();
                pictureBoxCheckThemMoi.Visible = false;
                timerCheckThemMoi.Enabled = false;
                TC_CheckThemMoi = 0;
            }

            textBoxSDTMoi.Text = "";
            textBoxTenMoi.Text = "";
            textBoxDiaChiMoi.Text = "";
        }
    }
}
