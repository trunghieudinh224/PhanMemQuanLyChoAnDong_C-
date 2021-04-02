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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace QUANLYBANQUANAO
{
    public partial class formChiTietPhieuNhap : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        public OleDbDataAdapter da;
        private OleDbConnection connection = new OleDbConnection();
        public string MaPhieu = formNhapHang.PhieuNhapDuocChon;
        public static string filename;

        public formChiTietPhieuNhap()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienThongTinPhieuNhap();

            HienThongTinSPNhap();
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

        //HÀM HIỂN THỊ CÁC LABEL 
        void HienThongTinPhieuNhap()
        {
            labelMaPhieu_Text.Text = MaPhieu;
            connection.Open();
            string query = "select * from HangNhap where MaPhieu = '"+MaPhieu+"'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            labelNgay_Text.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[1].ToString()).ToString("dd/MM/yyyy");
            labelTongPhieu_Text.Text = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString()).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";
            labelNVNhapHang_Text.Text = dt.Rows[0].ItemArray[7].ToString();
            labelNVLapPhieu_Text.Text = dt.Rows[0].ItemArray[8].ToString();
            labelNCC_Text.Text = dt.Rows[0].ItemArray[3].ToString();
            labelSDTNCC_Text.Text = dt.Rows[0].ItemArray[6].ToString(); 
            labelMaNCC_Text.Text = dt.Rows[0].ItemArray[4].ToString(); 
            labelDiaChiNCC_Text.Text = dt.Rows[0].ItemArray[5].ToString();
        }

        //HÀM HIỂN THỊ THÔNG TIN SẢN PHẨM NHẬP
        void HienThongTinSPNhap()
        {
            connection.Open();
            string query = "select TenSP as [Tên sản phẩm], DanhMuc as [Danh mục], SoLuong as [Số lượng], GiaNhap as [Đơn giá] from ChiTietHangNhap where MaPhieu = '" + MaPhieu+"'";
            da = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewDSPN.DataSource = dt;
            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string SP = dt.Rows[i].ItemArray[0].ToString();
                string SL = dt.Rows[i].ItemArray[1].ToString();
                string DM = dt.Rows[i].ItemArray[2].ToString();
                string GN = dt.Rows[i].ItemArray[3].ToString();

                string[] item = { SP, SL, DM, GN };
                var x = new ListViewItem(item);
                listViewDSHN.Items.Add(x);
            }
            listViewDSHN.Columns[2].TextAlign = HorizontalAlignment.Center;
            filename = Application.StartupPath + "//PhieuNhap//" + MaPhieu + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
        }

        //HÀM LƯU THÔNG TIN THÀNH FILE PDF
        public void PDFPhieuNhap(DataGridView dgv)
        {

            Document pdfdoc = new Document(PageSize.A5, 20f, 20f, 20f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(filename, FileMode.Create));

            BaseFont bf = BaseFont.CreateFont(Application.StartupPath + @"\vuArial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            PdfPTable pdftb = new PdfPTable(dgv.Columns.Count);
            pdftb.DefaultCell.Padding = 3;
            pdftb.WidthPercentage = 100;
            pdftb.HorizontalAlignment = Element.ALIGN_CENTER;
            pdftb.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font TieuDeChinh = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font Bang = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font kcb = new iTextSharp.text.Font(bf, 7, iTextSharp.text.Font.NORMAL);

            Paragraph TieuDe = new Paragraph("THÔNG TIN PHIẾU NHẬP\n", TieuDeChinh);
            TieuDe.Alignment = 1;
            Paragraph khoangcach = new Paragraph(" ", TieuDeChinh);


            Paragraph dong1 = new Paragraph("Ngày: " + labelNgay_Text.Text + "                                Mã Phiếu: " + labelMaPhieu_Text.Text, Bang);
            Paragraph dong2 = new Paragraph("Tổng Phiếu: " + labelTongPhieu_Text.Text, Bang);
            Paragraph dong3 = new Paragraph("Nhân viên nhận hàng: " + labelNVNhapHang_Text.Text , Bang);
            Paragraph dong4 = new Paragraph("Nhân viên lập phiếu: " + labelNVLapPhieu_Text.Text, Bang);
            Paragraph dong5 = new Paragraph("Nhà cung cấp: " + labelNCC_Text.Text, Bang);
            Paragraph dong6 = new Paragraph("SĐT NCC: " + labelSDTNCC_Text.Text + "                           Mã NCC: " + labelMaNCC_Text.Text, Bang);
            Paragraph dong7 = new Paragraph("Địa chỉ NCC: " + labelDiaChiNCC_Text.Text, Bang);
            Paragraph khoangcachbang = new Paragraph(" ", kcb);

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, Bang));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                cell.HorizontalAlignment = 1;
                pdftb.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftb.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            pdfdoc.Open();
            pdfdoc.Add(TieuDe);
            pdfdoc.Add(khoangcach);
            pdfdoc.Add(dong1);
            pdfdoc.Add(dong2);
            pdfdoc.Add(dong3);
            pdfdoc.Add(dong4);
            pdfdoc.Add(dong5);
            pdfdoc.Add(dong6);
            pdfdoc.Add(dong7);
            pdfdoc.Add(khoangcach);
            pdfdoc.Add(pdftb);

            pdfdoc.Close();

        }

        //HÀM KHI NHẤN VÀO NÚT IN PHIẾU
        private void buttonInPhieu_Click(object sender, EventArgs e)
        {
            PDFPhieuNhap(dataGridViewDSPN);
            System.Diagnostics.Process.Start(filename);
        }
    }
}
