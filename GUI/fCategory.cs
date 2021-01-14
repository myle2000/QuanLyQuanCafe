using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DAO;

namespace QuanLyQuanCafe.GUI
{
    public partial class fCategory : Form
    {
        public fCategory()
        {
            InitializeComponent();
            LoadData();
        }
        BindingSource foodList = new BindingSource();
        BindingSource categoryList = new BindingSource();

        private void fUser_Load(object sender, EventArgs e)
        {
        }
        void LoadData()
        {
            dtgvCategory.DataSource = categoryList;
            LoadListCategory();
            AddCategoryBinding();
        }
        void AddCategoryBinding()
        {
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            categoryList.DataSource = CategoryDAO.Instance.SearchCategoryByName(txbFindCategory.Text);
            txbFindCategory.Text = "";
        }
    }
}
