using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord /*list*/});
            return result.Rows.Count > 0;

        }

        public bool UpdateAccount(string userName, string displayName, string pass, int type, int id_staff)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @type , @id_staff", new object[] { userName, displayName, pass, type, id_staff });

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT username, displayname, password, type, id_staff, name as Staff_name  FROM dbo.Account, staff where staff.id=account.id_staff");
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string name, string displayName, int type, int id_staff)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, password, Type, id_staff )VALUES  ( N'{0}', N'{1}', '{2}', {3}, {4} )", name, displayName,1, type, id_staff);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        /*public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }*/

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name, string pass)
        {
            string query = string.Format("update account set password = '{0}' where UserName = N'{1}'", pass, name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
