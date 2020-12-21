using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public void SwitchTableEmpty(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTabelEmpty @idTable1 , @idTabel2", new object[]{id1, id2});
        }
        public void SwitchTableNotEmpty(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTabelNotEmpty @idTable1 , @idTabel2", new object[] { id1, id2 });
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();

            string query = "select * from TABLE_FOOD";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
        public bool InsertTable(string name, int status)
        {
            string query = string.Format("INSERT dbo.TABLE_FOOD ( name, status)VALUES  ( N'{0}', {1})", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTable(int idTable)
        {
            string query = string.Format("Delete TABLE_FOOD where id = {0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int idTable, string name, int status)
        {
            string query = string.Format("UPDATE TABLE_FOOD SET name = N'{0}', status = {1} WHERE id = {2}", name, status, idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
