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
    public partial class formXacNhanToa : Form
    {
        public string connectionSTR = formDangNhap.connectionSTR;
        private OleDbConnection connection = new OleDbConnection();
        public static DataTable dt = new DataTable();
        public static DataTable dttra = new DataTable();
        

        public static string nhanvienlap;
        public static string filename;
        public static int MaToaHang = 0;

        public formXacNhanToa()
        {
            InitializeComponent();

            connection.ConnectionString = connectionSTR;

            HienThiToaMua();

            HienThiToaTra();

            HienThongTinToa();
        }

        //HÀM KHI CLICK NÚT ẨN
        private void buttonAn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //HÀM KHI RÊ CHUỘT VÀO NÚT ẨN
        private void buttonAn_MouseHover(object sender, EventArgs e)
        {
            buttonAn.BackColor = Color.CornflowerBlue;
        }

        //HÀM KHI RÊ CHUỘT RỜI KHỎI NÚT ẨN
        private void buttonAn_MouseLeave(object sender, EventArgs e)
        {
            buttonAn.BackColor = Color.CornflowerBlue;
        }

        //HÀM KHI CLICK NÚT X
        private void buttonX_Click(object sender, EventArgs e)
        {
            formBanHang.kettoa = 0;
            dt.Clear();
            dttra.Clear();
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




        //----------CÁC HÀM CHÍNH TRONG FORM----------
        //HIỂN THỊ DANH SÁCH SẢN PHẨM KHÁCH MUA
        void HienThiToaMua()
        {
            string sp, sl, dg, tt;
            for (int i =0; i<dt.Rows.Count; i++)
            {
                sp = dt.Rows[i].ItemArray[0].ToString();
                sl = dt.Rows[i].ItemArray[1].ToString();
                dg = dt.Rows[i].ItemArray[2].ToString();
                tt = dt.Rows[i].ItemArray[3].ToString();

                string[] item = { sp, sl,dg,tt };
                var x = new ListViewItem(item);
                listViewMuaHang.Items.Add(x);
                dataGridViewMua.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString());
            }

        }

        //HIỂN THỊ DANH SÁCH SẢN PHẨM KHÁCH TRẢ
        void HienThiToaTra()
        {
            string sp, sl, dg, tt;
            for (int i = 0; i < dttra.Rows.Count; i++)
            {
                sp = dttra.Rows[i].ItemArray[0].ToString();
                sl = dttra.Rows[i].ItemArray[1].ToString();
                dg = dttra.Rows[i].ItemArray[2].ToString();
                tt = dttra.Rows[i].ItemArray[3].ToString();

                string[] item = { sp, sl, dg, tt };
                var x = new ListViewItem(item);
                listViewTraHang.Items.Add(x);
                dataGridViewTra.Rows.Add(dttra.Rows[i].ItemArray[0].ToString(), dttra.Rows[i].ItemArray[1].ToString(), dttra.Rows[i].ItemArray[2].ToString(), dttra.Rows[i].ItemArray[3].ToString());
            }
        }

        public int KhachNo, NoKhach = 0;
        //HIỂN THỊ THÔNG TIN CÁC LABEL 
        void HienThongTinToa()
        {
            KhachNo = NoKhach = 0;
            connection.Open();
            string query = "select TenHienThi from TaiKhoan where Username = '"+formDangNhap.username+"'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            string username = cmd.ExecuteScalar().ToString();
            connection.Close();
            labelNhanVienLapToa_Text.Text = username;
            labelNgay_Text.Text = DateTime.Now.ToString("dd/MM/yyyy");
            labelTenKhach_Text.Text = formBanHang.TenKhach;
            labelSDT_Text.Text = formBanHang.SDT;
            labelTongToaHang_Text.Text = formBanHang.TongToaHang.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
            labelSLSanPham_Text.Text = formBanHang.SLSanPham;
            if (formBanHang.Toa_ThieuKhach_KhachThieu == "Khách thiếu:")
            {
                labelKhachNo.Text = "Khách nợ:";
                labelKhachNo_Text.Text = Math.Abs(formBanHang.Toa_KhachThieu).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                KhachNo = Math.Abs(formBanHang.Toa_KhachThieu);
            }
            else
            {
                labelKhachNo.Text = "Nợ khách:";
                labelKhachNo_Text.Text = Math.Abs(formBanHang.Toa_KhachThieu).ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###");
                NoKhach = Math.Abs(formBanHang.Toa_KhachThieu);
            }            
            labelThanhToan_Text.Text = formBanHang.ThanhToan;

            int mua = 0;
            int tra = 0;
            for (int i =0; i < listViewMuaHang.Items.Count; i++)
            {
                mua = mua + Convert.ToInt32(listViewMuaHang.Items[i].SubItems[3].Text);
            }
            labelTongMua_Text.Text = mua.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            for (int j = 0; j < listViewTraHang.Items.Count; j++)
            {
                tra = tra + Convert.ToInt32(listViewTraHang.Items[j].SubItems[3].Text);
            }
            labelTongTra_Text.Text = tra.ToString("#,##,##,##,##,##,##,##,##,##,##,##,##,###") + " VND";

            connection.Open();
            string queryMaToaHang = "select max(MaToa) from Toa";
            OleDbCommand cmdCheckMaToa = new OleDbCommand(queryMaToaHang, connection);
            if (cmdCheckMaToa.ExecuteScalar().ToString() == "")
            {
                MaToaHang = 1;
            }
            else
            {
                MaToaHang = Convert.ToInt32(cmdCheckMaToa.ExecuteScalar().ToString()) + 1;
            }
            connection.Close();

            filename = Application.StartupPath + "//Toa//" + MaToaHang.ToString() + "_(" + labelTenKhach_Text.Text + ")_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
        }

        //HÀM THIẾT KẾ TOA XUẤT PDF
        public void PDFToaHang(DataGridView dgvmua, DataGridView dgvtra)
        {
            
            Document pdfdoc = new Document(PageSize.A5, 20f, 20f, 20f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(filename, FileMode.Create));

            BaseFont bf = BaseFont.CreateFont(Application.StartupPath + @"\vuArial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            PdfPTable pdftb = new PdfPTable(dgvmua.Columns.Count);
            pdftb.DefaultCell.Padding = 3;
            pdftb.WidthPercentage = 100;
            pdftb.HorizontalAlignment = Element.ALIGN_CENTER;
            pdftb.DefaultCell.BorderWidth = 1;

            PdfPTable pdftbtra = new PdfPTable(dgvtra.Columns.Count);
            pdftbtra.DefaultCell.Padding = 3;
            pdftbtra.WidthPercentage = 100;
            pdftbtra.HorizontalAlignment = Element.ALIGN_CENTER;
            pdftbtra.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font TieuDeChinh = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font Bang = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font kcb = new iTextSharp.text.Font(bf, 7, iTextSharp.text.Font.NORMAL);

            Paragraph ANDONG = new Paragraph("TRUNG TÂM THƯƠNG MẠI DỊCH VỤ AN ĐÔNG\n", TieuDeChinh);
            ANDONG.Alignment = 1;
            Paragraph THIENVY = new Paragraph("LỢI DUNG (THIỆN VY)\n", TieuDeChinh);
            THIENVY.Alignment = 1;
            Paragraph khoangcach = new Paragraph(" ", TieuDeChinh);


            Paragraph dong1 = new Paragraph("Nhân viên lập: " + labelNhanVienLapToa_Text.Text + "                                  Ngày: " + labelNgay_Text.Text, Bang);
            Paragraph dong2 = new Paragraph("Tên khách: " + labelTenKhach_Text.Text, Bang);
            Paragraph dong3 = new Paragraph("SĐT: "+ labelSDT_Text.Text + "                                 Tổng toa hàng: " + labelTongToaHang_Text.Text, Bang);
            Paragraph dong4 = new Paragraph(labelKhachNo.Text + " " + labelKhachNo_Text.Text, Bang);
            Paragraph dong5 = new Paragraph("SLSP (mua - bán): " + labelSLSanPham_Text.Text,Bang);
            Paragraph dong6 = new Paragraph("Hình thức thanh toán: " + labelThanhToan_Text.Text, Bang);
            Paragraph dong7 = new Paragraph("MUA                                                  " + "Tổng mua: "+labelTongMua_Text.Text +"\n", Bang);
            Paragraph dong8 = new Paragraph("TRẢ                                                  " + "Tổng trả:    " + labelTongTra_Text.Text + "\n", Bang);
            Paragraph khoangcachbang = new Paragraph(" ",kcb);

            //Mua
            if (listViewMuaHang.Items.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvmua.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, Bang));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = 1;
                    pdftb.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgvmua.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdftb.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
            }            

            //Trả
            if (listViewTraHang.Items.Count >0)
            {
                foreach (DataGridViewColumn column in dgvtra.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, Bang));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = 1;
                    pdftbtra.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgvtra.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdftbtra.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
            }

            
            pdfdoc.Open();
            pdfdoc.Add(ANDONG);
            pdfdoc.Add(THIENVY);
            pdfdoc.Add(khoangcach);
            pdfdoc.Add(dong1);
            pdfdoc.Add(dong2);
            pdfdoc.Add(dong3);
            pdfdoc.Add(dong4);
            pdfdoc.Add(dong5);
            pdfdoc.Add(dong6);
            if (listViewMuaHang.Items.Count > 0)
            {
                pdfdoc.Add(khoangcach);
                pdfdoc.Add(dong7);
                pdfdoc.Add(khoangcachbang);
                pdfdoc.Add(pdftb);
            }                   
            if (listViewTraHang.Items.Count > 0)
            {
                pdfdoc.Add(khoangcach);
                pdfdoc.Add(dong8);
                pdfdoc.Add(khoangcachbang);
                pdfdoc.Add(pdftbtra);
            }           
            pdfdoc.Close();
   
        }
              
        //HÀM THỰC HIỆN LƯU TOA
        private void buttonLuuToa_Click(object sender, EventArgs e)
        {           
            connection.Open();

            DialogResult dlr = MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.OKCancel);
            //nếu muốn lưu toa
            if (dlr == DialogResult.OK)
            {
                buttonX.Enabled = false;
                buttonKetToa.Enabled = true;

                //nếu khách hàng là khách vãng lai
                if (formBanHang.TenKhach != "" && formBanHang.SDT != "")
                {
                    //nếu khách hàng là khách vãng lai chưa mua ở sạp lần nào
                    if (formBanHang.LoaiKhach == "KhachVangLaiMoi")
                    {
                        string query = "insert into KhachHang (SDTKhachHang, HoTenKhachHang, DiaChiKhachHang, LoaiKhachHang) values ('"+formBanHang.SDT + "', '"+ formBanHang.TenKhach + "', '"+ formBanHang.DiaChi + "', 'khachvanglai')";
                        OleDbCommand cmd = new OleDbCommand(query,connection);
                        cmd.ExecuteNonQuery();
                    }
                }

                //lưu toa thành file pdf
                PDFToaHang(dataGridViewMua, dataGridViewTra);       

                //thêm thông tin vào bảng Toa
                string queryToa = "insert into Toa (MaToa, NgayLapToa, NhanVienLapToa, TenKhachHang, SDTKhachHang, TongToa, TienGiamGia, KhachNo, NoKhach, HinhThucThanhToan) values ('"+MaToaHang.ToString()+"', '" + labelNgay_Text.Text + "', '" + formDangNhap.username + "', '" + labelTenKhach_Text.Text + "', '" + labelSDT_Text.Text + "', '" + labelTongToaHang_Text.Text + "', '" + formBanHang.giamgia + "', '" + Math.Abs(KhachNo) + "', '" + Math.Abs(NoKhach) + "', '" + labelThanhToan_Text.Text + "')";
                OleDbCommand cmdToa = new OleDbCommand(queryToa, connection);
                cmdToa.ExecuteNonQuery();

                //thêm thông tin từ toa Mua và chi tiết toa
                if (listViewMuaHang.Items.Count > 0)
                {
                    for (int i = 0; i < listViewMuaHang.Items.Count; i++)
                    {
                        //lấy mã sp của các sp trong toa Mua
                        string queryLayMaSP = "select MaSP from SanPham where TenSP = '" + listViewMuaHang.Items[i].SubItems[0].Text + "'";
                        OleDbCommand cmdLayMaSP = new OleDbCommand(queryLayMaSP, connection);
                        string MaSP = cmdLayMaSP.ExecuteScalar().ToString();
                        string TenSP = listViewMuaHang.Items[i].SubItems[0].Text;

                        //lấy giá gốc của các sản phẩm trong toa Mua
                        string queryLayGiaGoc = "select GiaGoc from SanPham where TenSP = '" + listViewMuaHang.Items[i].SubItems[0].Text + "'";
                        OleDbCommand cmdLayGiaGoc = new OleDbCommand(queryLayGiaGoc, connection);
                        string GiaGoc = cmdLayGiaGoc.ExecuteScalar().ToString();
                        string SoLuong = listViewMuaHang.Items[i].SubItems[1].Text;
                        string GiaBan = listViewMuaHang.Items[i].SubItems[2].Text;
                        string ThanhTien = listViewMuaHang.Items[i].SubItems[3].Text;

                        //thêm các thông tin toa Mua vào ChiTietToa
                        string queryChiTietToaMua = "insert into ChiTietToa (MaToa, MuaTra, MaSP, TenSP, SoLuong, GiaGoc, GiaBan, ThanhTien) values ('" + MaToaHang.ToString() + "', 'Mua', '" + MaSP + "', '" + TenSP + "', '" + SoLuong + "', '" + GiaGoc + "', '" + GiaBan + "', '" + ThanhTien + "')";
                        OleDbCommand cmdChiTietToaMua = new OleDbCommand(queryChiTietToaMua, connection);
                        cmdChiTietToaMua.ExecuteNonQuery();
                    }
                }

                //thêm thông tin toa Trả vào chi tiết toa
                if (listViewTraHang.Items.Count > 0)
                {
                    for (int i = 0; i < listViewTraHang.Items.Count; i++)
                    {
                        //lấy mã sp của các sp trong toa Trả
                        string queryLayMaSP = "select MaSP from SanPham where TenSP = '" + listViewTraHang.Items[i].SubItems[0].Text + "'";
                        OleDbCommand cmdLayMaSP = new OleDbCommand(queryLayMaSP, connection);
                        string MaSP = cmdLayMaSP.ExecuteScalar().ToString();
                        string TenSP = listViewTraHang.Items[i].SubItems[0].Text;

                        //lấy giá gốc của các sản phẩm trong toa Trả
                        string queryLayGiaGoc = "select GiaGoc from SanPham where TenSP = '" + listViewTraHang.Items[i].SubItems[0].Text + "'";
                        OleDbCommand cmdLayGiaGoc = new OleDbCommand(queryLayGiaGoc, connection);
                        string GiaGoc = cmdLayGiaGoc.ExecuteScalar().ToString();
                        int SoLuong = Convert.ToInt32(listViewTraHang.Items[i].SubItems[1].Text);
                        string GiaBan = listViewTraHang.Items[i].SubItems[2].Text;
                        string ThanhTien = listViewTraHang.Items[i].SubItems[3].Text;

                        //thêm các thông tin toa Trả vào ChiTietToa
                        string queryChiTietToaMua = "insert into ChiTietToa (MaToa, MuaTra, MaSP, TenSP, SoLuong, GiaGoc, GiaBan, ThanhTien) values ('" + MaToaHang.ToString() + "', 'Trả', '" + MaSP + "', '" + TenSP + "', '" + SoLuong + "', '" + GiaGoc + "', '" + GiaBan + "', '" + ThanhTien + "')";
                        OleDbCommand cmdChiTietToaMua = new OleDbCommand(queryChiTietToaMua, connection);
                        cmdChiTietToaMua.ExecuteNonQuery();

                        //lấy số lượng tồn từng sản phẩm
                        string queryLaySLSPHienTai = "select SoLuongTon from SanPham where TenSP = '" + TenSP + "'";
                        OleDbCommand cmdLaySLSPHienTai = new OleDbCommand(queryLaySLSPHienTai, connection);
                        int SLSPHienTai = Convert.ToInt32(cmdLaySLSPHienTai.ExecuteScalar().ToString());

                        //cập nhật số lượng tồn các sản phẩm khách trả
                        string queryCapNhat = "update SanPham set SoLuongTon = " + (SoLuong + SLSPHienTai) + " where TenSP = '" + TenSP + "'";
                        OleDbCommand cmdCapNhat = new OleDbCommand(queryCapNhat, connection);
                        cmdCapNhat.ExecuteNonQuery();
                    }
                }
                                
                buttonLuuToa.Enabled = false;
                buttonIn.Enabled = true;
            }
            connection.Close();
        }

        //HÀM IN TOA (MỞ FILE PDF)
        private void buttonIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(filename);
        }

        //HÀM KẾT TOA 
        private void buttonKetToa_Click(object sender, EventArgs e)
        {
            if (buttonLuuToa.Enabled == false)
            {
                formBanHang.kettoa = 1;
                dt.Clear();
                dttra.Clear();
                this.Close();
            }

            if (buttonLuuToa.Enabled == true)
            {
                MessageBox.Show("Bạn chưa xác nhận thanh toán và lưu toa !!!", "Thông báo");
            }
        }
    }
}
