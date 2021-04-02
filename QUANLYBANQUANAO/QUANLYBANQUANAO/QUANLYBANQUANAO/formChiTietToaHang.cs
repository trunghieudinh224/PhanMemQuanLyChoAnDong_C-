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
    public partial class formChiTietToaHang : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        public formChiTietToaHang()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienThongTin();

            ThongTinMua();

            ThongTinTra();
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

        //HÀM HIỆN THÔNG TIN TOA LÊN LABEL
        void HienThongTin()
        {
            connection.Open();
            labelIdToa_Text.Text = formQuanLyToa.ToaDuocChon;

            string query = "select MaToa, NgayLapToa, NhanVienLapToa, TenKhachHang, SDTKhachHang, TongToa, TienGiamGia, KhachNo, NoKhach, HinhThucThanhToan from Toa where MaToa = "+ Convert.ToInt32(formQuanLyToa.ToaDuocChon)+"";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            labelNhanVienLapToa_Text.Text = dt.Rows[0].ItemArray[2].ToString();
            labelNgay_Text.Text = dt.Rows[0].ItemArray[1].ToString();
            labelTenKhach_Text.Text = dt.Rows[0].ItemArray[3].ToString();
            labelSDT_Text.Text = dt.Rows[0].ItemArray[4].ToString();
            labelTongToaHang_Text.Text = Convert.ToInt32(dt.Rows[0].ItemArray[5].ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            int noKhach = Convert.ToInt32(dt.Rows[0].ItemArray[7].ToString());
            if (noKhach < 0)
            {
                labelKhachNo.Text = "Khách nợ:";
                labelKhachNo_Text.Text = noKhach.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            }
            else
            {
                labelKhachNo.Text = "Khách nợ:";
                labelKhachNo_Text.Text = "0 VND";
            }
            int khachNo = Convert.ToInt32(dt.Rows[0].ItemArray[8].ToString());
            if (khachNo < 0)
            {
                labelKhachNo.Text = "Nợ khách:";
                labelKhachNo_Text.Text = khachNo.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            }
            else
            {
                labelKhachNo.Text = "Nợ khách:";
                labelKhachNo_Text.Text = "0 VND";
            }
            labelThanhToan_Text.Text = dt.Rows[0].ItemArray[9].ToString();
            if (Convert.ToInt32(dt.Rows[0].ItemArray[6].ToString()) == 0)
            {
                labelGiamGia_Text.Text = "0 VND";
            }
            else
            {
                labelGiamGia_Text.Text = Convert.ToInt32(dt.Rows[0].ItemArray[6].ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            }
            connection.Close();
        }

        //HÀM HIỂN THỊ TOA MUA VÀ TỔNG GIÁ TRỊ TOA MUA
        void ThongTinMua()
        {
            connection.Open();

            string query = "select TenSP, SoLuong, GiaBan, ThanhTien from ChiTietToa where MaToa = " + Convert.ToInt32(formQuanLyToa.ToaDuocChon) + " and MuaTra = 'Mua'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewMua.DataSource = dt;
            string[] item = new string[200];
            int Mua = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j<dt.Columns.Count; j++)
                {
                    item[j] = dt.Rows[i].ItemArray[j].ToString();
                }

                var x = new ListViewItem(item);
                listViewMuaHang.Items.Add(x);
                Mua = Mua + Convert.ToInt32(listViewMuaHang.Items[i].SubItems[3].Text);
            }

            if (Mua != 0)
            {
                labelTongMua_Text.Text = Mua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            }

            connection.Close();
        }

        //HÀM HIỂN THỊ TOA TRẢ VÀ TỔNG GIÁ TRỊ TOA TRẢ
        void ThongTinTra()
        {
            connection.Open();

            string query = "select TenSP, SoLuong, GiaBan, ThanhTien from ChiTietToa where MaToa = " + Convert.ToInt32(formQuanLyToa.ToaDuocChon) + " and MuaTra = 'Trả'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewTra.DataSource = dt;
            string[] item = new string[200];
            int Tra = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    item[j] = dt.Rows[i].ItemArray[j].ToString();
                }

                var x = new ListViewItem(item);
                listViewTraHang.Items.Add(x);                           
                Tra = Tra + Convert.ToInt32(listViewTraHang.Items[i].SubItems[3].Text);
            }

            labelTongTra_Text.Text = Tra.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            connection.Close();
        }

        //HÀM KHI CLICK VÀO NÚT XÁC NHẬN
        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //HÀM KHI CLICK VÀO NÚT IN TOA
        private void buttonIn_Click(object sender, EventArgs e)
        {
            string Ngay = Convert.ToDateTime(labelNgay_Text.Text).ToString("ddMMyyyy");
            string filename = Application.StartupPath + "//Toa//" + labelIdToa_Text.Text + "_(" + labelTenKhach_Text.Text + ")_" + Ngay + ".pdf";
            System.Diagnostics.Process.Start(filename);
        }
    }
}
