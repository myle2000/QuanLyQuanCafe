using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnExti_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassWord.Text;
            string newpass = txbNewPass.Text;
            string retype = txbReEnterPass.Text;
            string userName = txbUserName.Text;
            if (password != this.LoginAccount.Password)
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu");
                return;
            }
            else
            if (!newpass.Equals(retype))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdatePassword(userName, displayName, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
            
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            txbUserName.Text = this.LoginAccount.UserName;
            txbDisplayName.Text = this.LoginAccount.DisplayName;
            txbPassWord.UseSystemPasswordChar = true;
            txbNewPass.UseSystemPasswordChar = true;
            txbReEnterPass.UseSystemPasswordChar = true;
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
            {
                txbPassWord.UseSystemPasswordChar = false;
                txbNewPass.UseSystemPasswordChar = false;
                txbReEnterPass.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassWord.UseSystemPasswordChar = true;
                txbNewPass.UseSystemPasswordChar = true;
                txbReEnterPass.UseSystemPasswordChar = true;
            }
        }
    }

    public class AccountEvent:EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
