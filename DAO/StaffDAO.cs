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
    }
}
