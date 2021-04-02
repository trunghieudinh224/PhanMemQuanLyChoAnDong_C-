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
    public partial class formQuanLyDoanhThuBanHang : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();

        //HÀM LOAD FORM
        public formQuanLyDoanhThuBanHang()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            AnPanel();

            HienThiMacDinh();
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

        //HÀM ẨN TẤT CẢ
        void AnPanel()
        {
            panelDoanhThuNgay.Visible = false;
            panelDoanhThuThang.Visible = false;
            panelNam.Visible = false;
        }

        //HIỂN THỊ MÀU NÚT VÀ ENABLE CÁC BUTTON
        void MauNut()
        {
            buttonDoanhThuTrongNgay.BackColor = Color.SandyBrown;
            buttonDoanhThuThang.BackColor = Color.SandyBrown;
            buttonNam.BackColor = Color.SandyBrown;
        }






        //----------CODE THỰC HIỆN CHO TAB DOANH THU THEO NGÀY----------
        //HÀM HIỂN THỊ MẶC ĐỊNH CỦA TAB DT THEO NGÀY
        void HienThiMacDinh()
        {
            dateTimePickerNgay1.Value = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
            panelDoanhThuNgay.Visible = true;
            buttonDoanhThuTrongNgay.BackColor = Color.SaddleBrown;

            HienThongTinLabel_Ngay();
            BieuDoTKSP();
        }

        public int SLToa_Ngay = 0, TongDT_Ngay = 0, GiamGia_Ngay = 0, KhachNo_Ngay = 0, NoKhach_Ngay = 0;
        //HIỂN THỊ THÔNG TIN DOANH THU (SỐ LƯỢNG TOA, TỔNG DOANH THU, TỔNG GIẢM GIÁ, KHÁCH NỢ, NỢ KHÁCH)
        void ThongTinLabelDoanhThuNgayBenTrai()
        {
            connection.Open();

            string query = "select TenKhachHang, TongToa, KhachNo, NoKhach, TienGiamGia from Toa where Day(NgayLapToa) = " + dateTimePickerNgay1.Value.Day.ToString() + "and Month(NgayLapToa) = " + dateTimePickerNgay1.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerNgay1.Value.Year.ToString() + "";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSTTN.DataSource = dt;
            dataGridViewDSTTN.Columns[0].Width = 120;
            dataGridViewDSTTN.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDSTTN.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDSTTN.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDSTTN.Columns[4].Visible = false;

            SLToa_Ngay = TongDT_Ngay = GiamGia_Ngay = KhachNo_Ngay = NoKhach_Ngay = 0;
            for (int i = 0; i < dataGridViewDSTTN.Rows.Count; i++)
            {
                SLToa_Ngay++;
                TongDT_Ngay = TongDT_Ngay + Convert.ToInt32(dataGridViewDSTTN.Rows[i].Cells[1].Value.ToString());
                GiamGia_Ngay = GiamGia_Ngay + Convert.ToInt32(dataGridViewDSTTN.Rows[i].Cells[4].Value.ToString());
                KhachNo_Ngay = KhachNo_Ngay + Convert.ToInt32(dataGridViewDSTTN.Rows[i].Cells[2].Value.ToString());
                NoKhach_Ngay = NoKhach_Ngay + Convert.ToInt32(dataGridViewDSTTN.Rows[i].Cells[3].Value.ToString());
            }

            connection.Close();
        }

        public int SLSPNhap_Ngay, TongTienNhapKho_Ngay = 0;
        //HÀM LẤY THÔNG TIN NHẬP KHO NGÀY
        void NhapKho_Ngay()
        {
            connection.Open();

            string querySLSPNhap = "select SoLuong from ChiTietHangNhap where MaPhieu in (select MaPhieu from HangNhap where Day(NgayNhap) = " + dateTimePickerNgay1.Value.Day.ToString() + "and Month(NgayNhap) = " + dateTimePickerNgay1.Value.Month.ToString() + "and Year(NgayNhap) = " + dateTimePickerNgay1.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(querySLSPNhap, connection);
            DataTable dtSLSPNhap = new DataTable();
            da.Fill(dtSLSPNhap);

            string queryTongTienNhapKho = "select TongPhieu from HangNhap where Day(NgayNhap) = " + dateTimePickerNgay1.Value.Day.ToString() + "and Month(NgayNhap) = " + dateTimePickerNgay1.Value.Month.ToString() + "and Year(NgayNhap) = " + dateTimePickerNgay1.Value.Year.ToString() + "";
            da = new OleDbDataAdapter(queryTongTienNhapKho, connection);
            DataTable dtTongTienNhapKho = new DataTable();
            da.Fill(dtTongTienNhapKho);

            SLSPNhap_Ngay = TongTienNhapKho_Ngay = 0;
            for (int i = 0; i < dtSLSPNhap.Rows.Count; i++)
            {
                SLSPNhap_Ngay = SLSPNhap_Ngay + Convert.ToInt32(dtSLSPNhap.Rows[i].ItemArray[0].ToString());
            }

            for (int i = 0; i < dtTongTienNhapKho.Rows.Count; i++)
            {
                TongTienNhapKho_Ngay = TongTienNhapKho_Ngay + Convert.ToInt32(dtTongTienNhapKho.Rows[i].ItemArray[0].ToString());
            }

            connection.Close();
        }

        public int SLSPtra_Ngay = 0;
        //SỐ LƯỢNG SẢN PHẨM KHÁCH TRẢ TRONG NGÀY
        void HangTra_Ngay()
        {
            SLSPtra_Ngay = 0;
            connection.Open();
            string querySLSPTra_Ngay = "select sum(SoLuong) from ChiTietToa where MuaTra = 'Trả' and MaToa in (select MaToa from Toa where Day(NgayLapToa) = " + dateTimePickerNgay1.Value.Day.ToString() + "and Month(NgayLapToa) = " + dateTimePickerNgay1.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerNgay1.Value.Year.ToString() + ") ";
            OleDbCommand cmdSLSPTra_Ngay = new OleDbCommand(querySLSPTra_Ngay, connection);

            if (cmdSLSPTra_Ngay.ExecuteScalar().ToString() != "")
            {
                SLSPtra_Ngay = Convert.ToInt32(cmdSLSPTra_Ngay.ExecuteScalar().ToString());
            }
            else
            {
                SLSPtra_Ngay = 0;
            }
            connection.Close();
        }

        public int GiaGoc_Ngay, GiaBan_Ngay, TongSLSPBan_Ngay, LaiTuSPban_Ngay = 0;
        //THỐNG KÊ SỐ LƯỢNG CÁC SẢN PHẨM ĐÃ BÁN TRONG NGÀY THEO THỨ TỰ GIẢM DẦN VÀ TÍNH LÃI TỪ SẢN PHẨM BÁN ĐƯỢC TRRONG NGÀY
        void BanHang_Ngay()
        {
            connection.Open();
            //lấy ra tên các sản phẩm đã bán trong ngày và thêm 1 cột column (Ten SP | Số lượng)
            string query = "select distinct TenSP from ChiTietToa where ChiTietToa.MuaTra = 'Mua' and MaToa in (select Toa.MaToa from Toa where Day(NgayLapToa) = " + dateTimePickerNgay1.Value.Day.ToString() + "and Month(NgayLapToa) = " + dateTimePickerNgay1.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerNgay1.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá gốc");
            dt.Columns.Add("Giá bán");
            dataGridViewTKSP1.DataSource = dt;

            //lấy thông tin số lượng các sản phẩm đã bán trong ngày từ chi tiết toa
            string querySL = "select TenSP, SoLuong from ChiTietToa where ChiTietToa.MuaTra = 'Mua' and MaToa in (select Toa.MaToa from Toa where Day(NgayLapToa) = " + dateTimePickerNgay1.Value.Day.ToString() + "and Month(NgayLapToa) = " + dateTimePickerNgay1.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerNgay1.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(querySL, connection);
            DataTable dtSL = new DataTable();
            da.Fill(dtSL);
            dataGridViewSL.DataSource = dtSL;

            //cộng tất cả số lượng ở bảng dataGridViewSL theo tên sản phẩm ở bảng dataGridViewTKSP1
            for (int i = 0; i < dataGridViewTKSP1.Rows.Count; i++)
            {
                int sl = 0;
                for (int j = 0; j < dataGridViewSL.Rows.Count; j++)
                {
                    if (dataGridViewSL.Rows[j].Cells[0].Value.ToString() == dataGridViewTKSP1.Rows[i].Cells[0].Value.ToString())
                    {
                        sl = sl + Convert.ToInt32(dataGridViewSL.Rows[j].Cells[1].Value.ToString());
                    }
                }
                dataGridViewTKSP1.Rows[i].Cells[1].Value = sl.ToString();
            }

            //sắp xếp sản phẩm ở bảng dataGridViewTKSP1 theo thứ tự giảm dần theo số lượng
            for (int n = 0; n < dataGridViewTKSP1.Rows.Count; n++)
            {
                if (n == dataGridViewTKSP1.Rows.Count - 1)
                {
                    dataGridViewTKSP1.Rows[n].Cells[1].Value = dataGridViewTKSP1.Rows[n].Cells[1].Value;
                    dataGridViewTKSP1.Rows[n].Cells[0].Value = dataGridViewTKSP1.Rows[n].Cells[0].Value;
                }
                else
                {
                    for (int m = n + 1; m < dataGridViewTKSP1.Rows.Count; m++)
                    {
                        if (Convert.ToInt32(dataGridViewTKSP1.Rows[n].Cells[1].Value.ToString()) < Convert.ToInt32(dataGridViewTKSP1.Rows[m].Cells[1].Value.ToString()))
                        {
                            string x = dataGridViewTKSP1.Rows[m].Cells[1].Value.ToString();
                            string y = dataGridViewTKSP1.Rows[m].Cells[0].Value.ToString();

                            dataGridViewTKSP1.Rows[m].Cells[1].Value = dataGridViewTKSP1.Rows[n].Cells[1].Value;
                            dataGridViewTKSP1.Rows[m].Cells[0].Value = dataGridViewTKSP1.Rows[n].Cells[0].Value;

                            dataGridViewTKSP1.Rows[n].Cells[1].Value = x;
                            dataGridViewTKSP1.Rows[n].Cells[0].Value = y;
                        }
                    }
                }
            }

            //lấy giá gốc và giá bán của các sản phẩm trong bảng dataGridViewTKSP1
            for (int i = 0; i < dataGridViewTKSP1.Rows.Count; i++)
            {
                string queryGiaGoc = "select GiaGoc from ChiTietToa where TenSP = '" + dataGridViewTKSP1.Rows[i].Cells[0].Value.ToString() + "'";
                OleDbCommand cmdGiaGoc = new OleDbCommand(queryGiaGoc, connection);
                dataGridViewTKSP1.Rows[i].Cells[2].Value = cmdGiaGoc.ExecuteScalar().ToString();

                string queryGiaBan = "select GiaBan from ChiTietToa where TenSP = '" + dataGridViewTKSP1.Rows[i].Cells[0].Value.ToString() + "'";
                OleDbCommand cmdGiaBan = new OleDbCommand(queryGiaBan, connection);
                dataGridViewTKSP1.Rows[i].Cells[3].Value = cmdGiaBan.ExecuteScalar().ToString();
            }
            connection.Close();

            //tính lãi từ sản phẩm bán được trong ngày
            GiaGoc_Ngay = GiaBan_Ngay = TongSLSPBan_Ngay = LaiTuSPban_Ngay = 0;
            for (int i = 0; i < dataGridViewTKSP1.Rows.Count; i++)
            {
                GiaGoc_Ngay = GiaGoc_Ngay + Convert.ToInt32(dataGridViewTKSP1.Rows[i].Cells[2].Value.ToString()) * Convert.ToInt32(dataGridViewTKSP1.Rows[i].Cells[1].Value.ToString());
                GiaBan_Ngay = GiaBan_Ngay + Convert.ToInt32(dataGridViewTKSP1.Rows[i].Cells[3].Value.ToString()) * Convert.ToInt32(dataGridViewTKSP1.Rows[i].Cells[1].Value.ToString());
                TongSLSPBan_Ngay = TongSLSPBan_Ngay + Convert.ToInt32(dataGridViewTKSP1.Rows[i].Cells[1].Value.ToString());
            }
            LaiTuSPban_Ngay = GiaBan_Ngay - GiaGoc_Ngay - GiamGia_Ngay;
        }

        //HIỆN TẤT CẢ THÔNG TIN LABEL TRONG TAB DOANH THU THEO NGÀY
        void HienThongTinLabel_Ngay()
        {
            ThongTinLabelDoanhThuNgayBenTrai();         
            NhapKho_Ngay();
            HangTra_Ngay();
            BanHang_Ngay();

            //các label bên trái
            labelSLToa_Text.Text = SLToa_Ngay.ToString() + " Toa";
            labelTongDoanhThu_Text.Text = TongDT_Ngay.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelTongGiamGia_Text.Text = GiamGia_Ngay.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelKhachNo_Text.Text = KhachNo_Ngay.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelNoKhach_Text.Text = NoKhach_Ngay.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            //các label bên phải
            labelSLSPNhapKho_Text.Text = SLSPNhap_Ngay.ToString() + " SP";
            if (TongTienNhapKho_Ngay != 0)
            {
                labelTongTienNhapKho_Text.Text = TongTienNhapKho_Ngay.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            }
            else
            {
                labelTongTienNhapKho_Text.Text = "0 VND";
            }
            labelSLSPKhachTra_Text.Text = SLSPtra_Ngay.ToString() + " SP";
            labelSLSPDaBan_Text.Text = TongSLSPBan_Ngay.ToString() + " SP";
            labelSLSPNhapKho_Text.Text = SLSPNhap_Ngay.ToString() + " SP";
            if (TongTienNhapKho_Ngay != 0)
            {
                labelTongTienNhapKho_Text.Text = TongTienNhapKho_Ngay.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            }
            else
            {
                labelTongTienNhapKho_Text.Text = "0 VND";
            }
            labelLaiTuSPBanDuoc_Text.Text = (GiaBan_Ngay - GiaGoc_Ngay - GiamGia_Ngay).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
        }

        //ĐIỀU CHỈNH SIZE PANEL THEO TỈ LỆ SỐ LƯỢNG SẢN PHẨM
        void ThayDoiSizePanelNgay(Panel pn1, Panel pn2, Panel pn3, Panel pn4, Label lb1, Label lb2, Label lb3, Label lb4)
        {
            if (lb1.Text != "")
            {
                pn1.Size = new Size(panelNgayMau.Size.Width, panelNgayMau.Size.Height);
            }
            else
            {
                pn1.Size = new Size(0, 0);
            }
            
            if (lb2.Text != "")
            {
                double sizesp2 = Convert.ToDouble(lb2.Text) / Convert.ToDouble(lb1.Text);
                sizesp2 = panelNgayMau.Size.Width * sizesp2;
                pn2.Size = new Size(Convert.ToInt32(sizesp2), panelNgayMau.Height);
            }
            else
            {
                pn2.Size = new Size(0, 0);
            }

            if (lb3.Text != "")
            {
                double sizesp3 = Convert.ToDouble(lb3.Text) / Convert.ToDouble(lb1.Text);
                sizesp3 = panelNgayMau.Size.Width * sizesp3;
                pn3.Size = new Size(Convert.ToInt32(sizesp3), panelNgayMau.Height);
            }
            else
            {
                pn3.Size = new Size(0, 0);
            }

            if (lb4.Text != "")
            {
                double sizesp4 = Convert.ToDouble(lb4.Text) / Convert.ToDouble(lb1.Text);
                sizesp4 = panelNgayMau.Size.Width * sizesp4;
                pn4.Size = new Size(Convert.ToInt32(sizesp4), panelNgayMau.Height);
            }
            else
            {
                pn4.Size = new Size(0, 0);
            }

            pn1.BackColor = Color.LightBlue;
            pn2.BackColor = Color.LightBlue;
            pn3.BackColor = Color.LightBlue;
            pn4.BackColor = Color.LightBlue;
        }

        //HIỂN THỊ CÁC THÔNG TIN TRONG BIỂU ĐỒ THỐNG KÊ
        void BieuDoTKSP()
        {
            //trường hợp không có sản phẩm nào
            if (dataGridViewTKSP1.Rows.Count == 0)
            {

                labelsp1.Text = labelsp2.Text = labelsp3.Text = labelsp4.Text = "...";

                labelSLsp1.Text = labelSLsp2.Text = labelSLsp3.Text = labelSLsp4.Text = "";

                labelChuThichTKSP1.Text = "Không có sản phẩm nào.";
            }
            //trường hợp có ít nhất 1 sản phẩm
            else if (dataGridViewTKSP1.Rows.Count == 1)
            {
                labelsp1.Text = "_" + dataGridViewTKSP1.Rows[0].Cells[0].Value.ToString();
                labelsp2.Text = "...";
                labelsp3.Text = "...";
                labelsp4.Text = "...";

                labelSLsp1.Text = dataGridViewTKSP1.Rows[0].Cells[1].Value.ToString();
                labelSLsp2.Text = labelSLsp3.Text = labelSLsp4.Text = "";

                labelChuThichTKSP1.Text = "Sản phẩm bán duy nhất.";
            }
            //trường hợp có 2 sản phẩm
            else if (dataGridViewTKSP1.Rows.Count == 2)
            {
                labelsp1.Text = "_" + dataGridViewTKSP1.Rows[0].Cells[0].Value.ToString();
                labelsp2.Text = "_" + dataGridViewTKSP1.Rows[1].Cells[0].Value.ToString();
                labelsp3.Text = labelsp4.Text = "";

                labelSLsp1.Text = dataGridViewTKSP1.Rows[0].Cells[1].Value.ToString();
                labelSLsp2.Text = dataGridViewTKSP1.Rows[1].Cells[1].Value.ToString();
                labelSLsp3.Text = "";
                labelSLsp4.Text = "";

                labelChuThichTKSP1.Text = "2 sản phẩm bán chạy nhất."; 
            }
            //trường hợp có 3 sản phẩm
            else if (dataGridViewTKSP1.Rows.Count == 3)
            {
                labelsp1.Text = "_" + dataGridViewTKSP1.Rows[0].Cells[0].Value.ToString();
                labelsp2.Text = "_" + dataGridViewTKSP1.Rows[1].Cells[0].Value.ToString();
                labelsp3.Text = "_" + dataGridViewTKSP1.Rows[2].Cells[0].Value.ToString();
                labelsp4.Text = "...";

                labelSLsp1.Text = dataGridViewTKSP1.Rows[0].Cells[1].Value.ToString();
                labelSLsp2.Text = dataGridViewTKSP1.Rows[1].Cells[1].Value.ToString();
                labelSLsp3.Text = dataGridViewTKSP1.Rows[1].Cells[1].Value.ToString();
                labelSLsp4.Text = "";

                labelChuThichTKSP1.Text = "3 sản phẩm bán chạy nhất.";        
            }
            //trường hợp có 4 sản phẩm
            else if (dataGridViewTKSP1.Rows.Count > 3)
            {
                labelsp1.Text = "_" + dataGridViewTKSP1.Rows[0].Cells[0].Value.ToString();
                labelsp2.Text = "_" + dataGridViewTKSP1.Rows[1].Cells[0].Value.ToString();
                labelsp3.Text = "_" + dataGridViewTKSP1.Rows[2].Cells[0].Value.ToString();
                labelsp4.Text = "_" + dataGridViewTKSP1.Rows[3].Cells[0].Value.ToString();

                labelSLsp1.Text = dataGridViewTKSP1.Rows[0].Cells[1].Value.ToString();
                labelSLsp2.Text = dataGridViewTKSP1.Rows[1].Cells[1].Value.ToString();
                labelSLsp3.Text = dataGridViewTKSP1.Rows[2].Cells[1].Value.ToString();
                labelSLsp4.Text = dataGridViewTKSP1.Rows[3].Cells[1].Value.ToString();

                labelChuThichTKSP1.Text = "4 sản phẩm bán chạy nhất.";
            }

            ThayDoiSizePanelNgay(panelsp1, panelsp2, panelsp3, panelsp4, labelSLsp1, labelSLsp2, labelSLsp3, labelSLsp4);
        }

        //SỰ KIỆN KHI NHẤN VÀO NÚT "DOANH THU TRONG NGÀY"
        private void buttonDoanhThuTrongNgay_Click(object sender, EventArgs e)
        {
            MauNut();
            AnPanel();
            panelDoanhThuNgay.Visible = true;
            buttonDoanhThuTrongNgay.BackColor = Color.SaddleBrown;

            HienThongTinLabel_Ngay();
            BieuDoTKSP();
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX THỐNG KÊ SẢN PHẨM THEO NGÀY
        private void groupBoxTKSP1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 220, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }
               
        //HÀM THAY ĐỔI DỮ LIỆU KHI THAY ĐỔI THỜI GIAN (THEO NGÀY)
        private void dateTimePickerNgay1_ValueChanged(object sender, EventArgs e)
        {
            HienThongTinLabel_Ngay();
            BieuDoTKSP();
        }







        //----------CODE THỰC HIỆN CHO TAB DOANH THU THEO THÁNG----------
        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX THỐNG KÊ SẢN PHẨM THEO THÁNG
        private void groupBoxTongKetThang_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 188, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        //SỰ KIỆN KHI NHẤN VÀO NÚT "DOANH THU THEO THÁNG"
        private void buttonDoanhThuThang_Click(object sender, EventArgs e)
        {
            dateTimePickerThang.Value = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
            MauNut();
            AnPanel();
            panelDoanhThuThang.Visible = true;
            buttonDoanhThuThang.BackColor = Color.SaddleBrown;

            HienThongTinTongKetThang();    
        }
        
        public int SLSPDaBan, TongTienGiaGoc, TongTienGiaBan, LaiTuSPBanDuocTrongThang = 0;
        //HÀM SẮP XẾP CÁC SẢN PHẨM ĐÃ BÁN GIẢM DẦN THEO SỐ LƯỢNG, HIỂN THỊ SLSP ĐÃ BÁN & TIỀN LÃI TỪ SP BÁN 
        void BanHangThang()
        {
            TongTienGiaGoc = 0; TongTienGiaBan = 0; SLSPDaBan = 0;
            connection.Open();

            //lấy ra tên các sản phẩm đã bán trong tháng và thêm 1 cột column (Ten SP | Số lượng)
            string query = "select distinct TenSP from ChiTietToa where ChiTietToa.MuaTra = 'Mua' and MaToa in (select Toa.MaToa from Toa where Month(NgayLapToa) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerThang.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá gốc");
            dt.Columns.Add("Giá bán");
            dataGridViewThang.DataSource = dt;

            //lấy thông tin số lượng các sản phẩm đã bán trong tháng từ chi tiết toa
            string querySL = "select TenSP, SoLuong from ChiTietToa where ChiTietToa.MuaTra = 'Mua' and MaToa in (select Toa.MaToa from Toa where Month(NgayLapToa) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerThang.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(querySL, connection);
            DataTable dtSL = new DataTable();
            da.Fill(dtSL);

            connection.Close();

            if (dt.Rows.Count > 0)
            {
                //cộng tất cả số lượng của từng sản phẩm ở datatable dtSL rồi chuyển sang vào dataGridViewHangTra tương ứng theo tên
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sl = 0;
                    for (int j = 0; j < dtSL.Rows.Count; j++)
                    {
                        if (dtSL.Rows[j].ItemArray[0].ToString() == dt.Rows[i].ItemArray[0].ToString())
                        {
                            sl = sl + Convert.ToInt32(dtSL.Rows[j].ItemArray[1].ToString());
                        }
                    }
                    dataGridViewThang.Rows[i].Cells[1].Value = sl.ToString();
                    SLSPDaBan = SLSPDaBan + sl;
                }

                //Sắp xếp số lượng các sản phẩm đã bán theo thứ tự giảm dần
                for (int n = 0; n < dataGridViewThang.Rows.Count; n++)
                {
                    if (n == dataGridViewThang.Rows.Count - 1)
                    {
                        dataGridViewThang.Rows[n].Cells[1].Value = dataGridViewThang.Rows[n].Cells[1].Value;
                        dataGridViewThang.Rows[n].Cells[0].Value = dataGridViewThang.Rows[n].Cells[0].Value;
                    }
                    else
                    {
                        for (int m = n + 1; m < dataGridViewThang.Rows.Count; m++)
                        {
                            if (Convert.ToInt32(dataGridViewThang.Rows[n].Cells[1].Value.ToString()) < Convert.ToInt32(dataGridViewThang.Rows[m].Cells[1].Value.ToString()))
                            {
                                string x = dataGridViewThang.Rows[m].Cells[1].Value.ToString();
                                string y = dataGridViewThang.Rows[m].Cells[0].Value.ToString();

                                dataGridViewThang.Rows[m].Cells[1].Value = dataGridViewThang.Rows[n].Cells[1].Value;
                                dataGridViewThang.Rows[m].Cells[0].Value = dataGridViewThang.Rows[n].Cells[0].Value;

                                dataGridViewThang.Rows[n].Cells[1].Value = x;
                                dataGridViewThang.Rows[n].Cells[0].Value = y;
                            }
                        }
                    }
                }

                //tính slsp đã bán và tiền lãi từ sản phẩm bán được     
                for (int i = 0; i < dataGridViewThang.Rows.Count; i++)
                {
                    connection.Open();
                    string queryGiaGoc = "select GiaGoc from SanPham where TenSP = '" + dataGridViewThang.Rows[i].Cells[0].Value.ToString() + "'";
                    OleDbCommand cmdGiaGoc = new OleDbCommand(queryGiaGoc, connection);
                    dataGridViewThang.Rows[i].Cells[2].Value = cmdGiaGoc.ExecuteScalar().ToString();

                    string queryGiaBan = "select GiaBan from SanPham where TenSP = '" + dataGridViewThang.Rows[i].Cells[0].Value.ToString() + "'";
                    OleDbCommand cmdGiaBan = new OleDbCommand(queryGiaBan, connection);
                    dataGridViewThang.Rows[i].Cells[3].Value = cmdGiaBan.ExecuteScalar().ToString();
                    connection.Close();

                    TongTienGiaGoc = TongTienGiaGoc + Convert.ToInt32(dataGridViewThang.Rows[i].Cells[1].Value.ToString()) * Convert.ToInt32(dataGridViewThang.Rows[i].Cells[2].Value.ToString());
                    TongTienGiaBan = TongTienGiaBan + Convert.ToInt32(dataGridViewThang.Rows[i].Cells[1].Value.ToString()) * Convert.ToInt32(dataGridViewThang.Rows[i].Cells[3].Value.ToString());
                }

                LaiTuSPBanDuocTrongThang = TongTienGiaBan - TongTienGiaGoc;  
                labelSLSPDaBanTrongThang_Text.Text = SLSPDaBan.ToString();
                labelLaiTuSPBanDuocTrongThang_Text.Text = LaiTuSPBanDuocTrongThang.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
            else
            {
                LaiTuSPBanDuocTrongThang = 0;
                labelSLSPDaBanTrongThang_Text.Text = "0";
                labelLaiTuSPBanDuocTrongThang_Text.Text = "0";
            }
        }

        public int TienLaiSPKhachTra, TienHangKhachTra, GiaGocTienHang, TongSLKhachTra = 0;
        //HÀM TÍNH SỐ TIỀN LỜI TỪ HÀNG TRẢ CỦA KHÁCH
        void TraHangThang()
        {
            TienLaiSPKhachTra = 0; TienHangKhachTra = 0; GiaGocTienHang = 0; TongSLKhachTra = 0;
            connection.Open();

            //lấy ra tên các sản phẩm khách trả trong tháng và thêm 1 cột column (Ten SP | Số lượng)
            string query = "select distinct TenSP from ChiTietToa where ChiTietToa.MuaTra = 'Trả' and MaToa in (select Toa.MaToa from Toa where Month(NgayLapToa) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerThang.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Số lượng");
            dt.Columns.Add("Giá gốc");
            dt.Columns.Add("Giá bán");
            dataGridViewHangTra.DataSource = dt;

            //lấy thông tin số lượng các sản phẩm khách trả trong tháng từ chi tiết toa
            string querySL = "select TenSP, SoLuong from ChiTietToa where ChiTietToa.MuaTra = 'Trả' and MaToa in (select Toa.MaToa from Toa where Month(NgayLapToa) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerThang.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(querySL, connection);
            DataTable dtSL = new DataTable();
            da.Fill(dtSL);

            connection.Close();

            
            if (dtSL.Rows.Count > 0)
            {
                //cộng tất cả số lượng của từng sản phẩm ở datatable dtSL rồi chuyển sang vào dataGridViewHangTra tương ứng theo tên
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sl = 0, giaGoc = 0, giaBan = 0;
                    for (int j = 0; j < dtSL.Rows.Count; j++)
                    {
                        if (dtSL.Rows[j].ItemArray[0].ToString() == dt.Rows[i].ItemArray[0].ToString())
                        {
                            connection.Open();
                            sl = sl + Convert.ToInt32(dtSL.Rows[j].ItemArray[1].ToString());

                            string queryGiaGoc = "select GiaGoc from ChiTietToa where TenSP = '" + dtSL.Rows[j].ItemArray[0].ToString() + "'";
                            OleDbCommand cmdGiaGoc = new OleDbCommand(queryGiaGoc, connection);
                            giaGoc = Convert.ToInt32(cmdGiaGoc.ExecuteScalar().ToString());

                            string queryGiaBan = "select GiaBan from ChiTietToa where TenSP = '" + dtSL.Rows[j].ItemArray[0].ToString() + "'";
                            OleDbCommand cmdGiaBan = new OleDbCommand(queryGiaBan, connection);
                            giaBan = Convert.ToInt32(cmdGiaBan.ExecuteScalar().ToString());
                            connection.Close();
                        }
                    }
                    dataGridViewHangTra.Rows[i].Cells[1].Value = sl.ToString();
                    dataGridViewHangTra.Rows[i].Cells[2].Value = giaGoc.ToString();
                    dataGridViewHangTra.Rows[i].Cells[3].Value = giaBan.ToString();
                }

                //Tính số tiền lãi của lượng hàng khách trả (dùng để trừa vào lợi nhuận)
                for (int i = 0; i < dataGridViewHangTra.Rows.Count; i++)
                {
                    TienHangKhachTra = TienHangKhachTra + Convert.ToInt32(dataGridViewHangTra.Rows[i].Cells[3].Value.ToString()) * Convert.ToInt32(dataGridViewHangTra.Rows[i].Cells[1].Value.ToString());
                    TongSLKhachTra = TongSLKhachTra + Convert.ToInt32(dataGridViewHangTra.Rows[i].Cells[1].Value.ToString());
                    GiaGocTienHang = GiaGocTienHang + Convert.ToInt32(dataGridViewHangTra.Rows[i].Cells[1].Value.ToString()) * Convert.ToInt32(dataGridViewHangTra.Rows[i].Cells[2].Value.ToString());
                }
                TienLaiSPKhachTra = TienHangKhachTra - GiaGocTienHang;
            }     
        }

        public int TongLuongNhanVienThang = 0;
        //LẤY TỔNG LƯƠNG NHÂN VIÊN TRONG THÁNG
        void LuongNhanVienThang()
        {
            TongLuongNhanVienThang = 0;
            connection.Open();

            string query = "select sum(TongLuong) from GioCongVaLuongNhanVien where Nam = "+ Convert.ToInt32(dateTimePickerThang.Value.Year.ToString()) + " and Thang = " + Convert.ToInt32(dateTimePickerThang.Value.Month.ToString()) + "";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            if (cmd.ExecuteScalar().ToString() != "0" && cmd.ExecuteScalar().ToString() != "")
            {
                TongLuongNhanVienThang = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                labelTongLuongNV_Text.Text = TongLuongNhanVienThang.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
            else
            {
                labelTongLuongNV_Text.Text = "0";
            }

            connection.Close();
        }

        public int SLToaThang, TongToaThang, KhachNoThang, NoKhachThang = 0;
        //HIỆN THÔNG TIN CÁC LABEL DOANH THU THÁNG BÊN TRÁI
        void HienThongTinTongKetThang_CacLabelBenTrai()
        {
            SLToaThang = 0; TongToaThang = 0; KhachNoThang = 0; NoKhachThang = 0;
            connection.Open();

            string query = "select MaToa, TongToa, KhachNo, NoKhach from Toa where Month(NgayLapToa) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerThang.Value.Year.ToString() + "";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SLToaThang++;
                    TongToaThang = TongToaThang + Convert.ToInt32(dt.Rows[i].ItemArray[1].ToString());
                    KhachNoThang = KhachNoThang + Convert.ToInt32(dt.Rows[i].ItemArray[2].ToString());
                    NoKhachThang = NoKhachThang + Convert.ToInt32(dt.Rows[i].ItemArray[3].ToString());
                }

                labelSLToaTrongThang_Text.Text = SLToaThang.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                labelTongDoanhThuTrongThang_Text.Text = TongToaThang.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");   
            }
            else
            {
                labelSLToaTrongThang_Text.Text = "0";
                labelTongDoanhThuTrongThang_Text.Text = "0";
            }

            if (KhachNoThang == 0 && NoKhachThang != 0)
            {
                labelKhachNoNoKhachTrongThang_Text.Text = "0" + "/" + Math.Abs(NoKhachThang).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
            else if (KhachNoThang != 0 && NoKhachThang == 0)
            {
                labelKhachNoNoKhachTrongThang_Text.Text = Math.Abs(KhachNoThang).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + "/" + "0";
            }
            else if (KhachNoThang == 0 && NoKhachThang == 0)
            {
                labelKhachNoNoKhachTrongThang_Text.Text = "0/0";
            }
            else
            {
                labelKhachNoNoKhachTrongThang_Text.Text = Math.Abs(KhachNoThang).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + "/" + Math.Abs(NoKhachThang).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
            connection.Close();

            LuongNhanVienThang();
        }
        
        public int SLSPNhap, TongTienNhapKho = 0;
        //THÔNG TIN NHẬP KHO THÁNG
        void NhapKhoThang()
        {
            SLSPNhap = 0; TongTienNhapKho = 0;
            connection.Open();
            string querySLSPNhap = "select SoLuong from ChiTietHangNhap where MaPhieu in (select MaPhieu from HangNhap where Month(NgayNhap) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayNhap) = " + dateTimePickerThang.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(querySLSPNhap, connection);
            DataTable dtSLSPNhap = new DataTable();
            da.Fill(dtSLSPNhap);

            string queryTongTienNhapKho = "select TongPhieu from HangNhap where Month(NgayNhap) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayNhap) = " + dateTimePickerThang.Value.Year.ToString() + "";
            da = new OleDbDataAdapter(queryTongTienNhapKho, connection);
            DataTable dtTongTienNhapKho = new DataTable();
            da.Fill(dtTongTienNhapKho);

            if (dtSLSPNhap.Rows.Count > 0)
            {
                for (int i = 0; i < dtSLSPNhap.Rows.Count; i++)
                {
                    SLSPNhap = SLSPNhap + Convert.ToInt32(dtSLSPNhap.Rows[i].ItemArray[0].ToString());
                }

                for (int i = 0; i < dtTongTienNhapKho.Rows.Count; i++)
                {
                    TongTienNhapKho = TongTienNhapKho + Convert.ToInt32(dtTongTienNhapKho.Rows[i].ItemArray[0].ToString());
                }

                labelSLSPNhapKhoTrongThang_Text.Text = SLSPNhap.ToString();
                labelTongTienNhapKhoTrongThang_Text.Text = TongTienNhapKho.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
            else
            {
                labelSLSPNhapKhoTrongThang_Text.Text = labelTongTienNhapKhoTrongThang_Text.Text = "0";
            }
            
            connection.Close();
        }

        public int TongGiamGia = 0;
        //HIỆN THÔNG TIN CÁC LABEL DOANH THU THÁNG BÊN PHẢI
        void HienThongTinTongKetThang_CacLabelBenPhai()
        {
            TongGiamGia = 0;
            NhapKhoThang();
            TraHangThang();

            connection.Open();
            string queryTongGiamGia = "select sum(TienGiamGia) from Toa where Month(NgayLapToa) = " + dateTimePickerThang.Value.Month.ToString() + "and Year(NgayLapToa) = " + dateTimePickerThang.Value.Year.ToString() + "";
            OleDbCommand cmdTongGiamGia = new OleDbCommand(queryTongGiamGia, connection);
            if (cmdTongGiamGia.ExecuteScalar().ToString() != "")
            {
                TongGiamGia = Convert.ToInt32(cmdTongGiamGia.ExecuteScalar().ToString());
                labelTongGiamGiaThang_Text.Text = TongGiamGia.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            }
            else
            {
                labelTongGiamGiaThang_Text.Text = "0";
            }
            
            connection.Close();
            
            labelSLSPKhachTraThang_Text.Text = TongSLKhachTra.ToString();
            BanHangThang();
        }

        //HIỆN THÔNG TIN CÁC LABEL DOANH THU TỔNG KẾT THÁNG
        void HienThongTinTongKetThang()
        {
            HienThongTinTongKetThang_CacLabelBenTrai();
            HienThongTinTongKetThang_CacLabelBenPhai();
            labelLoiNhuan_Text.Text = (LaiTuSPBanDuocTrongThang - TongTienNhapKho - TongLuongNhanVienThang - TienLaiSPKhachTra - TongGiamGia).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
        }

        //HIỆN MÀU PANEL MẶC ĐỊNH (DarkCyan)
        void MauPanelThangMacDinh()
        {
            panelsp1T.BackColor = panelsp1T.BackColor = panelsp1T.BackColor = panelsp1T.BackColor = panelsp1T.BackColor = panelsp1T.BackColor = Color.DarkCyan;
        }

        //HIỆN THÔNG TIN 6 SẢN PHẨM BÁN CHẠY NHẤT TRONG THÁNG (SỐ LƯỢNG, PANEL, TÊN SP)
        void HienThiSLSanPhamThang(Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Panel pn1, Panel pn2, Panel pn3, Panel pn4, Panel pn5, Panel pn6)
        {
            lb1.Visible = lb2.Visible = lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = true;      //mặc định hiển thị label slsp là true
            pn1.Visible = pn2.Visible = pn3.Visible = pn4.Visible = pn5.Visible = pn6.Visible = true;      //mặc định hiển thị panel slsp là true
            labelsp1Thang.Visible = labelsp2Thang.Visible = labelsp3Thang.Visible = labelsp4Thang.Visible = labelsp5Thang.Visible = labelsp6Thang.Visible = true;
            if (dataGridViewThang.Rows.Count == 0)
            {
                lb1.Text = lb2.Text = lb3.Text = lb4.Text = lb5.Text = lb6.Text = "1";  
                labelsp1Thang.Text = labelsp2Thang.Text = labelsp3Thang.Text = labelsp4Thang.Text = labelsp5Thang.Text = labelsp6Thang.Text = "...";
                lb1.Visible = lb2.Visible = lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = false;
                pn1.Visible = pn2.Visible = pn3.Visible = pn4.Visible = pn5.Visible = pn6.Visible = false;
            }
            else if (dataGridViewThang.Rows.Count == 1)
            {
                lb1.Text = dataGridViewThang.Rows[0].Cells[1].Value.ToString();
                lb2.Text = lb3.Text = lb4.Text = lb5.Text = lb6.Text = "1";
                labelsp1Thang.Text = dataGridViewThang.Rows[0].Cells[0].Value.ToString();
                labelsp2Thang.Text = labelsp3Thang.Text = labelsp4Thang.Text = labelsp5Thang.Text = labelsp6Thang.Text = "...";
                lb2.Visible = lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = false;
                pn2.Visible = pn3.Visible = pn4.Visible = pn5.Visible = pn6.Visible = false;
            }
            else if (dataGridViewThang.Rows.Count == 2)
            {
                lb1.Text = dataGridViewThang.Rows[0].Cells[1].Value.ToString();
                lb2.Text = dataGridViewThang.Rows[1].Cells[1].Value.ToString();
                lb3.Text = lb4.Text = lb5.Text = lb6.Text = "1";
                labelsp1Thang.Text = dataGridViewThang.Rows[0].Cells[0].Value.ToString();
                labelsp2Thang.Text = dataGridViewThang.Rows[1].Cells[0].Value.ToString();
                labelsp3Thang.Text = labelsp4Thang.Text = labelsp5Thang.Text = labelsp6Thang.Text = "...";
                lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = false;
                pn3.Visible = pn4.Visible = pn5.Visible = pn6.Visible = false;
            }
            else if (dataGridViewThang.Rows.Count == 3)
            {
                lb1.Text = dataGridViewThang.Rows[0].Cells[1].Value.ToString();
                lb2.Text = dataGridViewThang.Rows[1].Cells[1].Value.ToString();
                lb3.Text = dataGridViewThang.Rows[2].Cells[1].Value.ToString();
                lb4.Text = lb5.Text = lb6.Text = "1";
                labelsp1Thang.Text = dataGridViewThang.Rows[0].Cells[0].Value.ToString();
                labelsp2Thang.Text = dataGridViewThang.Rows[1].Cells[0].Value.ToString();
                labelsp3Thang.Text = dataGridViewThang.Rows[2].Cells[0].Value.ToString();
                labelsp4Thang.Text = labelsp5Thang.Text = labelsp6Thang.Text = "...";
                lb4.Visible = lb5.Visible = lb6.Visible = false;
                pn4.Visible = pn5.Visible = pn6.Visible = false;
            }
            else if (dataGridViewThang.Rows.Count == 4)
            {
                lb1.Text = dataGridViewThang.Rows[0].Cells[1].Value.ToString();
                lb2.Text = dataGridViewThang.Rows[1].Cells[1].Value.ToString();
                lb3.Text = dataGridViewThang.Rows[2].Cells[1].Value.ToString();
                lb4.Text = dataGridViewThang.Rows[3].Cells[1].Value.ToString();
                lb5.Text = lb6.Text = "1";
                labelsp1Thang.Text = dataGridViewThang.Rows[0].Cells[0].Value.ToString();
                labelsp2Thang.Text = dataGridViewThang.Rows[1].Cells[0].Value.ToString();
                labelsp3Thang.Text = dataGridViewThang.Rows[2].Cells[0].Value.ToString();
                labelsp4Thang.Text = dataGridViewThang.Rows[3].Cells[0].Value.ToString();
                labelsp5Thang.Text = labelsp6Thang.Text = "...";
                lb5.Visible = lb6.Visible = false;
                pn5.Visible = pn6.Visible = false;
            }
            else if (dataGridViewThang.Rows.Count == 5)
            {
                lb1.Text = dataGridViewThang.Rows[0].Cells[1].Value.ToString();
                lb2.Text = dataGridViewThang.Rows[1].Cells[1].Value.ToString();
                lb3.Text = dataGridViewThang.Rows[2].Cells[1].Value.ToString();
                lb4.Text = dataGridViewThang.Rows[3].Cells[1].Value.ToString();
                lb5.Text = dataGridViewThang.Rows[4].Cells[1].Value.ToString();
                lb6.Text = "1";
                labelsp1Thang.Text = dataGridViewThang.Rows[0].Cells[0].Value.ToString();
                labelsp2Thang.Text = dataGridViewThang.Rows[1].Cells[0].Value.ToString();
                labelsp3Thang.Text = dataGridViewThang.Rows[2].Cells[0].Value.ToString();
                labelsp4Thang.Text = dataGridViewThang.Rows[3].Cells[0].Value.ToString();
                labelsp5Thang.Text = dataGridViewThang.Rows[4].Cells[0].Value.ToString();
                labelsp6Thang.Text = "...";
                lb6.Visible = false;
                pn6.Visible = false;
            }
            else
            {
                lb1.Text = dataGridViewThang.Rows[0].Cells[1].Value.ToString();
                lb2.Text = dataGridViewThang.Rows[1].Cells[1].Value.ToString();
                lb3.Text = dataGridViewThang.Rows[2].Cells[1].Value.ToString();
                lb4.Text = dataGridViewThang.Rows[3].Cells[1].Value.ToString();
                lb5.Text = dataGridViewThang.Rows[4].Cells[1].Value.ToString();
                lb6.Text = dataGridViewThang.Rows[5].Cells[1].Value.ToString();
                labelsp1Thang.Text = dataGridViewThang.Rows[0].Cells[0].Value.ToString();
                labelsp2Thang.Text = dataGridViewThang.Rows[1].Cells[0].Value.ToString();
                labelsp3Thang.Text = dataGridViewThang.Rows[2].Cells[0].Value.ToString();
                labelsp4Thang.Text = dataGridViewThang.Rows[3].Cells[0].Value.ToString();
                labelsp5Thang.Text = dataGridViewThang.Rows[4].Cells[0].Value.ToString();
                labelsp6Thang.Text = dataGridViewThang.Rows[5].Cells[0].Value.ToString();
            }
        }

        //VỊ TRÍ PANEL SLSP THÁNG MẶC ĐỊNH
        void ViTriVaSizePanelThangMacDinh()
        {
            panelThang1.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);
            panelThang2.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);
            panelThang3.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);
            panelThang4.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);
            panelThang5.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);
            panelThang6.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);

            panelsp2T.Location = new Point(panelsp2T.Location.X, panelsp1T.Location.Y);
            panelsp3T.Location = new Point(panelsp3T.Location.X, panelsp1T.Location.Y);
            panelsp4T.Location = new Point(panelsp4T.Location.X, panelsp1T.Location.Y);
            panelsp5T.Location = new Point(panelsp5T.Location.X, panelsp1T.Location.Y);
            panelsp6T.Location = new Point(panelsp6T.Location.X, panelsp1T.Location.Y);

        }

        //HÀM ĐIỀU CHỈNH SIZE PANEL SLSP THÁNG THEO TỈ LỆ SỐ LƯỢNG
        void SizePanelThang(Panel pn1, Panel pn2, Panel pn3, Panel pn4, Panel pn5, Panel pn6, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6)
        {
            ViTriVaSizePanelThangMacDinh();
            int chieuCaoPanel = 0;
            pn1.Size = new Size(panelThangMau.Size.Width, panelThangMau.Size.Height);

            chieuCaoPanel = Convert.ToInt32(panelThangMau.Size.Height * (Convert.ToDouble(lb2.Text) / Convert.ToDouble(lb1.Text)));
            pn2.Size = new Size(panelThangMau.Size.Width, chieuCaoPanel);
            pn2.Location = new Point(pn2.Location.X, pn2.Location.Y + (panelThangMau.Size.Height - pn2.Size.Height));
            labelSLsp2T.Location = new Point(labelSLsp2T.Location.X, labelSLsp1T.Location.Y + (panelThangMau.Size.Height - pn2.Size.Height));

            chieuCaoPanel = Convert.ToInt32(panelThangMau.Size.Height * (Convert.ToDouble(lb3.Text) / Convert.ToDouble(lb1.Text)));
            pn3.Size = new Size(panelThangMau.Size.Width, chieuCaoPanel);
            pn3.Location = new Point(pn3.Location.X, pn3.Location.Y + (panelThangMau.Size.Height - pn3.Size.Height));
            labelSLsp3T.Location = new Point(labelSLsp3T.Location.X, labelSLsp1T.Location.Y + (panelThangMau.Size.Height - pn3.Size.Height));

            chieuCaoPanel = Convert.ToInt32(panelThangMau.Size.Height * (Convert.ToDouble(lb4.Text) / Convert.ToDouble(lb1.Text)));
            pn4.Size = new Size(panelThangMau.Size.Width, chieuCaoPanel);
            pn4.Location = new Point(pn4.Location.X, pn4.Location.Y + (panelThangMau.Size.Height - pn4.Size.Height));
            labelSLsp4T.Location = new Point(labelSLsp4T.Location.X, labelSLsp1T.Location.Y + (panelThangMau.Size.Height - pn4.Size.Height));

            chieuCaoPanel = Convert.ToInt32(panelThangMau.Size.Height * (Convert.ToDouble(lb5.Text) / Convert.ToDouble(lb1.Text)));
            pn5.Size = new Size(panelThangMau.Size.Width, chieuCaoPanel);
            pn5.Location = new Point(pn5.Location.X, pn5.Location.Y + (panelThangMau.Size.Height - pn5.Size.Height));
            labelSLsp5T.Location = new Point(labelSLsp5T.Location.X, labelSLsp1T.Location.Y + (panelThangMau.Size.Height - pn5.Size.Height));

            chieuCaoPanel = Convert.ToInt32(panelThangMau.Size.Height * (Convert.ToDouble(lb6.Text) / Convert.ToDouble(lb1.Text)));
            pn6.Size = new Size(panelThangMau.Size.Width, chieuCaoPanel);
            pn6.Location = new Point(pn6.Location.X, pn6.Location.Y + (panelThangMau.Size.Height - pn6.Size.Height));
            labelSLsp6T.Location = new Point(labelSLsp6T.Location.X, labelSLsp1T.Location.Y + (panelThangMau.Size.Height - pn6.Size.Height));
        }

        //HÀM THAY ĐỔI DỮ LIỆU KHI THAY ĐỔI THỜI GIAN (THEO THÁNG)
        private void dateTimePickerThang_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerThang.Value == null)
            {
                dateTimePickerThang.Value = Convert.ToDateTime(DateTime.Now.ToString("MM/yyyy"));
            }

            HienThongTinTongKetThang();
            MauPanelThangMacDinh();
            HienThiSLSanPhamThang(labelSLsp1T, labelSLsp2T, labelSLsp3T, labelSLsp4T, labelSLsp5T, labelSLsp6T, panelsp1T, panelsp2T, panelsp3T, panelsp4T, panelsp5T, panelsp6T);
            SizePanelThang(panelsp1T, panelsp2T, panelsp3T, panelsp4T, panelsp5T, panelsp6T, labelSLsp1T, labelSLsp2T, labelSLsp3T, labelSLsp4T, labelSLsp5T, labelSLsp6T);
        }







        //----------CODE THỰC HIỆN CHO TAB DOANH THU THEO NĂM----------
        //SỰ KIỆN KHI NHẤN VÀO NÚT "DOANH THU THEO NĂM"
        private void buttonNam_Click(object sender, EventArgs e)
        {
            dateTimePickerNam.Value = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
            MauNut();
            AnPanel();
            panelNam.Visible = true;
            buttonNam.BackColor = Color.SaddleBrown;


            HienThongTinLabel_ThongKeDoanhThuNam();
            SizeBieuDoNamMacDinh(panelThang1, panelThang2, panelThang3, panelThang4, panelThang5, panelThang6, panelThang7, panelThang8, panelThang9, panelThang10, panelThang11, panelThang12);
            LayThongTinTungThang();
            SizeBieuDoNam(panelThang1, panelThang2, panelThang3, panelThang4, panelThang5, panelThang6, panelThang7, panelThang8, panelThang9, panelThang10, panelThang11, panelThang12);
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX BIỂU ĐỒ THỐNG KÊ DOANH THU THEO TỪNG THÁNG
        private void groupBoxBieuDoTangTruongHangThang_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 345, 10, e.ClipRectangle.Width + 1, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        public int ThangCoDoanhThuLonNhat = 0;
        //LẤY THÔNG TIN DOANH THU TỪNG THÁNG
        void LayThongTinTungThang()
        {
            //xuất ra datatable dt (thang | tongtoa) theo năm
            connection.Open();
            string query = "select Month(NgayLapToa) as [Thang], TongToa from Toa where Year(NgayLapToa) = " + dateTimePickerNam.Value.Year.ToString() + "";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            //tạo datatable TongDT (Thang | Doanh Thu) trong đó cột Thang có dữ liệu từ 1 đến 12, sau đó đổ dữ liệu vào datagridviewNam

            DataTable TongDT = new DataTable();
            TongDT.Columns.Add("Thang");
            TongDT.Columns.Add("Doanh Thu");
            for (int i = 1; i <= 12; i++)
            {
                DataRow dtr = TongDT.NewRow();
                dtr["Thang"] = i;
                dtr["Doanh Thu"] = "1";     //nếu không có doanh thu của tháng đó thì mặc định là 1 (nếu là "0" thì không dùng để tính toán được)
                TongDT.Rows.Add(dtr);
            }
            dataGridViewNam.DataSource = TongDT;

            //tính tổng doanh thu từng tháng và thêm vào cột DoanhThu của datatable TongDT với tháng tương ứng
            for (int i = 0; i < TongDT.Rows.Count; i++)
            {
                int DTThang = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j].ItemArray[0].ToString() == TongDT.Rows[i].ItemArray[0].ToString())
                    {
                        DTThang = DTThang + Convert.ToInt32(dt.Rows[j].ItemArray[1].ToString());
                    }
                }
                dataGridViewNam.Rows[i].Cells[1].Value = DTThang.ToString();

                //tìm tháng có doanh thu lớn nhất
                if (ThangCoDoanhThuLonNhat <= DTThang)
                {
                    ThangCoDoanhThuLonNhat = DTThang;
                }
            }
            HienDoanhThuTungThang();
        }

        public int DTThang1, DTThang2, DTThang3, DTThang4, DTThang5, DTThang6, DTThang7, DTThang8, DTThang9, DTThang10, DTThang11, DTThang12 = 0;
        //HIỆN DOANH THU TỪNG THÁNG LÊN LABEL
        void HienDoanhThuTungThang()
        {
            DTThang1 = Convert.ToInt32(dataGridViewNam.Rows[0].Cells[1].Value.ToString());
            labelDTThang1.Text = DTThang1.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang2 = Convert.ToInt32(dataGridViewNam.Rows[1].Cells[1].Value.ToString());
            labelDTThang2.Text = DTThang2.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang3 = Convert.ToInt32(dataGridViewNam.Rows[2].Cells[1].Value.ToString());
            labelDTThang3.Text = DTThang3.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang4 = Convert.ToInt32(dataGridViewNam.Rows[3].Cells[1].Value.ToString());
            labelDTThang4.Text = DTThang4.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang5 = Convert.ToInt32(dataGridViewNam.Rows[4].Cells[1].Value.ToString());
            labelDTThang5.Text = DTThang5.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang6 = Convert.ToInt32(dataGridViewNam.Rows[5].Cells[1].Value.ToString());
            labelDTThang6.Text = DTThang6.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang7 = Convert.ToInt32(dataGridViewNam.Rows[6].Cells[1].Value.ToString());
            labelDTThang7.Text = DTThang7.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang8 = Convert.ToInt32(dataGridViewNam.Rows[7].Cells[1].Value.ToString());
            labelDTThang8.Text = DTThang8.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang9 = Convert.ToInt32(dataGridViewNam.Rows[8].Cells[1].Value.ToString());
            labelDTThang9.Text = DTThang9.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang10 = Convert.ToInt32(dataGridViewNam.Rows[9].Cells[1].Value.ToString());
            labelDTThang10.Text = DTThang10.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang11 = Convert.ToInt32(dataGridViewNam.Rows[10].Cells[1].Value.ToString());
            labelDTThang11.Text = DTThang11.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
            DTThang12 = Convert.ToInt32(dataGridViewNam.Rows[11].Cells[1].Value.ToString());
            labelDTThang12.Text = DTThang12.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VNĐ";
        }

        //SIZE BIỂU ĐỒ TĂNG TRƯỞNG THÁNG MẶC ĐỊNH KHI CHƯA THAY ĐỔI BỞI DỮ LIỆU
        void SizeBieuDoNamMacDinh(Panel p1, Panel p2, Panel p3, Panel p4, Panel p5, Panel p6, Panel p7, Panel p8, Panel p9, Panel p10, Panel p11, Panel p12)
        {
            p1.Size = p2.Size = p3.Size = p4.Size = p5.Size = p6.Size = p7.Size = p8.Size = p9.Size = p10.Size = p11.Size = p12.Size = new Size(panelTest.Size.Width, panelTest.Size.Height);
        }

        //THAY ĐỔI VÀ HIỂN THỊ SIZE BIỂU ĐỒ TĂNG TRƯỞNG THÁNG KHI CÓ DỮ LIỆU CỤ THỂ
        void SizeBieuDoNam(Panel p1, Panel p2, Panel p3, Panel p4, Panel p5, Panel p6, Panel p7, Panel p8, Panel p9, Panel p10, Panel p11, Panel p12)
        {
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = p7.Visible = p8.Visible = p9.Visible = p10.Visible = p11.Visible = p12.Visible = true;

            p1.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang1 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p1.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p1.Visible = false;
            }
            p2.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang2 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p2.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p2.Visible = false;
            }
            p3.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang3 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p3.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p3.Visible = false;
            }
            p4.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang4 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p4.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p4.Visible = false;
            }
            p5.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang5 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p5.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p5.Visible = false;
            }
            p6.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang6 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p6.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p6.Visible = false;
            }
            p7.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang7 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p7.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p7.Visible = false;
            }
            p8.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang8 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p8.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p8.Visible = false;
            }
            p9.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang9 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p9.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p9.Visible = false;
            }
            p10.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang10 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p10.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p10.Visible = false;
            }
            p11.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang11 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p11.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p11.Visible = false;
            }
            p12.Size = new Size(Convert.ToInt32(panelTest.Size.Width * (DTThang12 / Convert.ToDouble(ThangCoDoanhThuLonNhat))), p1.Size.Height);
            if (p12.Size.Width == Convert.ToInt32(panelTest.Size.Width * (1.0 / Convert.ToDouble(ThangCoDoanhThuLonNhat))))
            {
                p12.Visible = false;
            }
        }

        //HÀM THAY ĐỔI DỮ LIỆU BIỂU ĐỒ DOANH THU TĂNG TRƯỞNG THÁNG THEO THỜI GIAN
        private void dateTimePickerNam_ValueChanged(object sender, EventArgs e)
        {
            HienThongTinLabel_ThongKeDoanhThuNam();
            SizeBieuDoNamMacDinh(panelThang1, panelThang2, panelThang3, panelThang4, panelThang5, panelThang6, panelThang7, panelThang8, panelThang9, panelThang10, panelThang11, panelThang12);
            LayThongTinTungThang();
            SizeBieuDoNam(panelThang1, panelThang2, panelThang3, panelThang4, panelThang5, panelThang6, panelThang7, panelThang8, panelThang9, panelThang10, panelThang11, panelThang12);           
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX BAO PHỦ TOÀN BỘ 3 GROUPBOX BÊN PHẢI
        private void groupBoxTKNam_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.AntiqueWhite, 3);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 9, 0, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, 3, 10, e.ClipRectangle.Width + 1, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width, e.ClipRectangle.Height - 3, 2, e.ClipRectangle.Height - 3);
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX BÁN HÀNG
        private void groupBoxBanHang_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 111, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX NHẬP KHO VÀ LƯƠNG
        private void groupBoxNhapKhoLuong_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 196, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        //SỰ KIỆN HIỂN THỊ BORDER CỦA GROUPBOX DOANH THU
        private void groupBoxDoanhThu_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Black, 3);
            gfx.DrawLine(p1, 0, 11, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 10, 10, 10);
            gfx.DrawLine(p, 124, 10, e.ClipRectangle.Width - 2, 10);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 9, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 1);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }
                
        public int TienLaiTuHangTra_Nam, TongSLSPKhachTra_Nam, TienLaiTuSPDaBan_Nam, SLSPDaBan_Nam, LoiNhuanBanHang_Nam = 0;
        //TÍNH SỐ LƯỢNG HÀNG ĐÃ BÁN VÀ HÀNG TRẢ TRONG NĂM, TÍNH LỢI NHUẬN BÁN HÀNG CHƯA GIẢM GIÁ = LÃI TỪ SP BÁN - LÃI TỪ SP KHÁCH TRẢ 
        void MuaTraHangNam()
        {
            //lấy thông tin sản phẩm có giao dịch trong năm vừa chọn
            connection.Open();
            string queryThongTinMuaTra = "select distinct TenSP, GiaGoc, GiaBan from ChiTietToa where MaToa in (select MaToa from Toa where Year(NgayLapToa) = " + dateTimePickerNam.Value.Year.ToString() + ")";
            da = new OleDbDataAdapter(queryThongTinMuaTra, connection);
            DataTable dtThongTinMuaTra = new DataTable();
            da.Fill(dtThongTinMuaTra);
            connection.Close();

            //tạo datable chứa thông tin các sản phẩm trả hàng trong năm (tên sp, số lượng, giá gốc, giá bán)
            DataTable dtSLTra = new DataTable();
            dtSLTra.Columns.Add("TenSP");
            dtSLTra.Columns.Add("SL");
            dtSLTra.Columns.Add("GiaGoc");
            dtSLTra.Columns.Add("GiaBan");
            for (int i = 0; i < dtThongTinMuaTra.Rows.Count; i++)
            {
                connection.Open();
                string querySL = "select sum(SoLuong) from ChiTietToa where MuaTra = 'Trả' and TenSP = '" + dtThongTinMuaTra.Rows[i].ItemArray[0].ToString() + "' and MaToa in (select MaToa from Toa where Year(NgayLapToa) = " + dateTimePickerNam.Value.Year.ToString() + ")";
                OleDbCommand cmdSL = new OleDbCommand(querySL, connection);
                string SL = cmdSL.ExecuteScalar().ToString();
                connection.Close();

                if (SL != "")
                {
                    DataRow dtr = dtSLTra.NewRow();
                    dtr["TenSP"] = dtThongTinMuaTra.Rows[i].ItemArray[0].ToString();
                    dtr["SL"] = SL;
                    dtr["GiaGoc"] = dtThongTinMuaTra.Rows[i].ItemArray[1].ToString();
                    dtr["GiaBan"] = dtThongTinMuaTra.Rows[i].ItemArray[2].ToString();
                    dtSLTra.Rows.Add(dtr);
                }     
            }

            //tính tiền lãi từ các sản phẩm khách trả
            TienLaiTuHangTra_Nam = 0;
            int GiaGoc = 0, GiaBan = 0;
            TongSLSPKhachTra_Nam = 0;
            for (int i = 0; i < dtSLTra.Rows.Count; i++)
            {
                GiaGoc = GiaGoc + (Convert.ToInt32(dtSLTra.Rows[i].ItemArray[1].ToString()) * Convert.ToInt32(dtSLTra.Rows[i].ItemArray[2].ToString()));
                GiaBan = GiaBan + (Convert.ToInt32(dtSLTra.Rows[i].ItemArray[1].ToString()) * Convert.ToInt32(dtSLTra.Rows[i].ItemArray[3].ToString()));
                TongSLSPKhachTra_Nam = TongSLSPKhachTra_Nam + Convert.ToInt32(dtSLTra.Rows[i].ItemArray[1].ToString());
            }
            TienLaiTuHangTra_Nam = GiaBan - GiaGoc;

            //tạo datable chứa thông tin các sản phẩm đã bán trong năm (tên sp, số lượng, giá gốc, giá bán)
            DataTable dtSLMua = new DataTable();
            dtSLMua.Columns.Add("TenSP");
            dtSLMua.Columns.Add("SL");
            dtSLMua.Columns.Add("GiaGoc");
            dtSLMua.Columns.Add("GiaBan");
            for (int i = 0; i < dtThongTinMuaTra.Rows.Count; i++)
            {
                connection.Open();
                string querySL = "select sum(SoLuong) from ChiTietToa where MuaTra = 'Mua' and TenSP = '" + dtThongTinMuaTra.Rows[i].ItemArray[0].ToString() + "'";
                OleDbCommand cmdSL = new OleDbCommand(querySL, connection);
                string SL = cmdSL.ExecuteScalar().ToString();
                connection.Close();

                DataRow dtr = dtSLMua.NewRow();
                dtr["TenSP"] = dtThongTinMuaTra.Rows[i].ItemArray[0].ToString();
                dtr["SL"] = SL;
                dtr["GiaGoc"] = dtThongTinMuaTra.Rows[i].ItemArray[1].ToString();
                dtr["GiaBan"] = dtThongTinMuaTra.Rows[i].ItemArray[2].ToString();
                dtSLMua.Rows.Add(dtr);
            }

            //tính tiền lãi từ các sản phẩm đã bán
            int GiaGocMua = 0, GiaBanMua = 0;
            SLSPDaBan_Nam = 0;
            for (int i = 0; i < dtSLMua.Rows.Count; i++)
            {
                GiaGocMua = GiaGocMua + (Convert.ToInt32(dtSLMua.Rows[i].ItemArray[1].ToString()) * Convert.ToInt32(dtSLMua.Rows[i].ItemArray[2].ToString()));
                GiaBanMua = GiaBanMua + (Convert.ToInt32(dtSLMua.Rows[i].ItemArray[1].ToString()) * Convert.ToInt32(dtSLMua.Rows[i].ItemArray[3].ToString()));
                SLSPDaBan_Nam = SLSPDaBan_Nam + (Convert.ToInt32(dtSLMua.Rows[i].ItemArray[1].ToString()));
            }
            TienLaiTuSPDaBan_Nam = GiaBanMua - GiaGocMua;
            LoiNhuanBanHang_Nam = TienLaiTuSPDaBan_Nam - TienLaiTuHangTra_Nam;      //lợi nhuận chưa trừ giảm giá         
        }

        public int SLSPNhapKho_Nam, TongTienNhapKho_Nam, TongLuongNV_Nam = 0;
        //TÍNH CÁC THÔNG TIN CÓ TRONG GROUPBOX NHẬP KHO LƯƠNG
        void NhapKho_Luong()
        {          
            connection.Open();

            //lấy tổng số lượng hàng nhập trong năm
            SLSPNhapKho_Nam = 0;
            string querySLSPNhap = "select sum(SoLuong) from ChiTietHangNhap where MaPhieu in (select MaPhieu from HangNhap where Year(NgayNhap) = " + dateTimePickerNam.Value.Year.ToString() + ")";
            OleDbCommand cmdSLSPNhap = new OleDbCommand(querySLSPNhap,connection);          
            if (cmdSLSPNhap.ExecuteScalar().ToString() != "")
            {
                SLSPNhapKho_Nam = Convert.ToInt32(cmdSLSPNhap.ExecuteScalar().ToString());
            }
            else
            {
                SLSPNhapKho_Nam = 0;
            }

            //lấy tổng tiền các phiếu nhập hàng trong năm
            TongTienNhapKho_Nam = 0;
            string queryTongTienNhapKhoNam = "select sum(TongPhieu) from HangNhap where Year(NgayNhap) = " + dateTimePickerNam.Value.Year.ToString() + "";
            OleDbCommand cmdTongTienNhapKhoNam = new OleDbCommand(queryTongTienNhapKhoNam, connection);            
            if (cmdTongTienNhapKhoNam.ExecuteScalar().ToString() != "")
            {
                TongTienNhapKho_Nam = Convert.ToInt32(cmdTongTienNhapKhoNam.ExecuteScalar().ToString());
            }
            else
            {
                TongTienNhapKho_Nam = 0;
            }

            //lấy tổng tiền lương nhân viên trong năm
            TongLuongNV_Nam = 0;
            string queryLuongNV = "select sum (TongLuong) from GioCongVaLuongNhanVien where Nam = "+Convert.ToInt32(dateTimePickerNam.Value.ToString("yyyy"))+" ";
            OleDbCommand cmdLuongNV = new OleDbCommand(queryLuongNV,connection);
            
            if (cmdLuongNV.ExecuteScalar().ToString() != "")
            {
                TongLuongNV_Nam = Convert.ToInt32(cmdLuongNV.ExecuteScalar().ToString());
            }
            else
            {
                TongLuongNV_Nam = 0;
            }

            connection.Close();
        }

        public int TongDT_Nam, GiamGia_Nam, KhachNo_Nam, NoKhach_Nam = 0;
        //LẤY THÔNG TIN DỮ LIỆU CÁC LABEL CỦA GROUPBOX DOANH THU
        void LayThongTinGroupboxDoanhThu()
        {
            //lấy dữ liệu tổng toa, khách nợ, khách trả, giảm giá trong năm
            connection.Open();      
            string query = "select TongToa, KhachNo, NoKhach, TienGiamGia from Toa where Year(NgayLapToa) = " + dateTimePickerNam.Value.Year.ToString() + "";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            TongDT_Nam = GiamGia_Nam = KhachNo_Nam = NoKhach_Nam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TongDT_Nam = TongDT_Nam + Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());

                if (dt.Rows[i].ItemArray[1].ToString() != null)
                {
                    KhachNo_Nam = KhachNo_Nam + Convert.ToInt32(dt.Rows[i].ItemArray[1].ToString());
                }
               
                if (dt.Rows[i].ItemArray[2].ToString() != null)
                {
                    NoKhach_Nam = NoKhach_Nam + Convert.ToInt32(dt.Rows[i].ItemArray[2].ToString());
                }

                if (dt.Rows[i].ItemArray[3].ToString() != null)
                {
                    GiamGia_Nam = GiamGia_Nam + Convert.ToInt32(dt.Rows[i].ItemArray[3].ToString());
                }
            }
        }
    
        //HIỂN THỊ THÔNG TIN TOÀN BỘ LABEL DOANH THU THEO NĂM
        void HienThongTinLabel_ThongKeDoanhThuNam()
        {
            MuaTraHangNam();
            NhapKho_Luong();
            LayThongTinGroupboxDoanhThu();

            //groupbox bán hàng
            labelSLSPDaBanNam_Text.Text = SLSPDaBan_Nam.ToString() + " SP";
            labelSLSPTra_Text.Text = TongSLSPKhachTra_Nam.ToString() + " SP";
            labelLoiNhuanBHNam_Text.Text = LoiNhuanBanHang_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            //groupbox nhập kho lương
            labelTienNhapKhoNam_Text.Text = TongTienNhapKho_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelSLSPNhapNam_Text.Text = SLSPNhapKho_Nam.ToString() + " SP";
            labelLuongNV_Text.Text = TongLuongNV_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            //groupbox doanh thu
            labelTongGiamGiaNam_Text.Text = GiamGia_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelTongDTNam_Text.Text = TongDT_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelKhachNoNam_Text.Text = KhachNo_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelNoKhachNam_Text.Text = NoKhach_Nam.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            //label tổng lợi nhuận cả năm
            labelTongLoiNhuanCaNam.Text = (LoiNhuanBanHang_Nam - GiamGia_Nam - TongTienNhapKho_Nam - TongLuongNV_Nam).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
        }
    }
}

