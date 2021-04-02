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
    public partial class formBanHang : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public string Quyen;
        public int TongTien = 0;
        public static int TongToaHang;
        public static string SLSanPham;
        public static int KhachNo;
        public static string ThanhToan;       
        public static int kettoa;
        public static string giamgia;
        public static int Toa_KhachThieu = 0;
        public static string Toa_ThieuKhach_KhachThieu;

        //HÀM LOAD FORM
        public formBanHang()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienThiUsername();

            PQ();

            TenSap();
            
            HienSanPhamMacDinh();

            HienDanhMuc();

            cbbKhachHang();

            dtbMuaHang();

            dtbTraHang();
        }

        private void timerGio_Tick(object sender, EventArgs e)
        {
            labelThoiGian.Text ="Ngày làm việc: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"); ;
        }

        //HÀM KHI CLICK VÀO NÚT ẨN
        private void buttonAn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Icon.Dispose();
        }

        //HÀM KHI RÊ CHUỘT VÀO NÚT ẨN
        private void buttonAn_MouseHover(object sender, EventArgs e)
        {
            buttonAn.BackColor = Color.RoyalBlue;
        }

        //HÀM KHI RÊ CHUỘT KHỎI NÚT ẨN
        private void buttonAn_MouseLeave(object sender, EventArgs e)
        {
            buttonAn.BackColor = Color.CornflowerBlue;
        }

        //HÀM KHI CLICK VÀO NÚT ĐĂNG XUẤT
        private void buttonDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn đăng xuất khỏi phần mềm ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.OK)
            {
                if (listViewMuaHang.Items.Count > 0)
                {
                    string sp;
                    for (int i = 0; i < listViewMuaHang.Items.Count; i++)
                    {
                        sp = listViewMuaHang.Items[i].SubItems[0].Text;
                        CapNhatSauKhiXoaSP(sp, listViewMuaHang);
                    }
                }

                if (listViewTraHang.Items.Count > 0)
                {
                    string sp;
                    for (int i = 0; i < listViewTraHang.Items.Count; i++)
                    {
                        sp = listViewTraHang.Items[i].SubItems[0].Text;
                        CapNhatSauKhiXoaSP(sp, listViewTraHang);
                    }
                }

                formXacNhanToa.dt.Columns.Clear();
                formXacNhanToa.dttra.Columns.Clear();
                this.Close();
            }
        }

        //HÀM KHI RÊ CHUỘT VÀO NÚT ĐĂNG XUẤT
        private void buttonDangXuat_MouseHover(object sender, EventArgs e)
        {
            buttonX.BackColor = Color.Red;
        }

        //HÀM KHI RÊ CHUỘT KHỎI NÚT ĐĂNG XUẤT
        private void buttonDangXuat_MouseLeave(object sender, EventArgs e)
        {
            buttonX.BackColor = Color.CornflowerBlue;
        }






        //----------CÁC HÀM HIỂN THỊ MẶC ĐỊNH----------
        //HÀM HIỂN THỊ TÊN HIỂN THỊ CỦA USER
        void HienThiUsername()
        {
            connection.Open();
            string query = "select TenHienThi from TaiKhoan where Username = '" + formDangNhap.username + "'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            string TenHienThi = cmd.ExecuteScalar().ToString();
            TaiKhoanNVToolStripMenuItem.Text = TenHienThi;
            connection.Close();
        }

        //HÀM TIMER TÊN SẠP
        void TenSap()
        {
            timerTenSap.Start();
        }

        //HÀM THỰC HIỆN HIỆU ỨNG CHO TÊN SẠP
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
        
        //HÀM REFESH CÁC THÔNG TIN TRONG FORM
        void Refresh()
        {
            listViewMuaHang.Items.Clear();
            listViewTraHang.Items.Clear();
            comboBoxKhachHang.SelectedIndex = 0;
            labelTongSL1_Cost.Text = "";
            labelTongSL2_Cost.Text = "";
            labelMuaTraTienMat_Cost.Text = "0 - 0";
            labelMuaTraCredit_Cost.Text = "0 - 0";
            textBoxGiamGiaTienMat.Text = "0";
            textBoxGiamGiaCredit.Text = "0";
            textBoxTienChuyenKhoan.Text = "0";
            textBoxTienMatKhachTra.Text = "0";
            labelTienThua_Cost.Text = "0";
            labelTongTienMat_Cost.Text = "0";
            labelTongTienCredit_Cost.Text = "0";
            labelKhachThieuTienMat_Cost.Text = "0";
            labelKhachThieuCredit_Cost.Text = "0";

            textBoxDiaChiKhachVangLai.Text = "";
            textBoxTenKhachVangLai.Text = "";
            textBoxSDTKhachVangLai.Text = "";
        }

        //HÀM HIỂN THỊ SẢN PHẨM LÊN DATAGRIDVIEW dataGridViewSanPham
        void HienSanPhamMacDinh()
        {
            connection.Open();
            string query = "select TenSP ,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai='ban' order by TenSP";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSanPham.DataSource = dt;


            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            connection.Close();
            dataGridViewSanPham.Columns[0].Width = 180;
            dataGridViewSanPham.Columns[1].Width = 100;
        }

        //HÀM HIỂN THỊ DANH MỤC SẢN PHẨM LÊN comboBoxDanhMucSanPham
        void HienDanhMuc()
        {
            connection.Open();
            string query = "select distinct DanhMuc from SanPham";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DanhMuc", typeof(string));
            dt.Rows.Add("Tất cả");
            dt.Load(reader);

            comboBoxDanhMucSanPham.ValueMember = "DanhMuc";
            comboBoxDanhMucSanPham.DisplayMember = "DanhMuc";
            comboBoxDanhMucSanPham.DataSource = dt;

            checkBoxMuaHang.Checked = true;
            connection.Close();
        }
       





        //----------CÁC HÀM CHỨC NĂNG MUA HOẶC TRẢ HÀNG-----------
        //HÀM TÌM KIẾM SẢN PHẨM THEO DANH MỤC
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sptim = textBoxTimKiem.Text;
            connection.Open();

            if (comboBoxDanhMucSanPham.SelectedIndex != 0)
            {
                string query = "select TenSP,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai = 'ban' and (TenSP like ('%" + sptim + "%') or GiaBan like ('%" + sptim + "%')) and DanhMuc='" + comboBoxDanhMucSanPham.GetItemText(this.comboBoxDanhMucSanPham.SelectedItem) + "' order by TenSP";
                da = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewSanPham.DataSource = dt;
            }
            if (comboBoxDanhMucSanPham.SelectedIndex == 0)
            {
                string query = "select TenSP,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai = 'ban' and (TenSP like ('%" + sptim + "%') or GiaBan like ('%" + sptim + "%')) order by TenSP";
                da = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewSanPham.DataSource = dt;
            }

            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            connection.Close();
        }

        //HÀM CHECK DỮ LIỆU NHẬP (CHỈ CHO PHÉP NHẬP SỐ VÀ CHỮ CÁI) VÀO textBoxTimKiem 
        private void textBoxTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM LOAD DỮ LIỆU SẢN PHẨM KHI NGƯỜI DÙNG CHỌN DỮ LIỆU TRONG comboBoxDanhMucSanPham
        private void comboBoxDanhMucSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            string danhmuc = this.comboBoxDanhMucSanPham.GetItemText(this.comboBoxDanhMucSanPham.SelectedItem);

            if (danhmuc == "Tất cả")
            {
                string queryAll = "select TenSP ,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai='ban' order by TenSP";
                da = new OleDbDataAdapter(queryAll, connection);
                DataTable dtAll = new DataTable();
                da.Fill(dtAll);
                dataGridViewSanPham.DataSource = dtAll;
            }
            else
            {
                string query = "select TenSP ,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai = 'ban' and DanhMuc = '" + danhmuc + "' order by TenSP";
                da = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewSanPham.DataSource = dt;
            }
            

            dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            connection.Close();
        }

        //HÀM LẤY LẤY DỮ LIỆU VÀ THÊM SẢN PHẨM VÀO BẢNG MUA HÀNG HOẶC TRẢ HÀNG
        private void dataGridViewSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewSanPham.CurrentCell.RowIndex;
            int cot = dataGridViewSanPham.CurrentCell.ColumnIndex;
            int montrung=-1;
            int slmontrung = 0;

            //nếu khách mua hàng
            if (checkBoxMuaHang.Checked == true)
            {
                //nếu đã có ít nhất 1 sản phẩm trong toa MUA
                if (Convert.ToInt32(listViewMuaHang.Items.Count.ToString()) > 0)    
                {
                    //kiểm tra sản phẩm vừa chọn đã tồn tại trong toa Mua chưa
                    for (int i = 0; i < Convert.ToInt32(listViewMuaHang.Items.Count.ToString()); i++)
                    {
                        if (listViewMuaHang.Items[i].SubItems[0].Text == dataGridViewSanPham.Rows[row].Cells[0].Value.ToString())
                        {
                            montrung = i;
                            slmontrung = Convert.ToInt32(listViewMuaHang.Items[i].SubItems[1].Text);                           
                        }
                    }

                    //nếu sản phẩm vừa chọn đã tồn tại trong toa Mua
                    if (montrung != -1)
                    {
                        //cập nhật sản phẩm vào toa Mua theo số lượng thêm của numericUpDownSL
                        if (numericUpDownSL.Value != 0)
                        {
                            int sl = 0;
                            sl = Convert.ToInt32(numericUpDownSL.Value) + slmontrung;
                            int thanhtien = sl * Convert.ToInt32(listViewMuaHang.Items[montrung].SubItems[2].Text);

                            //nếu số lượng tồn lớn hơn số lượng khách mua thêm thì cập nhật thông tin sản phẩm vào toa Mua
                            if ((Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value.ToString()) - Convert.ToInt32(numericUpDownSL.Value)) >= 0)
                            {
                                listViewMuaHang.Items[montrung].SubItems[1].Text = sl.ToString();
                                listViewMuaHang.Items[montrung].SubItems[3].Text = thanhtien.ToString();
                                CapNhatDuLieuSLMenu(row, Convert.ToInt32(numericUpDownSL.Value), dataGridViewSanPham.Rows[row].Cells[0].Value.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Số lượng tồn không đủ với yêu cầu mua", "Thông báo");
                            }
                     
                        }
                        //cập nhật sản phẩm vào toa Mua với số lượng thêm mặc định là 1
                        else
                        {
                            int sl = 0;
                            sl = 1 + slmontrung;
                            int thanhtien = sl * Convert.ToInt32(listViewMuaHang.Items[montrung].SubItems[2].Text);

                            //nếu số lượng tồn lớn hơn số lượng khách mua thêm thì cập nhật thông tin sản phẩm vào toa Mua
                            if ((Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value.ToString()) - 1) >= 0)
                            {
                                listViewMuaHang.Items[montrung].SubItems[1].Text = sl.ToString();
                                listViewMuaHang.Items[montrung].SubItems[3].Text = thanhtien.ToString();
                                CapNhatDuLieuSLMenu(row, 1, dataGridViewSanPham.Rows[row].Cells[0].Value.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Số lượng tồn không đủ với yêu cầu mua", "Thông báo");
                            }                            
                        }
                    }

                    //nếu sản phẩm vừa chọn không có trong toa Mua
                    else
                    {
                        //thêm sản phẩm vào toa Mua theo số lượng của numericUpDownSL
                        if (numericUpDownSL.Value > 0)
                        {
                            //nếu số lượng tồn lớn hơn số lượng khách mua thì thêm thông tin sản phẩm vào toa Mua
                            if (numericUpDownSL.Value <= Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value.ToString()))
                            {
                                string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                                int sl = Convert.ToInt32(numericUpDownSL.Value);
                                int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                                int thanhtien = dongia * sl;
                                string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                                var x = new ListViewItem(sp);
                                listViewMuaHang.Items.Add(x);
                                CapNhatDuLieuSLMenu(row, sl, tensp);
                            }
                            else
                            {
                                MessageBox.Show("Số lượng tồn không đủ với yêu cầu mua", "Thông báo");
                            }
                        }
                        //thêm sản phẩm vào toa Mua với số lượng mặc định là 1
                        else
                        {
                            //nếu số lượng tồn lớn hơn số lượng khách mua thì thêm thông tin sản phẩm vào toa Mua
                            if (Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value.ToString()) > 0)
                            {
                                string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                                int sl = 1;
                                int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                                int thanhtien = dongia * sl;
                                string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                                var x = new ListViewItem(sp);
                                listViewMuaHang.Items.Add(x);
                                CapNhatDuLieuSLMenu(row, sl, tensp);
                            }
                            else
                            {
                                MessageBox.Show("Số lượng tồn không đủ với yêu cầu mua", "Thông báo");
                            }
                        }
                    }
                }

                //nếu chưa có sản phẩm nào trong toa Mua
                if (Convert.ToInt32(listViewMuaHang.Items.Count.ToString()) == 0)  
                {
                    //thêm sản phẩm vào toa Mua theo số lượng của numericUpDownSL
                    if (numericUpDownSL.Value > 0)
                    {
                        //nếu số lượng tồn lớn hơn số lượng khách mua thì thêm thông tin sản phẩm vào toa Mua
                        if (numericUpDownSL.Value <= Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value.ToString()))
                        {
                            string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                            int sl = Convert.ToInt32(numericUpDownSL.Value);
                            int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                            int thanhtien = dongia * sl;
                            string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                            var x = new ListViewItem(sp);
                            listViewMuaHang.Items.Add(x);
                            CapNhatDuLieuSLMenu(row, sl, tensp);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng tồn không đủ với yêu cầu mua","Thông báo");
                        }
                    }
                    //thêm sản phẩm vào toa Mua với số lượng mặc định là 1
                    else
                    {
                        //nếu số lượng tồn lớn hơn số lượng khách mua thì thêm thông tin sản phẩm vào toa Mua
                        if (Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[3].Value.ToString()) > 0)
                        {
                            string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                            int sl = 1;
                            int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                            int thanhtien = dongia * sl;
                            string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                            var x = new ListViewItem(sp);
                            listViewMuaHang.Items.Add(x);

                            CapNhatDuLieuSLMenu(row, sl, tensp);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng tồn không đủ với yêu cầu mua", "Thông báo");
                        }
                    }
                }   
            }

            //nếu khách trả hàng
            else
            {
                //nếu trong toa Trả có ít nhất 1 sản phẩm
                if (Convert.ToInt32(listViewTraHang.Items.Count.ToString()) > 0)
                {
                    //kiểm tra sản phẩm vừa chọn đã tồn tại trong toa Trả chưa
                    for (int i = 0; i < Convert.ToInt32(listViewTraHang.Items.Count.ToString()); i++)
                    {
                        if (listViewTraHang.Items[i].SubItems[0].Text == dataGridViewSanPham.Rows[row].Cells[0].Value.ToString())
                        {
                            montrung = i;
                            slmontrung = Convert.ToInt32(listViewTraHang.Items[i].SubItems[1].Text);
                        }
                    }

                    //nếu sản phẩm vừa chọn đã tồn tại trong toa Trả
                    if (montrung != -1)
                    {
                        //cập nhật sản phẩm vào toa Trả theo số lượng thêm của numericUpDownSL
                        if (numericUpDownSL.Value > 0)
                        {
                            int sl = Convert.ToInt32(numericUpDownSL.Value) + slmontrung;
                            int thanhtien = sl * Convert.ToInt32(listViewTraHang.Items[montrung].SubItems[2].Text);
                            listViewTraHang.Items[montrung].SubItems[1].Text = sl.ToString();
                            listViewTraHang.Items[montrung].SubItems[3].Text = thanhtien.ToString();
                        }
                        //cập nhật sản phẩm vào toa Trả với số lượng thêm mặc định là 1
                        else
                        {
                            int sl = 1 + slmontrung;
                            int thanhtien = sl * Convert.ToInt32(listViewTraHang.Items[montrung].SubItems[2].Text);
                            listViewTraHang.Items[montrung].SubItems[1].Text = sl.ToString();
                            listViewTraHang.Items[montrung].SubItems[3].Text = thanhtien.ToString();
                        }
                    }
                    //nếu sản phẩm vừa chọn không có trong toa Trả
                    else
                    {
                        //thêm sản phẩm vào toa Trả theo số lượng thêm của numericUpDownSL
                        if (numericUpDownSL.Value > 0)
                        {
                            string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                            int sl = Convert.ToInt32(numericUpDownSL.Value);
                            int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                            int thanhtien = dongia * sl;
                            string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                            var x = new ListViewItem(sp);
                            listViewTraHang.Items.Add(x);
                        }
                        //thêm sản phẩm vào toa Trả với số lượng mặc định là 1
                        else
                        {
                            string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                            int sl = 1;
                            int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                            int thanhtien = dongia * sl;
                            string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                            var x = new ListViewItem(sp);
                            listViewTraHang.Items.Add(x);
                        }
                    }
                }

                //nếu chưa có sản phẩm nào trong toa Trả
                if (Convert.ToInt32(listViewTraHang.Items.Count.ToString()) == 0)
                {
                    //thêm sản phẩm vào toa Trả theo số lượng thêm của numericUpDownSL
                    if (numericUpDownSL.Value > 0)
                    {
                        string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                        int sl = Convert.ToInt32(numericUpDownSL.Value);
                        int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                        int thanhtien = dongia * sl;
                        string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                        var x = new ListViewItem(sp);
                        listViewTraHang.Items.Add(x);
                    }
                    //thêm sản phẩm vào toa Trả với số lượng mặc định là 1
                    else
                    {
                        string tensp = dataGridViewSanPham.Rows[row].Cells[0].Value.ToString();
                        int sl = 1;
                        int dongia = Convert.ToInt32(dataGridViewSanPham.Rows[row].Cells[2].Value.ToString());
                        int thanhtien = dongia * sl;
                        string[] sp = { tensp, sl.ToString(), dongia.ToString(), thanhtien.ToString() };
                        var x = new ListViewItem(sp);
                        listViewTraHang.Items.Add(x);
                    }
                }
            }

            textBoxTienMatKhachTra.Text = "0";
            textBoxTienChuyenKhoan.Text = "0";
            labelKhachThieuTienMat_Cost.Text = "0";
            labelKhachThieuCredit_Cost.Text = "0";
            labelTienThua_Cost.Text = "0";
            numericUpDownSL.Value = 0;
            HienThongTinThanhToan();
        }

        //HÀM CẬP NHẬT SỐ LƯỢNG CỦA SẢN PHẨM SAU KHI THÊM SẢN PHẨM VÀO TOA MUA
        void CapNhatDuLieuSLMenu(int vitridong, int sl, string tensp)
        {
            //số lượng ban đầu của sản phẩm thêm vào toa
            int slSauKhiClick = Convert.ToInt32(dataGridViewSanPham.Rows[vitridong].Cells[3].Value.ToString()) - sl;

            //cập nhật số lượng mới cho sản phẩm vừa thêm
            connection.Open();
            string queryCapNhat = "update SanPham set SoLuongTon = " + slSauKhiClick + " where TenSP = '" + tensp + "'";
            OleDbCommand cmdCapNhat = new OleDbCommand(queryCapNhat, connection);
            cmdCapNhat.ExecuteNonQuery();
            connection.Close();

            //tải lại menu với số lượng mới theo danh mục đang chọn
            if (this.comboBoxDanhMucSanPham.GetItemText(this.comboBoxDanhMucSanPham.SelectedItem) != "Tất cả")
            {
                connection.Open();
                string danhmuc = this.comboBoxDanhMucSanPham.GetItemText(this.comboBoxDanhMucSanPham.SelectedItem);
                string query = "select TenSP ,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai = 'ban' and DanhMuc = '" + danhmuc + "'";
                da = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataView dv = dt.DefaultView;
                dv.Sort = "DanhMuc";
                dv.Sort = "TenSp";
                dt = dv.ToTable();
                dataGridViewSanPham.DataSource = dt;
                dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                connection.Close();
            }
            //tải lại menu với danh mục "Tất cả"
            else
            {
                HienSanPhamMacDinh();
            }                  
            
        }

        //HÀM CHECK checkBoxMuaHang
        private void checkBoxMuaHang_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMuaHang.Checked == true)
            {
                checkBoxTraHang.Checked = false;
            }
        }

        //HÀM KHI CLICK VÀO checkBoxMuaHang
        private void checkBoxMuaHang_Click(object sender, EventArgs e)
        {
            if (checkBoxMuaHang.Checked == false)
            {
                checkBoxTraHang.Checked = true;
            }
        }

        //HÀM XÓA SẢN PHẨM KHỎI TOA MUA
        private void listViewMuaHang_DoubleClick(object sender, EventArgs e)
        {
            string sp = listViewMuaHang.SelectedItems[0].Text;
            CapNhatSauKhiXoaSP(sp, listViewMuaHang);
            listViewMuaHang.SelectedItems[0].Remove();
            HienThongTinThanhToan();
            textBoxTienMatKhachTra.Text = "0";
            textBoxTienChuyenKhoan.Text = "0";

            if (listViewMuaHang.Items.Count == 0)
            {
                Refresh();
            }
        }

        //HÀM CHECK checkBoxTraHang
        private void checkBoxTraHang_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTraHang.Checked == true)
            {
                checkBoxMuaHang.Checked = false;
            }
        }

        //HÀM KHI CLICK VÀO checkBoxTraHang
        private void checkBoxTraHang_Click(object sender, EventArgs e)
        {
            if (checkBoxTraHang.Checked == false)
            {
                checkBoxMuaHang.Checked = true;
            }
        }

        //HÀM XÓA SẢN PHẨM KHỎI TOA TRẢ
        private void listViewTraHang_DoubleClick(object sender, EventArgs e)
        {
            string sp = listViewTraHang.SelectedItems[0].Text;
            CapNhatSauKhiXoaSP(sp, listViewTraHang);
            listViewTraHang.SelectedItems[0].Remove();
            HienThongTinThanhToan();
            textBoxTienMatKhachTra.Text = "0";
            textBoxTienChuyenKhoan.Text = "0";

            if (listViewTraHang.Items.Count == 0)
            {
                Refresh();
            }
        }

        //HÀM CẬP NHẬT DỮ LIỆU SAU KHI XÓA SẢN PHẨM TỪ TOA MUA HOẶC TOA TRẢ
        void CapNhatSauKhiXoaSP(string sp, ListView lv)
        {
            int sl = 0;
            //lấy số lượng của sản phẩm muốn xóa trong listview
            for (int i = 0; i<lv.Items.Count; i++)
            {
                if (lv.Items[i].SubItems[0].Text == sp)
                {
                    sl = Convert.ToInt32(lv.Items[i].SubItems[1].Text);
                }
            }

            //nếu tham số truyền vào là listviewMuaHang
            if (lv.Name == "listViewMuaHang")
            {
                //cập nhật số lượng sản phẩm trong menu sau khi xóa
                for (int i = 0; i < dataGridViewSanPham.Rows.Count; i++)
                {
                    if (dataGridViewSanPham.Rows[i].Cells[0].Value.ToString() == sp)
                    {
                        sl = sl + Convert.ToInt32(dataGridViewSanPham.Rows[i].Cells[3].Value.ToString());
                    }
                }
            }
            //nếu tham số truyền vào là listviewTraHang
            else
            {
                //cập nhật số lượng sản phẩm trong menu sau khi xóa
                for (int i = 0; i < dataGridViewSanPham.Rows.Count; i++)
                {
                    if (dataGridViewSanPham.Rows[i].Cells[0].Value.ToString() == sp)
                    {
                        sl = Convert.ToInt32(dataGridViewSanPham.Rows[i].Cells[3].Value.ToString()) - sl ;
                    }
                }
            }

            //Cập nhật số lượng sản phẩm xóa vào menu chính
            connection.Open();
            string queryCapNhat = "update SanPham set SoLuongTon = " + sl + " where TenSP = '" + sp + "'";
            OleDbCommand cmdCapNhat = new OleDbCommand(queryCapNhat, connection);
            cmdCapNhat.ExecuteNonQuery();
            connection.Close();

            //tải lại menu với số lượng mới theo danh mục đang chọn
            if (this.comboBoxDanhMucSanPham.GetItemText(this.comboBoxDanhMucSanPham.SelectedItem) != "Tất cả")
            {
                connection.Open();
                string danhmuc = this.comboBoxDanhMucSanPham.GetItemText(this.comboBoxDanhMucSanPham.SelectedItem);
                string query = "select TenSP ,  DanhMuc, GiaBan, SoLuongTon from SanPham where TrangThai = 'ban' and DanhMuc = '" + danhmuc + "'";
                da = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataView dv = dt.DefaultView;
                dv.Sort = "DanhMuc";
                dv.Sort = "TenSp";
                dt = dv.ToTable();
                dataGridViewSanPham.DataSource = dt;
                dataGridViewSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSanPham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                connection.Close();
            }
            //tải lại menu với danh mục "Tất cả"
            else
            {
                HienSanPhamMacDinh();
            }
        }





        //----------CÁC HÀM THÔNG TIN THANH TOÁN-----------
        public static int tienthua = 0;
        public int TongTienMat_Cost = 0, TongTienCredit_Cost = 0;
        //HIỂN THỊ THÔNG TIN GROUPBOX THANH TOÁN
        void HienThongTinThanhToan()
        {
            TongTienMat_Cost = 0; TongTienCredit_Cost = 0;
            int TongSLMua = 0;
            int TongSLTra = 0;
            int TongMua = 0;
            int TongTra = 0;
            int row = dataGridViewSanPham.CurrentCell.RowIndex;

            for (int dongMua = 0; dongMua < Convert.ToInt32(listViewMuaHang.Items.Count.ToString()); dongMua++)
            {
                TongSLMua = TongSLMua + Convert.ToInt32(listViewMuaHang.Items[dongMua].SubItems[1].Text);
                TongMua = TongMua + Convert.ToInt32(listViewMuaHang.Items[dongMua].SubItems[3].Text);
            }

            for (int dongTra = 0; dongTra < Convert.ToInt32(listViewTraHang.Items.Count.ToString()); dongTra++)
            {
                TongSLTra = TongSLTra + Convert.ToInt32(listViewTraHang.Items[dongTra].SubItems[1].Text);
                TongTra = TongTra + Convert.ToInt32(listViewTraHang.Items[dongTra].SubItems[3].Text);
            }

            labelTongSL1_Cost.Text = labelTongSL2_Cost.Text = TongSLMua.ToString() + " - " + TongSLTra.ToString();
            labelMuaTraTienMat_Cost.Text = TongMua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " - " + TongTra.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelMuaTraCredit_Cost.Text = TongMua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " - " + TongTra.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");

            if (tabControlThanhToan.SelectedIndex == 0)
            {
                if (textBoxGiamGiaTienMat.Text == "")
                {
                    TongTienMat_Cost = TongMua - TongTra - Convert.ToInt32(textBoxGiamGiaTienMat.Text);
                }
                else
                {
                    TongTienMat_Cost =  TongMua - TongTra - Convert.ToInt32(textBoxGiamGiaTienMat.Text);         
                }
            }


            else
            {
                if (textBoxGiamGiaCredit.Text == "")
                {
                    TongTienCredit_Cost = TongMua - TongTra;
                }
                else
                {
                    TongTienCredit_Cost = TongMua - TongTra - Convert.ToInt32(textBoxGiamGiaCredit.Text);
                }
            }

            labelTongTienMat_Cost.Text = TongTienMat_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelTongTienCredit_Cost.Text = TongTienCredit_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");

        }

        private void tabControlThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThongTinThanhToan();
        }

        //HÀM KHI THAY ĐỔI DỮ LIỆU textBoxGiamGiaTienMat
        private void textBoxGiamGiaTienMat_TextChanged(object sender, EventArgs e)
        {
            textBoxTienMatKhachTra.Text = "0";
            if (textBoxGiamGiaTienMat.Text == "")
            {
                textBoxGiamGiaTienMat.Text = "0";
            }

            HienThongTinThanhToan();
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxGiamGiaTienMat
        private void textBoxGiamGiaTienMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM KHI THAY ĐỔI DỮ LIỆU textBoxTienMatKhachTra
        
        private void textBoxTienMatKhachTra_TextChanged(object sender, EventArgs e)
        {
            HienThongTinThanhToan();
            //nếu tổng toa > 0
            if (TongTienMat_Cost > 0)
            {
                if (textBoxTienMatKhachTra.Text == "")
                {
                    textBoxTienMatKhachTra.Text = "0";
                }
                tienthua = Convert.ToInt32(textBoxTienMatKhachTra.Text) - TongTienMat_Cost;

                if (tienthua > 0)
                {
                    labelTienThua_Cost.Text = tienthua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                    labelKhachThieuTienMat_Cost.Text = "0";
                    Toa_KhachThieu = 0;
                }
                if (tienthua < 0)
                {
                    Toa_KhachThieu = tienthua;
                    labelKhachThieuTienMat_Cost.Text = tienthua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                    labelTienThua_Cost.Text = "0";
                }
                if (tienthua == 0)
                {
                    Toa_KhachThieu = 0;
                    labelKhachThieuTienMat_Cost.Text = "0";
                    labelTienThua_Cost.Text = "0";
                }
            }
            // nếu toa < 0
            else
            {
                if (textBoxTienMatKhachTra.Text == "")
                {
                    textBoxTienMatKhachTra.Text = "0";
                }

                //nếu tiền trả cho khách ít hơn tiền đang thiếu khách
                if (Convert.ToInt32(textBoxTienMatKhachTra.Text)*-1 >= TongTienMat_Cost)
                {
                    if (textBoxTienMatKhachTra.Text == "")
                    {
                        textBoxTienMatKhachTra.Text = "0";
                    }
                    tienthua = TongTienMat_Cost + Convert.ToInt32(textBoxTienMatKhachTra.Text);
                    Toa_KhachThieu = (TongTienMat_Cost + Convert.ToInt32(textBoxTienMatKhachTra.Text));
                    labelKhachThieuTienMat_Cost.Text = (TongTienMat_Cost + Convert.ToInt32(textBoxTienMatKhachTra.Text)).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                    labelTienThua_Cost.Text = (TongTienMat_Cost + Convert.ToInt32(textBoxTienMatKhachTra.Text)).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                }
                //nếu tiền trả cho khách nhiều hơn tiền đang thiếu khách
                else
                {
                    MessageBox.Show("Vui lòng nhập tiền vừa đủ", "Thông báo");
                    textBoxTienMatKhachTra.Text = "0";
                }
            }
        }

        //HÀM XỬ LÝ TRẠNG THÁI KHÁCH NỢ HOẶC NỢ KHÁCH
        void KhachNo_KhachTra()
        {
            if (TongTienMat_Cost < 0)
            {
                labelTienMatKhachTra.Text = "Phải trả khách:";
                labelTienChuyenKhoan.Text = "Phải trả khách:";
                labelKhachThieuTienMat.Text = Toa_ThieuKhach_KhachThieu = "Thiếu khách:";
                labelKhachThieuCredit.Text = Toa_ThieuKhach_KhachThieu = "Thiếu khách:";
                labelTienThua.Visible = false;
                labelTienThua_Cost.Visible = false;
            }
            else
            {
                labelTienMatKhachTra.Text = "Tiền khách trả:";
                labelTienChuyenKhoan.Text = "Tiền chuyển khoản:";
                labelKhachThieuTienMat.Text = Toa_ThieuKhach_KhachThieu = "Khách thiếu:";
                labelKhachThieuCredit.Text = Toa_ThieuKhach_KhachThieu = "Khách thiếu:";
                labelTienThua.Visible = true;
                labelTienThua_Cost.Visible = true; 
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTienMatKhachTra
        private void textBoxTienMatKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM THỰC HIỆN KHI labelTongTienMat_Cost THAY ĐỔI
        private void labelTongTienMat_Cost_TextChanged(object sender, EventArgs e)
        {
            KhachNo_KhachTra();
            Toa_KhachThieu = -TongTienMat_Cost;
            labelKhachThieuTienMat_Cost.Text = "-" + TongTienMat_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            if (TongTienMat_Cost < 0)
            {
                Toa_KhachThieu = TongTienMat_Cost;
                labelKhachThieuTienMat_Cost.Text = TongTienMat_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }

            if (labelKhachThieuTienMat_Cost.Text == "0")
            {
                Toa_KhachThieu = -1 * TongTienMat_Cost;
                labelKhachThieuTienMat_Cost.Text = "-" + TongTienMat_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
        }

        //HÀM KHI THAY ĐỔI DỮ LIỆU textBoxGiamGiaCredit
        private void textBoxGiamGiaCredit_TextChanged(object sender, EventArgs e)
        {
            textBoxTienChuyenKhoan.Text = "0";
            if (textBoxGiamGiaCredit.Text == "")
            {
                textBoxGiamGiaCredit.Text = "0";
            }
            HienThongTinThanhToan();
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxGiamGiaCredit
        private void textBoxGiamGiaCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM KHI THAY ĐỔI DỮ LIỆU textBoxTienChuyenKhoan
        private void textBoxTienChuyenKhoan_TextChanged(object sender, EventArgs e)
        {
            //nếu tổng toa > 0
            if (TongTienCredit_Cost > 0)
            {
                if (textBoxTienChuyenKhoan.Text == "")
                {
                    textBoxTienChuyenKhoan.Text = "0";
                }

                tienthua = Convert.ToInt32(textBoxTienChuyenKhoan.Text) - TongTienCredit_Cost;
                if (tienthua>=0)
                {
                    Toa_KhachThieu = 0;
                    labelKhachThieuCredit_Cost.Text = "0";
                }
         
                if (tienthua < 0)
                {
                    labelKhachThieuCredit.Text = "Khách thiếu:";
                    Toa_KhachThieu = tienthua;
                    labelKhachThieuCredit_Cost.Text = tienthua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                }
            }

            //nếu tiền khách chuyển khoản < tổng toa
            if (Convert.ToInt32(textBoxTienChuyenKhoan.Text)  <= TongTienCredit_Cost)
            {
                if (TongTienCredit_Cost < 0)
                {
                    if (textBoxTienChuyenKhoan.Text == "")
                    {
                        textBoxTienChuyenKhoan.Text = "0";
                    }
                    tienthua = TongTienCredit_Cost + Convert.ToInt32(textBoxTienChuyenKhoan.Text);
                    Toa_KhachThieu = TongTienCredit_Cost + Convert.ToInt32(textBoxTienChuyenKhoan.Text);
                    labelKhachThieuCredit_Cost.Text = (TongTienCredit_Cost + Convert.ToInt32(textBoxTienChuyenKhoan.Text)).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                }
            }
            //nếu tiền khách chuyển khoản > tổng toa
            else
            {
                MessageBox.Show("Vui lòng nhập tiền vừa đủ", "Thông báo");
                textBoxTienChuyenKhoan.Text = "0";
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTienChuyenKhoan
        private void textBoxTienChuyenKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM THỰC HIỆN KHI labelTongTienCredit_Cost THAY ĐỔI
        private void labelTongTienCredit_Cost_TextChanged(object sender, EventArgs e)
        {
            KhachNo_KhachTra();

            Toa_KhachThieu = -TongTienCredit_Cost;
            labelKhachThieuCredit_Cost.Text = "-" + TongTienCredit_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            if (TongTienCredit_Cost < 0)
            {
                Toa_KhachThieu = TongTienCredit_Cost;
                labelKhachThieuCredit_Cost.Text = TongTienCredit_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }

            if (labelKhachThieuCredit_Cost.Text == "0")
            {
                Toa_KhachThieu = -TongTienCredit_Cost;
                labelKhachThieuCredit_Cost.Text = "-" + TongTienCredit_Cost.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
        }






        //----------CÁC HÀM THUỘC MỤC KHÁCH HÀNG-----------
        //HÀM XỬ LÝ HIỂN THỊ KHI CHỌN CHECK VÀO checkBoxKhachQuen
        private void checkBoxKhachQuen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKhachQuen.Checked == true)
            {
                checkBoxKhachVangLai.Checked = false;
                comboBoxKhachHang.Enabled = true;

                textBoxTenKhachVangLai.Enabled = false;
                textBoxSDTKhachVangLai.Enabled = false;
                textBoxDiaChiKhachVangLai.Enabled = false;
                textBoxTenKhachVangLai.Text = "";
                textBoxSDTKhachVangLai.Text = "";
                textBoxDiaChiKhachVangLai.Text = "";
            }
            else
            {
                checkBoxKhachVangLai.Checked = true;
                comboBoxKhachHang.SelectedIndex = 0;
                comboBoxKhachHang.Enabled = false;
                textBoxTenKhachVangLai.Enabled = true;
                textBoxSDTKhachVangLai.Enabled = true;
                textBoxDiaChiKhachVangLai.Enabled = true;

                labelSDTKhachCu_Text.Text = "";
                labelDiaChi_Text.Text = "";
            }
        }

        //HÀM HIỂN THỊ DANH SÁCH KHÁCH HÀNG 
        void cbbKhachHang()
        {
            connection.Open();
            string query = "select HoTenKhachHang from KhachHang";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HoTenKhachHang", typeof(string));
            dt.Rows.Add("--");
            dt.Load(reader);

            comboBoxKhachHang.ValueMember = "HoTenKhachHang";
            comboBoxKhachHang.DisplayMember = "HoTenKhachHang";
            comboBoxKhachHang.DataSource = dt;

            connection.Close();
        }

        //HÀM THỰC HIỆN KHI THAY ĐỔI DỮ LIỆU comboBoxKhachHang
        private void comboBoxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKhachHang.SelectedIndex == 0)
            {
                labelDiaChi_Text.Text = "";
                labelSDTKhachCu_Text.Text = "";
            }
            if (comboBoxKhachHang.SelectedIndex != 0)
            {

                connection.Open();
                string queryDiaChi = "select DiaChiKhachHang from KhachHang where HoTenKhachHang = '" + comboBoxKhachHang.GetItemText(this.comboBoxKhachHang.SelectedItem) + "'";
                OleDbCommand cmdDiaChi = new OleDbCommand(queryDiaChi, connection);
                labelDiaChi_Text.Text = Convert.ToString(cmdDiaChi.ExecuteScalar());

                string querySDT = "select SDTKhachHang from KhachHang where HoTenKhachHang = '" + comboBoxKhachHang.GetItemText(this.comboBoxKhachHang.SelectedItem) + "'";
                OleDbCommand cmdSDT = new OleDbCommand(querySDT, connection);
                labelSDTKhachCu_Text.Text = Convert.ToString(cmdSDT.ExecuteScalar());
                connection.Close();
            }
        }

        //HÀM XỬ LÝ HIỂN THỊ KHI CHỌN CHECK VÀO checkBoxKhachVangLai
        private void checkBoxKhachVangLai_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKhachVangLai.Checked == true)
            {
                checkBoxKhachQuen.Checked = false;
                comboBoxKhachHang.Enabled = false;

                textBoxTenKhachVangLai.Enabled = true;
                textBoxSDTKhachVangLai.Enabled = true;
                textBoxDiaChiKhachVangLai.Enabled = true;
            }
            else
            {
                checkBoxKhachQuen.Checked = true;
                comboBoxKhachHang.Enabled = true;

                textBoxTenKhachVangLai.Enabled = false;
                textBoxSDTKhachVangLai.Enabled = false;
                textBoxDiaChiKhachVangLai.Enabled = false;
                textBoxTenKhachVangLai.Text = "";
                textBoxSDTKhachVangLai.Text = "";
                textBoxDiaChiKhachVangLai.Text = "";
            }
        }
    
        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTenKhachMoi
        private void textBoxTenKhachVangLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxSDTKhachMoi
        private void textBoxSDTKhachVangLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static string LoaiKhach;
        //HÀM KIỂM TRA SỐ ĐIỆN THOẠI KHÁCH VÃNG LAI
        private void textBoxSDTKhachVangLai_TextChanged(object sender, EventArgs e)
        {
            textBoxTenKhachVangLai.BackColor = Color.White;
            textBoxSDTKhachVangLai.BackColor = Color.White;

            //kiểm tra khách vãng lai mới đã có trong danh sách khách hàng loại khachvanglai hay không
            connection.Open();
            string queryKT_KVL = "select count(SDTKhachHang) from KhachHang where SDTKhachHang = '" + textBoxSDTKhachVangLai.Text + "' and LoaiKhachHang = 'khachvanglai'";
            OleDbCommand cmdKT_KVL = new OleDbCommand(queryKT_KVL, connection);
            int KT_KVL = Convert.ToInt32(cmdKT_KVL.ExecuteScalar());

            //nếu khách vãng lai mới không có trong danh sách khách hàng loại khachvanglai
            if (KT_KVL == 0)
            {
                //kiểm tra khách vãng lai mới đã có trong danh sách khách hàng loại khachquen hay không
                string queryKT_KQ = "select count(SDTKhachHang) from KhachHang where SDTKhachHang = '" + textBoxSDTKhachVangLai.Text + "' and LoaiKhachHang = 'khachquen'";
                OleDbCommand cmdKT_KQ = new OleDbCommand(queryKT_KQ, connection);
                int KT_KQ = Convert.ToInt32(cmdKT_KQ.ExecuteScalar());

                //nếu khách vãng lai mới không có trong danh sách khách hàng loại khachquen
                if (KT_KQ > 0)
                {
                    textBoxSDTKhachVangLai.BackColor = Color.Silver;
                }

                //nếu khách vãng lai mới đã tồn tại trong danh sách khách hàng loại khachquen
                else
                {
                    textBoxSDTKhachVangLai.BackColor = Color.White;
                    LoaiKhach = "KhachVangLaiMoi";
                }
            }

            //nếu khách vãng lai mới có trong danh sách khách hàng loại khachvanglai
            else
            {
                LoaiKhach = "KhachVangLaiCu";
            }
            connection.Close();
        }






        //----------CÁC HÀM CHỨC NĂNG THANH TOÁN VÀ LƯU CÁC THÔNG TIN ĐỂ CHUYỂN SANG FORM XÁC NHẬN TOA-----------
        //HÀM TẠO DATATABLE dtbMuaHang 
        void dtbMuaHang()
        {
            formXacNhanToa.dt.Columns.Clear();
            formXacNhanToa.dt.Columns.Add("SP");
            formXacNhanToa.dt.Columns.Add("SL");
            formXacNhanToa.dt.Columns.Add("DG");
            formXacNhanToa.dt.Columns.Add("TT");
        }

        //HÀM TẠO DATATABLE dtbTraHang 
        void dtbTraHang()
        {
            formXacNhanToa.dttra.Columns.Clear();
            formXacNhanToa.dttra.Columns.Add("SP");
            formXacNhanToa.dttra.Columns.Add("SL");
            formXacNhanToa.dttra.Columns.Add("DG");
            formXacNhanToa.dttra.Columns.Add("TT");
        }

        //HÀM LẤY THÔNG TIN TOA MUA VÀ TOA TRẢ THÊM VÀO dtbMuaHang VÀ dtbTraHang
        void LayThongTinToa_MuaTra()
        {
            int count = 1;
            //nếu listViewMuaHang có dữ liệu
            if (listViewMuaHang.Items.Count>0)
            {
                //lấy thông tin toa mua thêm vào dtbMuaHang
                for (int i = 0; i < listViewMuaHang.Items.Count; i++)
                {
                    DataRow dtr = formXacNhanToa.dt.NewRow();
                    for (int j = 0; j < listViewMuaHang.Columns.Count; j++)
                    {
                        if (count == 5)
                        {
                            count = 1;
                        }

                        if (count == 1)
                        {
                            dtr["SP"] = listViewMuaHang.Items[i].SubItems[j].Text;
                        }
                        if (count == 2)
                        {
                            dtr["SL"] = listViewMuaHang.Items[i].SubItems[j].Text;
                        }
                        if (count == 3)
                        {
                            dtr["DG"] = listViewMuaHang.Items[i].SubItems[j].Text;
                        }
                        if (count == 4)
                        {
                            dtr["TT"] = listViewMuaHang.Items[i].SubItems[j].Text;
                        }
                        count++;
                    }
                    formXacNhanToa.dt.Rows.Add(dtr);
                }
            }

            //nếu listViewTraHang có dữ liệu
            if (listViewTraHang.Items.Count > 0)
            {
                //lấy thông tin toa mua thêm vào dtbTraHang
                for (int i = 0; i < listViewTraHang.Items.Count; i++)
                {
                    DataRow dtr = formXacNhanToa.dttra.NewRow();
                    for (int j = 0; j < listViewTraHang.Columns.Count; j++)
                    {
                        if (count == 5)
                        {
                            count = 1;
                        }

                        if (count == 1)
                        {
                            dtr["SP"] = listViewTraHang.Items[i].SubItems[j].Text;
                        }
                        if (count == 2)
                        {
                            dtr["SL"] = listViewTraHang.Items[i].SubItems[j].Text;
                        }
                        if (count == 3)
                        {
                            dtr["DG"] = listViewTraHang.Items[i].SubItems[j].Text;
                        }
                        if (count == 4)
                        {
                            dtr["TT"] = listViewTraHang.Items[i].SubItems[j].Text;
                        }
                        count++;
                    }
                    formXacNhanToa.dttra.Rows.Add(dtr);
                }
            }
        }

        public static string TenKhach;
        public static string SDT;
        public static string DiaChi;
        //HÀM LẤY THÔNG TIN TỪ FORM BÁN HÀNG ĐỂ FORM XÁC NHẬN TOA SỬ DỤNG
        void LayThongTinChoFormXacNhanToa()
        {
            //nếu khách hàng là khách vãng lai
            if (checkBoxKhachVangLai.Checked == true)
            {
                TenKhach = textBoxTenKhachVangLai.Text;
                SDT = textBoxSDTKhachVangLai.Text;
                DiaChi = textBoxDiaChiKhachVangLai.Text;
                if (tabControlThanhToan.SelectedIndex == 0)
                {
                    TongToaHang = TongTienMat_Cost;
                }
                else
                {
                    TongToaHang = TongTienCredit_Cost;
                }
                
                SLSanPham = labelTongSL1_Cost.Text;

                if (tabControlThanhToan.SelectedIndex == 0)
                {
                    KhachNo = Math.Abs(tienthua);
                    ThanhToan = "Tiền mặt";
                    giamgia = textBoxGiamGiaTienMat.Text;
                }
                if (tabControlThanhToan.SelectedIndex == 1)
                {
                    KhachNo = Math.Abs(tienthua);
                    ThanhToan = "Credit Card";
                    giamgia = textBoxGiamGiaCredit.Text;
                }                
            }
            //nếu khách hàng là khách quen
            else if (checkBoxKhachQuen.Checked == true)
            {
                if (comboBoxKhachHang.SelectedIndex != 0)
                {
                    TenKhach = comboBoxKhachHang.GetItemText(this.comboBoxKhachHang.SelectedItem);
                    SDT = labelSDTKhachCu_Text.Text;
                }

                if (tabControlThanhToan.SelectedIndex == 0)
                {
                    TongToaHang = TongTienMat_Cost;
                }
                else
                {
                    TongToaHang = TongTienCredit_Cost;
                }
                SLSanPham = labelTongSL1_Cost.Text;

                if (tabControlThanhToan.SelectedIndex == 0)
                {
                    KhachNo = Math.Abs(tienthua);
                    ThanhToan = "Tiền mặt";
                    giamgia = textBoxGiamGiaTienMat.Text;
                }
                if (tabControlThanhToan.SelectedIndex == 1)
                {
                    KhachNo = Math.Abs(tienthua);
                    ThanhToan = "Credit Card";
                    giamgia = textBoxGiamGiaCredit.Text;
                }
            }
        }

        //HÀM THỰC HIỆN THANH TOÁN
        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            //báo lỗi nếu chưa mua sản phẩm nào trong toa Mua và toa Trả
            if ((listViewMuaHang.Items.Count == 0 && listViewTraHang.Items.Count == 0))
            {
                MessageBox.Show("Toa chưa có thông tin sản phẩm !!!", "Thông báo");
            }
            //nếu đã có ít nhất 1 món trong toa Mua hoặc toa Trả
            else
            {
                //nếu khách hàng là khách quen
                if (checkBoxKhachQuen.Checked == true)
                {    
                    //nếu chưa chọn thông tin khách hàng
                    if (comboBoxKhachHang.SelectedIndex == 0)
                    {
                        MessageBox.Show("Vui lòng chọn thông tin khách hàng !!!", "Thông báo");
                    }
                    //nếu đã chọn thông tin khách hàng
                    if (comboBoxKhachHang.SelectedIndex != 0)
                    {
                        LayThongTinChoFormXacNhanToa();
                        LayThongTinToa_MuaTra();
                        formXacNhanToa f = new formXacNhanToa();
                        f.ShowDialog();
                        if (kettoa == 1)
                        {
                            Refresh();
                            HienSanPhamMacDinh();
                        }
                    }
                }
                //nếu khách hàng là khách vãng lai
                else if (checkBoxKhachVangLai.Checked == true)
                {
                    //nếu đã điền thông tin khách hàng vãng lai
                    if (textBoxTenKhachVangLai.Text != "" && textBoxSDTKhachVangLai.Text != "")
                    {
                        //nếu thông tin khách vãng lai hợp lệ
                        if (textBoxSDTKhachVangLai.BackColor == Color.White)
                        {
                            LayThongTinChoFormXacNhanToa();
                            LayThongTinToa_MuaTra();
                            formXacNhanToa f = new formXacNhanToa();
                            f.ShowDialog();
                            if (kettoa == 1)
                            {
                                Refresh();
                                HienSanPhamMacDinh();
                            }
                        }

                        //nếu thông tin khách vãng lai không hợp lệ
                        else
                        {
                            MessageBox.Show("SDT đã tồn tại trong danh sách khách quen, vui lòng xem lại !!!", "Thông báo");
                        }
                    }

                    //nếu khách hàng vãng lai chưa có thông tin
                    else
                    {
                        MessageBox.Show("Vui lòng nhập thông tin khách hàng !!!", "Thông báo");
                    }
                }

            }
        }






        //----------CÁC HÀM PHÂN QUYỀN CÁC CHỨC NĂNG VÀ HIỂN THỊ BORDER CÁC GROUPBOX-----------
        //HÀM XÉT QUYỀN CỦA USER
        void PQ()
        {
            connection.Open();

            string query = "select LoaiTaiKhoan from TaiKhoan where Username = '"+formDangNhap.username+"'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            Quyen = cmd.ExecuteScalar().ToString();

            connection.Close();
        }

        //HÀM MỞ FORM QUẢN LÝ TOA
        private void quảnLýToaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Quyen == "0")
            {
                formQuanLyToa f = new formQuanLyToa();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải quản lý sạp nên không thể truy cập vào mục này","Thông báo");
            } 
        }

        //HÀM MỞ FORM TÀI KHOẢN SẢN PHẨM
        private void tàiKhoảnSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "0")
            {
                formTaiKhoanSanPham f = new formTaiKhoanSanPham();
                this.Hide();
                f.ShowDialog();
                this.Show();
                HienSanPhamMacDinh();
                HienDanhMuc();
            }
            else
            {
                MessageBox.Show("Bạn không phải quản lý sạp nên không thể truy cập vào mục này", "Thông báo");
            }
        }

        //HÀM MỞ FORM DANH SÁCH KHÁCH HÀNG
        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDanhSachKhachHang f = new formDanhSachKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
            cbbKhachHang();
        }

        //HÀM MỞ FORM QUẢN LÝ DOANH THU
        private void quảnLýDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "0")
            {
                formQuanLyDoanhThuBanHang f = new formQuanLyDoanhThuBanHang();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải quản lý sạp nên không thể truy cập vào mục này", "Thông báo");
            }
        }

        //HÀM MỞ FORM NHẬP HÀNG
        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "0")
            {
                formNhapHang f = new formNhapHang();
                this.Hide();
                f.ShowDialog();
                this.Show();
                HienSanPhamMacDinh();
                HienDanhMuc();
            }
            else
            {
                MessageBox.Show("Bạn không phải quản lý sạp nên không thể truy cập vào mục này", "Thông báo");
            }
        }

        //HÀM MỞ FORM LƯƠNG NHÂN VIÊN
        private void quảnLýLươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "0")
            {
                formQuanLyLuongNhanVien f = new formQuanLyLuongNhanVien();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải quản lý sạp nên không thể truy cập vào mục này", "Thông báo");
            }
        }

        //HÀM MỞ FORM CẬP NHẬT THÔNG TIN TÀI KHOẢN
        private void ThongTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formThongTinTaiKhoan f = new formThongTinTaiKhoan();
            f.ShowDialog();
            HienThiUsername();
        }

        //HÀM HIỂN THỊ BORDER CỦA groupBoxThongTinKhachHang
        private void groupBoxThongTinKhachHang_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 245, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

       

        //HÀM HIỂN THỊ BORDER CỦA groupBoxThanhToan
        private void groupBoxThanhToan_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 133, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }
    }
}
