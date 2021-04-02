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
    public partial class formDanhSachKhachHang : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();
        public static string LuaChonTuyChinh;

        public formDanhSachKhachHang()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            DSKH();
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

        //HÀM HIỂN THỊ DANH SÁCH KHÁCH HÀNG
        void DSKH()
        {
            connection.Open();

            string query = "select SDTKhachHang, HoTenKhachHang, DiaChiKhachHang from KhachHang where LoaiKhachHang = 'khachquen'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSKH.DataSource = dt;

            connection.Close();
        }

        //HÀM TÌM KIẾM THÔNG TIN KHÁCH HÀNG
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string KhachCanTim = textBoxTimKiem.Text;

            connection.Open();

            string query = "select SDTKhachHang, HoTenKhachHang, DiaChiKhachHang from KhachHang where SDTKhachHang like ('%" + KhachCanTim + "%') or HoTenKhachHang like ('%" + KhachCanTim + "%') or DiaChiKhachHang like ('%" + KhachCanTim + "%') and LoaiKhachHang = 'khachquen'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSKH.DataSource = dt;

            connection.Close();
        }

        public static string SDTKhachHang_HienTai;
        public static string TenKhachHang_HienTai;
        public static string DiaChiKhachHang_HienTai;
        //HÀM LẤY THÔNG TIN KHI CHỌN VÀO 1 KHÁCH HÀNG TRONG dataGridViewDSKH
        private void dataGridViewDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridViewDSKH.CurrentCell.RowIndex;

            if (row >= 0)
            {
                SDTKhachHang_HienTai = dataGridViewDSKH.Rows[row].Cells[0].Value.ToString();
                TenKhachHang_HienTai = dataGridViewDSKH.Rows[row].Cells[1].Value.ToString();
                DiaChiKhachHang_HienTai = dataGridViewDSKH.Rows[row].Cells[2].Value.ToString();
            }
        }

        //HÀM SỬA THÔNG TIN KHÁCH HÀNG
        private void dataGridViewDSKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LuaChonTuyChinh = "CapNhat";
            formChinhSuaThongTinKhachHang f = new formChinhSuaThongTinKhachHang();
            f.ShowDialog();
            DSKH();
        }

        //HÀM THÊM KHÁCH HÀNG MỚI
        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            LuaChonTuyChinh = "ThemMoi";
            formChinhSuaThongTinKhachHang f = new formChinhSuaThongTinKhachHang();
            f.ShowDialog();
            DSKH();
        }

        //HÀM XÓA KHÁCH HÀNG
        private void buttonXoaKhachHang_Click(object sender, EventArgs e)
        {
            if (SDTKhachHang_HienTai != "")
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa "+ TenKhachHang_HienTai + " khỏi danh sách ?", "Thông báo", MessageBoxButtons.OKCancel);

                //nếu người dùng đồng ý xóa khách hàng
                if (dlr == DialogResult.OK)
                {
                    //ẩn khách hàng
                    connection.Open();
                    string query = "update KhachHang set LoaiKhachHang = 'khachvanglai' where SDTKhachHang = '" + SDTKhachHang_HienTai + "'";
                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    DSKH();
                    pictureBoxXoaKhachHang.Visible = true;
                    timerXoaKhachHang.Start();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần xóa !!!", "Thông báo");
            }
        }

        public int TC_CheckXoaKhachHang = 0;
        //HÀM HIỂN THÔNG BÁO XÓA KHÁCH HÀNG THÀNH CÔNG
        private void timerXoaKhachHang_Tick(object sender, EventArgs e)
        {
            TC_CheckXoaKhachHang++;
            if (TC_CheckXoaKhachHang == 1)
            {
                timerXoaKhachHang.Stop();
                pictureBoxXoaKhachHang.Visible = false;
                timerXoaKhachHang.Enabled = false;
                TC_CheckXoaKhachHang = 0;
            }
        }
    }
}
