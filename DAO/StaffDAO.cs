using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set { instance = value; }
        }
        public List<Staff> GetListStaff()
        {
            List<Staff> list = new List<Staff>();

            string query = "select * from Staff";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Staff category = new Staff(item);
                list.Add(category);
            }

            return list;
        }
        public List<Staff> SearchStaffByName(string name)
        {

            List<Staff> list = new List<Staff>();
            string query = string.Format("select * from STAFF where name like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }
            return list;
        }

        public bool InsertStaff(string name, string sdt ,string address,string sex,int salary,int status)
        {
            string query = string.Format("INSERT dbo.STAFF ( name, sdt, address ,sex,salary,status )VALUES  ( N'{0}', N'{1}',N'{2}',N'{3}',{4},{5})", name, sdt,address,sex,salary,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateStaff(int idstaff,string name, string sdt, string address, string sex, int salary, int status)
        {
            string query = string.Format("UPDATE dbo.STAFF SET name = N'{0}', sdt = N'{1}', address = N'{2}', sex=N'{3}',salary={4},status={5} WHERE id = {6}", name, sdt,address,sex,salary,status,idstaff);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteStaff(int idStaff)
        {
            try
            {
                AccountDAO.Instance.DeleteAccountByID(idStaff);
            }
            catch { }
            string query = string.Format("Delete STAFF where id = N'{0}'", idStaff);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
