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
    public partial class formQuanLyToa : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public static string ToaDuocChon = "1";
        public string ToaKhachNoDuocChon;

        public formQuanLyToa()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienDSToaMacDinh();

            HienToaKhachNoMacDinh();

            HienToaNoKhachMacDinh();
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

        //HÀM HIỂN THỊ DANH SÁCH TOA
        void HienDSToaMacDinh()
        {
            connection.Open();

            string query = "select NgayLapToa,MaToa,TenKhachHang,SDTKhachHang,TongToa,HinhThucThanhToan from Toa order by MaToa";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewToa.DataSource = dt;
            dataGridViewToa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewToa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            connection.Close();
        }

        //HÀM HIỆN DANH SÁCH TOA THEO THỜI GIAN
        private void buttonHienDanhSachBill_Click(object sender, EventArgs e)
        {
            connection.Open();

            string query = "select NgayLapToa,MaToa,TenKhachHang,SDTKhachHang,TongToa,HinhThucThanhToan from Toa where NgayLapToa >= #"+dateTimePickerTuNgay.Value.ToString("MM/dd/yyyy")+ "# and NgayLapToa <= #" + dateTimePickerDenNgay.Value.ToString("MM/dd/yyyy") + "#";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewToa.DataSource = dt;
            dataGridViewToa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewToa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            connection.Close();
        }

        //HÀM KHI CHỌN VÀO 1 TOA TRONG DANH SÁCH
        private void dataGridViewToa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewToa.CurrentCell.RowIndex;

            if (row >= 0)
            {
                ToaDuocChon = dataGridViewToa.Rows[row].Cells[1].Value.ToString();
            }    
        }

        //HÀM TÌM KIẾM TOA
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string ToaTim = textBoxTimKiem.Text;
            connection.Open();

            string query = "select NgayLapToa,MaToa,TenKhachHang,SDTKhachHang,TongToa,HinhThucThanhToan from Toa where (NgayLapToa between #" + dateTimePickerTuNgay.Value.ToString("dd/MM/yyyy") + "# and #" + dateTimePickerDenNgay.Value.ToString("dd/MM/yyyy") + "#) and (MaToa like ('%" + ToaTim + "%') or TenKhachHang like ('%" + ToaTim + "%') or SDTKhachHang like ('%" + ToaTim + "%') or HinhThucThanhToan like ('%" + ToaTim + "%') or TongToa like ('%" + ToaTim + "%'))";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewToa.DataSource = dt;
            dataGridViewToa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewToa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            connection.Close();
        }




        //----------TAB TOA KHÁCH NỢ----------
        //HÀM HIỂN THỊ DANH SÁCH TOA KHÁCH NỢ
        public int TongToaKhachNo, TienKhachTra_KhachNo, khachNo = 0;
        void HienToaKhachNoMacDinh()
        {
            TongToaKhachNo = TienKhachTra_KhachNo = khachNo = 0;
            connection.Open();

            string query = "select NgayLapToa,MaToa,TenKhachHang,TongToa,KhachNo from Toa where KhachNo > 0";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewToaKhachNo.DataSource = dt;
            dataGridViewToaKhachNo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToaKhachNo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewToaKhachNo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToaKhachNo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToaKhachNo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dataGridViewToaKhachNo.Rows.Count > 0)
            {
                labelMaToaKhachNo_Text.Text = dataGridViewToaKhachNo.Rows[0].Cells[1].Value.ToString();
                labelTenKhachKhachNo_Text.Text = dataGridViewToaKhachNo.Rows[0].Cells[2].Value.ToString();
                TongToaKhachNo = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[3].Value.ToString());
                labelTongToaKhachNo_Text.Text = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[3].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
                TienKhachTra_KhachNo = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[4].Value.ToString());
                labelKhachNo_Text.Text = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[4].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
                khachNo = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[4].Value.ToString());
                textBoxTinhTrangKhachNo.Text = "Chưa thanh toán đủ";
            }
            else
            {
                labelMaToaKhachNo_Text.Text = "";
                labelTenKhachKhachNo_Text.Text = "";
                labelTongToaKhachNo_Text.Text = "0";
                labelKhachNo_Text.Text = "0";
                textBoxTinhTrangKhachNo.Text = "";
            }

            connection.Close();
        }

        //HÀM KHI CHỌN VÀO 1 TOA TRONG DANH SÁCH TOA KHÁCH NỢ
        private void dataGridViewToaKhachNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewToaKhachNo.CurrentCell.RowIndex;

            if (row >= 0)
            {
                labelMaToaKhachNo_Text.Text = dataGridViewToaKhachNo.Rows[0].Cells[1].Value.ToString();
                labelTenKhachKhachNo_Text.Text = dataGridViewToaKhachNo.Rows[0].Cells[2].Value.ToString();
                TongToaKhachNo = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[3].Value.ToString());
                labelTongToaKhachNo_Text.Text = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[3].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
                TienKhachTra_KhachNo = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[4].Value.ToString());
                labelKhachNo_Text.Text = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[4].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
                khachNo = Convert.ToInt32(dataGridViewToaKhachNo.Rows[0].Cells[4].Value.ToString());
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTraNoKhachNo
        private void textBoxTraNoKhachNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM THAY ĐỔI TRẠNG THÁI TOA KHI NHẬP DỮ LIỆU VÀO textBoxTraNoKhachNo
        private void textBoxTraNoKhachNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTraNoKhachNo.Text == "")
            {
                textBoxTraNoKhachNo.Text = "0";
            }

            int TraNo = khachNo - Convert.ToInt32(textBoxTraNoKhachNo.Text);
            if (TraNo <= 0)
            {
                textBoxTinhTrangKhachNo.Text = "Đã thanh toán đủ";
            }

            if (TraNo > 0)
            {
                textBoxTinhTrangKhachNo.Text = "Chưa thanh toán đủ";
            }
        }

        //HÀM KHI NHẤN NÚT CẬP NHẬT TOA KHÁCH NỢ
        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            connection.Open();

            if (textBoxTinhTrangKhachNo.Text == "Chưa thanh toán đủ")
            {
                string query = "update Toa set KhachNo = "+Convert.ToInt32(Convert.ToInt32(labelKhachNo_Text.Text) + Convert.ToInt32(textBoxTraNoKhachNo.Text)) +" where MaToa = " + Convert.ToInt32(labelMaToaKhachNo_Text.Text) + "";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            if (textBoxTinhTrangKhachNo.Text == "Đã thanh toán đủ")
            {
                string query = "update Toa set KhachNo = 0 where MaToa = " + Convert.ToInt32(labelMaToaKhachNo_Text.Text) + "";
                OleDbCommand cmd = new OleDbCommand(query,connection);
                cmd.ExecuteNonQuery();                
            }
            connection.Close();

            HienDSToaMacDinh();
            HienToaKhachNoMacDinh();
        }




        //----------TAB TOA NỢ KHÁCH----------
        public int noKhach = 0;
        //HÀM HIỂN THỊ TOA NỢ KHÁCH
        void HienToaNoKhachMacDinh()
        {
            connection.Open();

            string query = "select NgayLapToa,MaToa,TenKhachHang,TongToa,NoKhach from Toa where NoKhach > 0";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewToaNoKhach.DataSource = dt;
            dataGridViewToaNoKhach.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewToaNoKhach.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewToaNoKhach.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToaNoKhach.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewToaNoKhach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int x = dataGridViewToaNoKhach.Rows.Count;
            if (x != 0)
            {
                labelMaToaNoKhach_Text.Text = dataGridViewToaNoKhach.Rows[0].Cells[1].Value.ToString();
                labelTenKhachNoKhach_Text.Text = dataGridViewToaNoKhach.Rows[0].Cells[2].Value.ToString();
                labelTongToaNoKhach_Text.Text = Convert.ToInt32(dataGridViewToaNoKhach.Rows[0].Cells[3].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                labelNoKhachNoKhach_Text.Text = Convert.ToInt32(dataGridViewToaNoKhach.Rows[0].Cells[4].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                noKhach = Convert.ToInt32(dataGridViewToaNoKhach.Rows[0].Cells[4].Value.ToString());
                textBoxTinhTrangNoKhach.Text = "Còn nợ";
            }
            else
            {
                labelMaToaNoKhach_Text.Text = "";
                labelTenKhachNoKhach_Text.Text = "";
                labelTongToaNoKhach_Text.Text = "0";
                labelNoKhachNoKhach_Text.Text = "0";
                textBoxTinhTrangNoKhach.Text = "";
            }

            connection.Close();
        }

        //HÀM KHI CHỌN 1 TOA TRONG DANH SÁCH TOA NỢ KHÁCH
        private void dataGridViewToaNoKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewToaNoKhach.CurrentCell.RowIndex;

            if (row >= 0)
            {
                labelMaToaNoKhach_Text.Text = dataGridViewToaNoKhach.Rows[row].Cells[1].Value.ToString();
                labelTenKhachNoKhach_Text.Text = dataGridViewToaNoKhach.Rows[row].Cells[2].Value.ToString();
                labelTongToaNoKhach_Text.Text = Convert.ToInt32(dataGridViewToaNoKhach.Rows[row].Cells[3].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                labelNoKhachNoKhach_Text.Text = Convert.ToInt32(dataGridViewToaNoKhach.Rows[row].Cells[4].Value.ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                noKhach = Convert.ToInt32(dataGridViewToaNoKhach.Rows[row].Cells[4].Value.ToString());
            }
        }

        //HÀM CHO QUY ĐỊNH INPUT NGƯỜI DÙNG NHẬP VÀO textBoxTruNo
        private void textBoxTruNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //HÀM THAY ĐỔI TRẠNG THÁI TOA KHI NHẬP DỮ LIỆU VÀO textBoxTruNo
        private void textBoxTruNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTruNo.Text == "")
            {
                textBoxTruNo.Text = "0";
            }

            int TraNo = noKhach - Convert.ToInt32(textBoxTruNo.Text);
            if (TraNo <= 0)
            {
                textBoxTinhTrangNoKhach.Text = "Hết nợ";
            }

            if (TraNo > 0)
            {
                textBoxTinhTrangNoKhach.Text = "Còn nợ";
            }
        }

        //HÀM KHI CLICK VÀO NÚT CẬP NHẬT TOA NỢ KHÁCH
        private void buttonCapNhatNoKhach_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (textBoxTinhTrangNoKhach.Text == "Còn nợ")
            {
                string query = "update Toa set NoKhach = " + Convert.ToInt32(Convert.ToInt32(labelNoKhachNoKhach_Text.Text) + Convert.ToInt32(textBoxTruNo.Text)) + " where MaToa = " + Convert.ToInt32(labelMaToaKhachNo_Text.Text) + "";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            if (textBoxTinhTrangNoKhach.Text == "Hết nợ")
            {
                string query = "update Toa set NoKhach = 0 where MaToa = '" + labelMaToaNoKhach_Text.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            connection.Close();

            HienToaNoKhachMacDinh();
        }

        //HÀM KHI CLICK VÀO NÚT CHI TIẾT TOA
        private void buttonChiTietToa_Click(object sender, EventArgs e)
        {
            formChiTietToaHang f = new formChiTietToaHang();
            f.ShowDialog();
        }
    }
}
