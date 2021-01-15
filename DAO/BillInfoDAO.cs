using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.Bill_Info WHERE id_Food = " + id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
        public void DeleteBillInfoByFoodIDBillID(int bill_id, int food_id)
        {
            DataProvider.Instance.ExecuteQuery("delete from BILL_inf WHERE id_bill= "+ bill_id + " and id_food= " + food_id);
        }
        public DataTable GetListBillInfByIDBill(int id_bill)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillInfByIDBill @id_bill", new object[] { id_bill });
        }
        public DateTime GetDateCheckOut(int id_bill)
        {
            return (DateTime)DataProvider.Instance.ExecuteScalar("SELECT dayCheckOut FROM BILL WHERE id=" + id_bill);
        }
        public String GetNameEmp(int id_bill)
        {
            return (String)DataProvider.Instance.ExecuteScalar("SELECT s.name FROM BILL b, STAFF s WHERE b.id_staff=s.id and b.id=" + id_bill);
        }
    }
}
