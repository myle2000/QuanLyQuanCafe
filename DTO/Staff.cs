using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Staff
    {
        private int id;
        private string name;
        private string sdt;
        private string address;
        private string sex;
        private int salary;
        private int status;
        public Staff(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Sdt = row["sdt"].ToString();
            this.Address = row["Address"].ToString();
            this.Sex = row["Sex"].ToString();
            this.Salary = (int)row["Salary"];
            this.Status = (int)row["Status"];

        }

        public Staff(int id, string name, string sdt, string address, string sex, int salary, int status)
        {
            this.Id = id;
            this.Name = name;
            this.Sdt = sdt;
            this.Address = address;
            this.Sex = sex;
            this.Salary = salary;
            this.Status = status;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Address { get => address; set => address = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Salary { get => salary; set => salary = value; }
        public int Status { get => status; set => status = value; }
    }
}
