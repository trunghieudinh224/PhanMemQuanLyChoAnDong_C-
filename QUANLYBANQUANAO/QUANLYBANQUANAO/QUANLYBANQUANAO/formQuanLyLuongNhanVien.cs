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
using System.Drawing.Drawing2D;
using System.Drawing.Text;


namespace QUANLYBANQUANAO
{
    public partial class formQuanLyLuongNhanVien : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public formQuanLyLuongNhanVien()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            dateTimePickerThangNam.Value = Convert.ToDateTime(DateTime.Now.ToString("MM/yyyy"));

            MaxDayMinDay();

            ChiTietLuongNhanVien(0, dataGridViewGioCong);
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

        //SỰ KIỆN HIỂN THỊ BORDER CỦA groupBoxLuongNhanVienChiTiet
        private void groupBoxLuongNhanVienChiTiet_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 284, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA groupBoxTongKet
        private void groupBoxTongKet_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 112, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        //HÀM THIẾT LẬP NGÀY THÁNG CHO dateTimePickerThangNam
        void MaxDayMinDay()
        {            
            dateTimePickerThangNam.MaxDate = Convert.ToDateTime(DateTime.Now.ToString("MM/yyyy"));
            dateTimePickerThangNam.MinDate = Convert.ToDateTime("01/2020");
        }

        //HÀM HIỆN THÔNG TIN LƯƠNG NHÂN VIÊN
        void HienLuong()
        {
            connection.Open();
            //lấy số lượng nhân viên đang làm việc
            string querySLNV = "select Username from TaiKhoan where LoaiTaiKhoan = '1' and TrangThai = 'On' ";
            da = new OleDbDataAdapter(querySLNV, connection);
            DataTable dtSLNV = new DataTable();
            da.Fill(dtSLNV);

            //lấy thông tin tất cả nhân viên trong hệ thống lương theo tháng đã chọn
            string queryHienThongTinLuongNV1 = "select GioCongVaLuongNhanVien.Username, LuongTheoGio, LuongThuong, TongLuong, TongGioLam, Ngay1, Ngay2, Ngay3, Ngay4, Ngay5, Ngay6, Ngay7, Ngay8, Ngay9, Ngay10, Ngay11, Ngay12, Ngay13, Ngay14, Ngay15, Ngay16, Ngay17, Ngay18, Ngay19, Ngay20, Ngay21, Ngay22, Ngay23, Ngay24, Ngay25, Ngay26, Ngay27, Ngay28, Ngay29, Ngay30, Ngay31 from GioCongVaLuongNhanVien where Thang = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("MM")) + " and Nam = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("yyyy")) + " ";
            da = new OleDbDataAdapter(queryHienThongTinLuongNV1, connection);
            DataTable dtHienThongTinLuongNV1 = new DataTable();
            da.Fill(dtHienThongTinLuongNV1);
            connection.Close();

            //nếu đã có thông tin lương của toàn bộ nhân viên trong tháng đã chọn
            if (dtHienThongTinLuongNV1.Rows.Count > 0)
            {
                dataGridViewGioCong.DataSource = dtHienThongTinLuongNV1;
                dataGridViewGioCong.Sort(dataGridViewGioCong.Columns[4], ListSortDirection.Descending);
            }
            //nếu chưa tồn tại thông tin lương của toàn bộ nhân viên trong tháng đã chọn
            else if (dtHienThongTinLuongNV1.Rows.Count == 0)
            {
                //thêm thông tin lương của tháng đã chọn cho toàn bộ nhân viên 
                for (int i = 0; i < dtSLNV.Rows.Count; i++)
                {
                    connection.Open();
                    string queryThemLuongThangHienTai = "insert into GioCongVaLuongNhanVien (Username, Nam, Thang) values ('" + dtSLNV.Rows[i].ItemArray[0].ToString() + "', " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("yyyy")) + ", " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("MM")) + ")";
                    OleDbCommand cmdThemLuongThangHienTai = new OleDbCommand(queryThemLuongThangHienTai, connection);
                    cmdThemLuongThangHienTai.ExecuteNonQuery();
                    connection.Close();
                }

                //hiển thị thông tin lương tháng đã chọn (vừa tạo) lên dataGridViewGioCong
                connection.Open();
                string queryHienThongTinLuongNV2 = "select GioCongVaLuongNhanVien.Username, LuongTheoGio, LuongThuong, TongLuong, TongGioLam, Ngay1, Ngay2, Ngay3, Ngay4, Ngay5, Ngay6, Ngay7, Ngay8, Ngay9, Ngay10, Ngay11, Ngay12, Ngay13, Ngay14, Ngay15, Ngay16, Ngay17, Ngay18, Ngay19, Ngay20, Ngay21, Ngay22, Ngay23, Ngay24, Ngay25, Ngay26, Ngay27, Ngay28, Ngay29, Ngay30, Ngay31 from GioCongVaLuongNhanVien where Thang = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("MM")) + " and Nam = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("yyyy")) + " ";
                da = new OleDbDataAdapter(queryHienThongTinLuongNV2, connection);
                DataTable dtHienThongTinLuongNV2 = new DataTable();
                da.Fill(dtHienThongTinLuongNV2);
                connection.Close();
                dataGridViewGioCong.DataSource = dtHienThongTinLuongNV2;
                dataGridViewGioCong.Sort(dataGridViewGioCong.Columns[4], ListSortDirection.Descending);
            }
        }

        //HÀM THAY ĐỔI DỮ LIỆU KHI dateTimePickerThangNam THAY ĐỔI
        private void dateTimePickerThangNam_ValueChanged(object sender, EventArgs e)
        {
            HienLuong();
            TongKet();
            ChiTietLuongNhanVien(0, dataGridViewGioCong);
        }

        public int NhanVien = 0;
        //HÀM KHI CHỌN 1 NHÂN VIÊN TRONG DANH SÁCH BẢNG LƯƠNG NHÂN VIÊN
        private void dataGridViewGioCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewGioCong.CurrentCell.RowIndex;
            NhanVien = row;

            if (row >= 0)
            {               
                ChiTietLuongNhanVien(row, dataGridViewGioCong);
            }
        }

        //HÀM HIỂN THỊ CHI TIẾT LƯƠNG NHÂN VIÊN LÊN LABEL
        void ChiTietLuongNhanVien(int row, DataGridView dtg)
        {
            labelNhanVien_Text.Text = dataGridViewGioCong.Rows[row].Cells[0].Value.ToString();
            labelLuongTheoGio_Text.Text = Convert.ToInt32(dataGridViewGioCong.Rows[row].Cells[1].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelGioCong_Text.Text = Convert.ToInt32(dataGridViewGioCong.Rows[row].Cells[4].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelLuongThuong_Text.Text = Convert.ToInt32(dataGridViewGioCong.Rows[row].Cells[2].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelTongThuNhap_Text.Text = Convert.ToInt32(dataGridViewGioCong.Rows[row].Cells[3].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
        }

        //HÀM HIỂN THỊ TỔNG KẾT LƯƠNG NHÂN VIÊN THÁNG
        void TongKet()
        {
            labelNhanVienHieuQuaNhat_Text.Text = dataGridViewGioCong.Rows[0].Cells[0].Value.ToString();
            int TongLuong = 0, TongThuong = 0;

            for (int i = 0; i<dataGridViewGioCong.Rows.Count; i++)
            {
                TongLuong = TongLuong + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[3].Value.ToString());
                TongThuong = TongThuong + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[2].Value.ToString());
            }
            labelTongLuongThang_Text.Text = TongLuong.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelTongThuong_Text.Text = TongThuong.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelSLNV_Text.Text = dataGridViewGioCong.Rows.Count.ToString();

            DataTable dtbNVHQN = new DataTable();
            dtbNVHQN.Columns.Add("NVHQN");
            if (dataGridViewGioCong.Rows.Count > 1)
            {
                for (int i = 1; i<dataGridViewGioCong.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[4].Value.ToString()) == Convert.ToInt32(dataGridViewGioCong.Rows[0].Cells[4].Value.ToString()))
                    {
                        labelNhanVienHieuQuaNhat_Text.Text = labelNhanVienHieuQuaNhat_Text.Text + ", " + dataGridViewGioCong.Rows[i].Cells[0].Value.ToString();
                    }
                }

            }
            else
            {
                labelNhanVienHieuQuaNhat_Text.Text = dataGridViewGioCong.Rows[0].Cells[0].Value.ToString();
            }
        }

        //Không cho viết chữ hoặc bất ký tự nào khác ngoại trừ số
        private void dataGridViewGioCong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dataGridViewGioCong_KeyPress);
            if (dataGridViewGioCong.CurrentCell.ColumnIndex > 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dataGridViewGioCong_KeyPress);
                }
            }
        }

        //Không cho viết chữ hoặc bất ký tự nào khác ngoại trừ số
        private void dataGridViewGioCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM CẬP NHẬT LƯƠNG LÊN CƠ SỞ DỮ LIỆU
        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            //cập nhật lương theo giờ, tổng lương , lương thưởng
            for (int i = 0; i < dataGridViewGioCong.Rows.Count; i++)   
            {
                connection.Open();
                string query = "update GioCongVaLuongNhanVien set LuongTheoGio = " + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[1].Value.ToString()) + ", LuongThuong = " + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[2].Value.ToString()) + ", TongLuong = " + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[3].Value.ToString()) + ", TongGioLam = " + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[4].Value.ToString()) + " where Username = '" + dataGridViewGioCong.Rows[i].Cells[0].Value.ToString() + "' and Nam = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("yyyy")) + " and Thang = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("MM")) + " ";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            //cập nhật giờ công theo ngày
            for (int i = 0; i < dataGridViewGioCong.Rows.Count; i++)
            {
                int Cot = 5;

                for (int j = 1; j <= 31; j++)
                {
                    connection.Open();
                    string query = "update GioCongVaLuongNhanVien set Ngay" + j.ToString() + " = " + Convert.ToInt32(dataGridViewGioCong.Rows[i].Cells[Cot].Value.ToString()) + " where Username = '" + dataGridViewGioCong.Rows[i].Cells[0].Value + "' and Nam = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("yyyy")) + " and Thang = " + Convert.ToInt32(dateTimePickerThangNam.Value.ToString("MM")) + " ";
                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    Cot++;
                }
            }

            timerTC.Start();
            labelTC.Visible = true;
        }

        //HÀM CẬP NHẬT DỮ LIỆU dataGridViewGioCong SAU KHI THAY ĐỔI 1 Ô 
        private void dataGridViewGioCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int CheckRong = 0, CotRong =0, DongRong = 0;
            for (int i = 0; i < dataGridViewGioCong.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewGioCong.Columns.Count; j++)
                {
                    if (dataGridViewGioCong.Rows[i].Cells[j].Value.ToString() == "")
                    {
                        CheckRong++;
                        CotRong = j;
                        DongRong = i;
                    }
                }
            }

            if (CheckRong > 0)
            {
                dataGridViewGioCong.Rows[DongRong].Cells[CotRong].Value = "0";
            }
            else if (CheckRong == 0)
            {
                int TongGioLam = 0;
                for (int cot = 5; cot <= 35; cot++)
                {
                    TongGioLam = TongGioLam + Convert.ToInt32(dataGridViewGioCong.Rows[NhanVien].Cells[cot].Value.ToString());
                }
                dataGridViewGioCong.Rows[NhanVien].Cells[4].Value = TongGioLam;
                dataGridViewGioCong.Rows[NhanVien].Cells[3].Value = TongGioLam * Convert.ToInt32(dataGridViewGioCong.Rows[NhanVien].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridViewGioCong.Rows[NhanVien].Cells[2].Value.ToString()); 
            }
            ChiTietLuongNhanVien(NhanVien, dataGridViewGioCong);
            TongKet();
        }

        public int TC = 0;
        //HÀM HIỂN THỊ THÔNG BÁO THÀNH CÔNG
        private void timerTC_Tick(object sender, EventArgs e)
        {
            TC++;
            if (TC == 1)
            {
                timerTC.Stop();
                labelTC.Visible = false;
                timerTC.Enabled = false;
                TC = 0;
            }
        }

        
    }
}
