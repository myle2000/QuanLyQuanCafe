using iTextSharp.text;
using iTextSharp.text.pdf;
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.GUI
{
    public partial class fBillDetails : Form
    {
        public fBillDetails(int id_bill, int totalMoney, int discount, int money)
        {
            InitializeComponent();
            LoadListBillinf(id_bill, totalMoney, discount,  money);
        }
        void LoadListBillinf(int id_bill, int totalMoney, int discount, int money)
        {
            dtgvBillinf.DataSource = BillInfoDAO.Instance.GetListBillInfByIDBill(id_bill);
            txbID_bill.Text = id_bill.ToString();

            txtDate.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss");

            txtEmp.Text = BillInfoDAO.Instance.GetNameEmp(id_bill);

            tbTotal.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:#,#}", totalMoney);
            tbdiscount.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:#,#}", discount);
            tbMoney.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:#,#}", money);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BaseFont bf = BaseFont.CreateFont("c:\\fonts\\vuArial.ttf",
                                   BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            // khỏi tạo font chữ
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 15);
            if (dtgvBillinf.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = txbID_bill.Text + ".pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dtgvBillinf.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


                            foreach (DataGridViewColumn column in dtgvBillinf.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                                pdfTable.AddCell(cell);

                            }

                            foreach (DataGridViewRow row in dtgvBillinf.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        //pdfTable.AddCell(cell.Value.ToString());
                                        PdfPCell t = new PdfPCell(new Phrase(cell.Value.ToString(), font));
                                        pdfTable.AddCell(t);
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A5, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();

                                Paragraph dash = new Paragraph("----------------------");
                                dash.Alignment = Element.ALIGN_CENTER;

                                Paragraph nameShop = new Paragraph("Cafe Sinh viên", font);
                                nameShop.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(nameShop);
                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph addrShop = new Paragraph("Địa chỉ: 1-Võ Văn Ngân, Thủ Đức", font);
                                addrShop.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(addrShop);
                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph telShop = new Paragraph("Số điện thoại: 099", font);
                                telShop.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(telShop);
                                pdfDoc.Add(new Paragraph("\n"));
                                pdfDoc.Add(dash);
                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph BILL = new Paragraph("HÓA ĐƠN", font);
                                BILL.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(BILL);
                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph numberBill = new Paragraph("Mã hóa đơn: " + txbID_bill.Text, font);
                                numberBill.Alignment = Element.ALIGN_LEFT;
                                pdfDoc.Add(numberBill);
                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph date = new Paragraph("Ngày thanh toán: " + txtDate.Text, font);
                                date.Alignment = Element.ALIGN_LEFT;
                                pdfDoc.Add(date);
                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph emp = new Paragraph("Nhân viên: " + txtEmp.Text, font);
                                emp.Alignment = Element.ALIGN_LEFT;
                                pdfDoc.Add(emp);
                                pdfDoc.Add(dash);
                                pdfDoc.Add(new Paragraph("\n"));

                                pdfDoc.Add(pdfTable);

                                pdfDoc.Add(new Paragraph("\n"));

                                Paragraph Money = new Paragraph("Tổng tiền: " + tbMoney.Text +" đ", font);
                                Money.Alignment = Element.ALIGN_LEFT;
                                pdfDoc.Add(Money);
                                pdfDoc.Add(new Paragraph("\n"));
                                Paragraph dis = new Paragraph("Giảm: - " + tbdiscount.Text + " đ", font);
                                dis.Alignment = Element.ALIGN_LEFT;
                                pdfDoc.Add(dis);
                                pdfDoc.Add(new Paragraph("\n"));
                                Paragraph totalMoney = new Paragraph("Thanh toán: " + tbTotal.Text + " đ", font);
                                totalMoney.Alignment = Element.ALIGN_LEFT;
                                pdfDoc.Add(totalMoney);

                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fBillDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
