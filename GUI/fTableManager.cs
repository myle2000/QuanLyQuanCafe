using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.GUI;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type);  }
        }
        public fTableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }

        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Visible = type == 1;
            foodToolStripMenuItem.Visible = type == 0;
            danhMụcToolStripMenuItem.Visible = type == 0;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName +")";
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight};
                btn.Text = item.Name + Environment.NewLine;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "0":
                        btn.BackColor = Color.LightGray;
                        break;
                    default:
                        btn.BackColor = Color.Green;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyQuanCafe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyQuanCafe.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTamTinh.Text = totalPrice.ToString("c", culture);
            //txbDiscount.Text = Int32.Parse(txbDiscount.Text).ToString("c", culture);
            txbTongCong.Text= (totalPrice - Int32.Parse(txbDiscount.Text)*1000).ToString("c", culture);

        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        #endregion


        #region Events

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
            this.Show();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account login = AccountDAO.Instance.GetAccountByUserName(LoginAccount.UserName);
            fAdmin f = new fAdmin(login);
            f.loginAccount = LoginAccount;
            f.ShowDialog();
            this.Show();
        }

        void f_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        void f_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        void f_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID, LoginAccount.Id_staff);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID , count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);
            LoadTable();
        }
        private void btnDelFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }
            if (lsvBill.SelectedItems.Count > 0)//đã chọn món cần xóa
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa món này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {

                    int id_bill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                    int id_food = FoodDAO.Instance.SearchIDfood(lsvBill.SelectedItems[0].SubItems[0].Text);
                    BillInfoDAO.Instance.DeleteBillInfoByFoodIDBillID(id_bill, id_food);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn món cần xóa");
            }


        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = Int32.Parse(txbDiscount.Text);
 
            double totalPrice = Convert.ToDouble(txbTamTinh.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - discount;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn cần thanh toán!");
                return;
            }
            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0} với giảm giá {1}.000đ. Tổng thanh toán =  {2}.000đ ", table.Name, discount,finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (int)finalTotalPrice*1000, table.ID);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }
        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {           
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }
            if ((lsvBill.Tag as Table).Status =="0")
            {
                MessageBox.Show("Bàn đã trống, không cần chuyển!");
                return;
            }
            if (id1 == id2)
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
            else
            {
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if ((cbSwitchTable.SelectedItem as Table).Status != "1")//TH bàn sắp chuyển trống
                    {
                        TableDAO.Instance.SwitchTableEmpty(id1, id2);
                    }
                    else // nếu bàn sắp chuyển đã có người ngồi
                    {
                        TableDAO.Instance.SwitchTableNotEmpty(id1, id2);
                    }
                }
            }
            
            LoadTable();
        }
        #endregion

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fFood f = new fFood();
            f.ShowDialog();
            this.Show();
          
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fCategory f = new fCategory();
            f.ShowDialog();
            this.Show();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            this.helpProvider1.SetShowHelp(this.textBox1, true);
            this.helpProvider1.SetHelpString(this.textBox1, "Ctrl + A de thanh toan \n Ctrl + B de them mon");
        }

        private void btnBillinf_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn cần thanh toán!");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = Int32.Parse(txbDiscount.Text);
            double totalPrice = Convert.ToDouble(txbTamTinh.Text.Split(',')[0]);
            double finalTotalPrice = (totalPrice - discount) * 1000;
            fBillDetails f = new fBillDetails(idBill, (int)finalTotalPrice, discount*1000, (int)totalPrice*1000);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void txbTotalPrice_TextChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTongCong.Text = (Convert.ToDouble(txbTamTinh.Text.Split(',')[0])*1000 - Int32.Parse(txbDiscount.Text)*1000).ToString("c", culture);
        }

        private void txbDiscount_TextChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTongCong.Text = (Convert.ToDouble(txbTamTinh.Text.Split(',')[0])*1000 - Int32.Parse(txbDiscount.Text)*1000).ToString("c", culture);
        }
    }
}
