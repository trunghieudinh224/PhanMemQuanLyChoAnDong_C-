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
    public partial class formNhapHang : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();
        public DataTable dtChiTietHangNhap = new DataTable();
        public static string PhieuNhapDuocChon;

        public formNhapHang()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            MacDinh();

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




        //HÀM HIỂN THỊ MẶC ĐỊNH KHI VỪA MỞ FORM
        void MacDinh()
        {
            buttonNhapHang.Text = "Nhập" + Environment.NewLine + "hàng";
            buttonDanhSachPhieuNhap.Text = "Danh" + Environment.NewLine + "sách" + Environment.NewLine + "phiếu" + Environment.NewLine + "nhập";
            buttonNhapHang.BackColor = Color.SaddleBrown;
            buttonDanhSachPhieuNhap.BackColor = Color.SandyBrown;
            buttonDanhSachPhieuNhap.ForeColor = Color.Gray;
            panelDanhSachPhieuNhap.Visible = false;

            HienThiNCC();
            HienThiNVNhanHang();
            HienThiNVLapPhieu();
            HienThiSP();
            HienThiDanhMucSP();
        }

        //----------MỤC NHẬP HÀNG----------
        //HÀM REFRESH THÔNG TIN
        void RF()
        {
            dtChiTietHangNhap.Rows.Clear();
            dataGridViewThongTinSPNhap.Rows.Clear();
            dateTimePickerNgayNhap.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            textBoxMaPhieu.Text = "";
            textBoxTongPhieu.Text = "";
            textBoxMaNCC.Text = "";
            textBoxDiaChiNCC.Text = "";
            textBoxSDTNCC.Text = "";
            comboBoxNhanVienLapPhieu.SelectedIndex = 0;
            comboBoxNCC.SelectedIndex = 0;
            comboBoxNVNhanHang.SelectedIndex = 0;
        }

        //HÀM KHI CLICK VÀO NÚT NHẬP HÀNG
        private void buttonNhapHang_Click(object sender, EventArgs e)
        {
            buttonNhapHang.BackColor = Color.SaddleBrown;
            buttonNhapHang.ForeColor = Color.Black;
            buttonDanhSachPhieuNhap.BackColor = Color.SandyBrown;
            buttonDanhSachPhieuNhap.ForeColor = Color.Gray;
            panelDanhSachPhieuNhap.Visible = false;
            panelNhapHang.Visible = true;
            HienThiNCC();
            HienThiNVNhanHang();
            HienThiNVLapPhieu();
            HienThiSP();
            HienThiDanhMucSP();
        }

        //HÀM HIỂN THỊ NCC 
        void HienThiNCC()
        {
            connection.Open();
            string query = "select  TenNCC from NCC where TrangThai = 'On'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TenNCC", typeof(string));
            dt.Rows.Add("Tên nhà cung cấp");
            dt.Load(reader);

            comboBoxNCC.ValueMember = "TenNCC";
            comboBoxNCC.DisplayMember = "TenNCC";
            comboBoxNCC.DataSource = dt;
            connection.Close();
        }

        //HÀM HIỂN THỊ THÔNG TIN NHÀ CUNG CẤP KHI NGƯỜI DÙNG CHỌN TRONG comboBoxNCC
        private void comboBoxNCC_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxNCC.SelectedIndex == 0)
            {
                textBoxSDTNCC.Text = "";
                textBoxMaNCC.Text = "";
                textBoxDiaChiNCC.Text = "";
            }
            else
            {
                connection.Open();
                string queryTTNCC = "select MaNCC, DiaChiNCC, SDTNCC from NCC where TenNCC = '" + comboBoxNCC.GetItemText(this.comboBoxNCC.SelectedItem) + "'";
                da = new OleDbDataAdapter(queryTTNCC, connection);
                DataTable dtTTNCC = new DataTable();
                da.Fill(dtTTNCC);
                connection.Close();

                textBoxMaNCC.Text = dtTTNCC.Rows[0].ItemArray[0].ToString();
                textBoxDiaChiNCC.Text = dtTTNCC.Rows[0].ItemArray[1].ToString();
                textBoxSDTNCC.Text = dtTTNCC.Rows[0].ItemArray[2].ToString();
            }
        }

        //HÀM HIỂN THỊ NHÂN VIÊN NHẬN HÀNG
        void HienThiNVNhanHang()
        {
            connection.Open();
            string query = "select  Username from TaiKhoan";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Username", typeof(string));
            dt.Rows.Add("--");
            dt.Load(reader);

            comboBoxNVNhanHang.ValueMember = "Username";
            comboBoxNVNhanHang.DisplayMember = "Username";
            comboBoxNVNhanHang.DataSource = dt;
            connection.Close();
        }

        //HÀM HIỂN THỊ NHÂN VIÊN LẬP PHIẾU
        void HienThiNVLapPhieu()
        {
            connection.Open();
            string query = "select  Username from TaiKhoan";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Username", typeof(string));
            dt.Rows.Add("--");
            dt.Load(reader);

            comboBoxNhanVienLapPhieu.ValueMember = "Username";
            comboBoxNhanVienLapPhieu.DisplayMember = "Username";
            comboBoxNhanVienLapPhieu.DataSource = dt;
            connection.Close();
        }

        //HÀM HIỂN THỊ SẢN PHẨM TRONG BẢNG THÔNG TIN SẢN PHẨM
        void HienThiSP()
        {
            connection.Open();
            string query = "select distinct TenSP from SanPham where TrangThai = 'ban'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            ComboBox TenSP = new ComboBox();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TenSP.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            ((DataGridViewComboBoxColumn)dataGridViewThongTinSPNhap.Columns["ColumnTenSP"]).DataSource = TenSP.Items;
        }

        //HÀM HIỂN THỊ DANH MỤC TRONG BẢNG THÔNG TIN SẢN PHẨM
        void HienThiDanhMucSP()
        {
            connection.Open();
            string query = "select distinct DanhMuc from DanhMuc";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            ComboBox DanhMucSP = new ComboBox();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DanhMucSP.Items.Add(dt.Rows[i].ItemArray[0].ToString()); 
            }
            ((DataGridViewComboBoxColumn)dataGridViewThongTinSPNhap.Columns["ColumnDanhMuc"]).DataSource = DanhMucSP.Items;
        }
      
        //HÀM LƯU THÔNG TIN PHIẾU NHẬP
        private void buttonLuuPhieu_Click(object sender, EventArgs e)
        {
            int CheckRong = 0;
            //nếu người dùng đã nhập đầy đủ thông tin
            if (textBoxMaPhieu.Text != "" && textBoxTongPhieu.Text != "" && comboBoxNCC.SelectedIndex != 0 && comboBoxNVNhanHang.SelectedIndex != 0 && comboBoxNhanVienLapPhieu.SelectedIndex != 0)
            {
                //kiểm tra mã phiếu có tồn tại trong hệ thống hay không
                connection.Open();
                string queryCheckMaPhieu = "select count(MaPhieu) from HangNhap where MaPhieu = '" + textBoxMaPhieu.Text + "'";
                OleDbCommand cmdCheckMaPhieu = new OleDbCommand(queryCheckMaPhieu, connection);
                int checkMaPhieu = Convert.ToInt32(cmdCheckMaPhieu.ExecuteScalar().ToString());
                connection.Close();

                //nếu mã phiếu chưa tồn tại
                if (checkMaPhieu == 0)
                {
                    //nếu trong bảng thông tin sản phẩm đã có ít nhất 1 sản phẩm
                    if (dataGridViewThongTinSPNhap.Rows.Count > 1)
                    {
                        //kiểm tra xem người dùng có nhập sót thông tin của ô nào trong bảng dataGridViewThongTinSPNhap không
                        for (int i = 0; i < dataGridViewThongTinSPNhap.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridViewThongTinSPNhap.Columns.Count; j++)
                            {
                                if (dataGridViewThongTinSPNhap.Rows[i].Cells[j].Value == null)
                                {
                                    CheckRong++;
                                }
                            }
                        }

                        //nếu người dùng nhập sót
                        if (CheckRong > 0)
                        {
                            MessageBox.Show("Bạn chưa nhập đủ thông tin sản phẩm vào phiếu nhập !!!", "Thông báo");
                        }

                        //nếu người dùng nhập đủ thông tin
                        else
                        {
                            //kiểm tra tổng tiền phiếu nhập với tổng giá trị các sản phẩm có bằng nhau không
                            int tongTienBangPhieuNhap = 0;
                            for (int i = 0; i < dataGridViewThongTinSPNhap.Rows.Count - 1; i++)
                            {
                                tongTienBangPhieuNhap = tongTienBangPhieuNhap + Convert.ToInt32(dataGridViewThongTinSPNhap.Rows[i].Cells[3].Value.ToString());
                            }
                            
                            //nếu tổng tiền phiếu nhập bằng tổng giá trị các sản phẩm
                            if (textBoxTongPhieu.Text == tongTienBangPhieuNhap.ToString())
                            {
                                //lưu thông tin phiếu nhập
                                connection.Open();                              
                                string queryHangNhap = "insert into HangNhap (MaPhieu,NgayNhap,TongPhieu,NCC,MaNCC,DiaChiNCC,SDTNCC,NVNhanHang,NVLapPhieu) values ('" + textBoxMaPhieu.Text + "', '" + dateTimePickerNgayNhap.Value.ToString("dd/MM/yyyy") + "', '" + textBoxTongPhieu.Text + "', '" + comboBoxNCC.GetItemText(this.comboBoxNCC.SelectedItem) + "', '" + textBoxMaNCC.Text + "', '" + textBoxDiaChiNCC.Text + "', '" + textBoxSDTNCC.Text + "', '" + comboBoxNVNhanHang.GetItemText(this.comboBoxNVNhanHang.SelectedItem) + "', '" + comboBoxNhanVienLapPhieu.GetItemText(this.comboBoxNhanVienLapPhieu.SelectedItem) + "')";
                                OleDbCommand cmdHangNhap = new OleDbCommand(queryHangNhap, connection);
                                cmdHangNhap.ExecuteNonQuery();

                                for (int i = 0; i < dataGridViewThongTinSPNhap.Rows.Count - 1; i++)
                                {
                                    //lưu thông tin chỉ tiết phiếu nhập
                                    string queryChiTietHangNhap = "insert into ChiTietHangNhap (MaPhieu, TenSP, SoLuong, DanhMuc, GiaNhap) values ('" + textBoxMaPhieu.Text + "', '" + dataGridViewThongTinSPNhap.Rows[i].Cells[0].Value.ToString() + "', '" + dataGridViewThongTinSPNhap.Rows[i].Cells[1].Value.ToString() + "', '" + dataGridViewThongTinSPNhap.Rows[i].Cells[2].Value.ToString() + "', '" + dataGridViewThongTinSPNhap.Rows[i].Cells[3].Value.ToString() + "')";
                                    OleDbCommand cmdChiTietHangNhap = new OleDbCommand(queryChiTietHangNhap, connection);
                                    cmdChiTietHangNhap.ExecuteNonQuery();

                                    //lấy số lượng tồn hiện tại của từng sản phẩm nhập
                                    int SoLuongTonMoi = 0;
                                    string queryLayThongTinSoLuongTon = "select SoLuongTon from SanPham where TenSP = '" + dataGridViewThongTinSPNhap.Rows[i].Cells[0].Value.ToString() + "'";
                                    OleDbCommand cmdLayThongTinSoLuongTon = new OleDbCommand(queryLayThongTinSoLuongTon, connection);
                                    SoLuongTonMoi = Convert.ToInt32(cmdLayThongTinSoLuongTon.ExecuteScalar()) + Convert.ToInt32(dataGridViewThongTinSPNhap.Rows[i].Cells[1].Value.ToString());

                                    //cập nhật số lượng tồn mới cho các sản phẩm nhập
                                    string queryCapNhatSoLuongTon = "update SanPham set SoLuongTon = " + SoLuongTonMoi + " where TenSP = '" + dataGridViewThongTinSPNhap.Rows[i].Cells[0].Value.ToString() + "'";
                                    OleDbCommand cmdCapNhatSoLuongTon = new OleDbCommand(queryCapNhatSoLuongTon, connection);
                                    cmdCapNhatSoLuongTon.ExecuteNonQuery();
                                }

                                connection.Close();

                                pictureBoxCheckNH.Visible = true;
                                timerTC.Start();
                                RF();
                            }

                            //nếu tổng tiền phiếu nhập không bằng tổng giá trị các sản phẩm
                            else
                            {
                                MessageBox.Show("Vui lòng xem lại tổng phiếu, tổng phiếu không khớp với tổng giá trị sản phẩm vừa nhập !!!", "Thông báo");
                            }
                        }
                    }

                    //nếu người dùng nhập đầy đủ thông tin các sản phẩm
                    else
                    {
                        MessageBox.Show("Bạn chưa nhập sản phẩm nào vào phiếu nhập !!!", "Thông báo");
                    }
                }

                //nếu mã phiếu đã tồn tại trong hệ thống
                else
                {
                    MessageBox.Show("Mã phiếu đã tồn tại vui lòng nhập lại !!!", "Thông báo");
                }
            }

            //nếu chưa nhập đủ thông tin của phiếu nhập
            else
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin phiếu nhập !!!", "Thông báo");
            }
        }

        //HÀM TÌM PHIẾU NHẬP THEO MÃ PHIẾU
        private void buttonTimPhieu_Click(object sender, EventArgs e)
        {
            if (textBoxTimPhieu.Text != "")
            {
                connection.Open();
                string queryCheckMaPhieu = "select count(MaPhieu) from HangNhap where MaPhieu = '"+textBoxTimPhieu.Text+"'";
                OleDbCommand cmdCheckMaPhieu = new OleDbCommand(queryCheckMaPhieu, connection);
                int CheckMaPhieu = Convert.ToInt32(cmdCheckMaPhieu.ExecuteScalar());
                connection.Close();

                if (CheckMaPhieu > 0)
                {
                    labelCheck.Visible = false;
                    textBoxTimPhieu.BackColor = Color.White;
                    connection.Open();
                    string query = "select * from HangNhap where MaPhieu = '" + textBoxTimPhieu.Text + "'";
                    da = new OleDbDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    connection.Close();

                    dtChiTietHangNhap.Rows.Clear();
                    textBoxMaPhieu.Text = dt.Rows[0].ItemArray[0].ToString();
                    dateTimePickerNgayNhap.Value = Convert.ToDateTime(dt.Rows[0].ItemArray[1].ToString());
                    textBoxTongPhieu.Text = dt.Rows[0].ItemArray[2].ToString();
                    for (int i = 0; i < comboBoxNCC.Items.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[3].ToString() == comboBoxNCC.GetItemText(comboBoxNCC.Items[i]).ToString())
                        {
                            comboBoxNCC.SelectedIndex = i;
                        }
                    }
                    for (int i = 0; i < comboBoxNVNhanHang.Items.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[7].ToString() == comboBoxNVNhanHang.GetItemText(comboBoxNVNhanHang.Items[i]).ToString())
                        {
                            comboBoxNVNhanHang.SelectedIndex = i;
                        }
                    }
                    for (int i = 0; i < comboBoxNhanVienLapPhieu.Items.Count; i++)
                    {
                        if (dt.Rows[0].ItemArray[8].ToString() == comboBoxNhanVienLapPhieu.GetItemText(comboBoxNhanVienLapPhieu.Items[i]).ToString())
                        {
                            comboBoxNhanVienLapPhieu.SelectedIndex = i;
                        }
                    }

                    connection.Open();
                    string queryChiTietHangNhap = "select TenSP,SoLuong, DanhMuc, GiaNhap from ChiTietHangNhap where MaPhieu = '" + textBoxTimPhieu.Text + "'";
                    da = new OleDbDataAdapter(queryChiTietHangNhap, connection);
                    da.Fill(dtChiTietHangNhap);
                    connection.Close();
                    dataGridViewThongTinSPNhap.Columns[0].DataPropertyName = "TenSP";
                    dataGridViewThongTinSPNhap.Columns[1].DataPropertyName = "SoLuong";
                    dataGridViewThongTinSPNhap.Columns[2].DataPropertyName = "DanhMuc";
                    dataGridViewThongTinSPNhap.Columns[3].DataPropertyName = "GiaNhap";
                    dataGridViewThongTinSPNhap.DataSource = dtChiTietHangNhap;
                }
                else
                {
                    textBoxTimPhieu.BackColor = Color.LightGray;
                    labelCheck.Visible = true;
                }
            }
            else
            {
                dtChiTietHangNhap.Rows.Clear();
                dateTimePickerNgayNhap.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                textBoxMaPhieu.Text = "";
                textBoxTongPhieu.Text = "";
                textBoxMaNCC.Text = "";
                textBoxDiaChiNCC.Text = "";
                textBoxSDTNCC.Text = "";
                comboBoxNhanVienLapPhieu.SelectedIndex = 0;
                comboBoxNCC.SelectedIndex = 0;
                comboBoxNVNhanHang.SelectedIndex = 0;
            }
        }

        public int TC = 0;
        //HÀM HIỂN THỊ LƯU THÔNG TIN PHIẾU NHẬP THÀNH CÔNG
        private void timerTC_Tick(object sender, EventArgs e)
        {
            TC++;
            if (TC == 1)
            {
                timerTC.Stop();
                pictureBoxCheckNH.Visible = false;
                timerTC.Enabled = false;
                TC = 0;
            }
        }





        //----------MỤC DANH SÁCH PHIẾU NHẬP----------
        //HÀM KHI CLICK VÀO NÚT DANH SÁCH PHIẾU NHẬP
        private void buttonDanhSachPhieuNhap_Click(object sender, EventArgs e)
        {
            buttonNhapHang.BackColor = Color.SandyBrown;
            buttonNhapHang.ForeColor = Color.Gray;
            buttonDanhSachPhieuNhap.BackColor = Color.SaddleBrown;
            buttonDanhSachPhieuNhap.ForeColor = Color.Black;
            panelDanhSachPhieuNhap.Visible = true;
            panelNhapHang.Visible = false;
            

            DanhSachPhieuNhap();
            if (dataGridViewDSPN.Rows.Count > 0)
            {
                PhieuNhapDuocChon = dataGridViewDSPN.Rows[0].Cells[1].Value.ToString();
            }
            
        }

        //HÀM HIỂN THỊ DANH SÁCH PHIẾU NHẬP
        void DanhSachPhieuNhap()
        {
            connection.Open();
            string query = "select NgayNhap, MaPhieu, NCC, TongPhieu from HangNhap";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSPN.DataSource = dt;
            connection.Close();
        }

        //HÀM TÌM PHIẾU NHẬP
        private void textBoxTimPhieuNhap_DSPN_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            string query = "select NgayNhap,MaPhieu,NCC,TongPhieu from HangNhap where MaPhieu like ('%" + textBoxTimPhieuNhap_DSPN.Text + "%') or NCC like ('%" + textBoxTimPhieuNhap_DSPN.Text + "%') or TongPhieu like ('%" + textBoxTimPhieuNhap_DSPN.Text + "%')";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSPN.DataSource = dt;
            connection.Close();
        }

        //HÀM LẤY THÔNG TIN CỦA 1 PHIẾU NHẬP KHI DOUBLE CLICK VÀO PHIẾU NHẬP
        private void dataGridViewDSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewDSPN.CurrentCell.RowIndex;

            if (row >= 0)
            {
                PhieuNhapDuocChon = dataGridViewDSPN.Rows[row].Cells[1].Value.ToString();
            }
        }

        //HÀM XÓA PHIẾU NHẬP
        private void buttonXoaPhieu_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn thật sự muốn xóa phiếu ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.OK)
            {
                connection.Open();
                string queryHN = "delete from HangNhap where MaPhieu = '" + PhieuNhapDuocChon + "'";
                OleDbCommand cmdHN = new OleDbCommand(queryHN, connection);
                cmdHN.ExecuteNonQuery();
                connection.Close();

                DanhSachPhieuNhap();
            }
        }

        //HÀM HIỂN THỊ CHI TIẾT PHIẾU NHẬP
        private void buttonXemPhieu_Click(object sender, EventArgs e)
        {
            formChiTietPhieuNhap f = new formChiTietPhieuNhap();
            f.ShowDialog();
        }

        //HÀM KHI NHẤN VÀO NÚT THÊM NHÀ CUNG CẤP
        private void buttonThemNCC_Click(object sender, EventArgs e)
        {
            formDanhMucNCC f = new formDanhMucNCC();
            f.ShowDialog();
            HienThiNCC();
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxMaPhieu
        private void textBoxMaPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTongPhieu
        private void textBoxTongPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTimPhieu
        private void textBoxTimPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTimPhieuNhap_DSPN
        private void textBoxTimPhieuNhap_DSPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
