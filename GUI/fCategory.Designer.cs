
namespace QuanLyQuanCafe.GUI
{
    partial class fCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel24 = new System.Windows.Forms.Panel();
            this.txbFindCategory = new System.Windows.Forms.TextBox();
            this.btnSearchCategory = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.txbCategoryName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txbCategoryID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgvCategory = new System.Windows.Forms.DataGridView();
            this.cIDCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel24.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.txbFindCategory);
            this.panel24.Controls.Add(this.btnSearchCategory);
            this.panel24.Location = new System.Drawing.Point(959, 18);
            this.panel24.Margin = new System.Windows.Forms.Padding(6);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(566, 100);
            this.panel24.TabIndex = 10;
            // 
            // txbFindCategory
            // 
            this.txbFindCategory.Location = new System.Drawing.Point(6, 33);
            this.txbFindCategory.Margin = new System.Windows.Forms.Padding(6);
            this.txbFindCategory.Name = "txbFindCategory";
            this.txbFindCategory.Size = new System.Drawing.Size(394, 30);
            this.txbFindCategory.TabIndex = 5;
            // 
            // btnSearchCategory
            // 
            this.btnSearchCategory.Location = new System.Drawing.Point(416, 21);
            this.btnSearchCategory.Margin = new System.Windows.Forms.Padding(6);
            this.btnSearchCategory.Name = "btnSearchCategory";
            this.btnSearchCategory.Size = new System.Drawing.Size(144, 57);
            this.btnSearchCategory.TabIndex = 4;
            this.btnSearchCategory.Text = "Tìm";
            this.btnSearchCategory.UseVisualStyleBackColor = true;
            this.btnSearchCategory.Click += new System.EventHandler(this.btnSearchCategory_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Location = new System.Drawing.Point(957, 131);
            this.panel12.Margin = new System.Windows.Forms.Padding(6);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(570, 666);
            this.panel12.TabIndex = 9;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.txbCategoryName);
            this.panel15.Controls.Add(this.label7);
            this.panel15.Location = new System.Drawing.Point(6, 103);
            this.panel15.Margin = new System.Windows.Forms.Padding(6);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(558, 84);
            this.panel15.TabIndex = 2;
            // 
            // txbCategoryName
            // 
            this.txbCategoryName.Location = new System.Drawing.Point(250, 16);
            this.txbCategoryName.Margin = new System.Windows.Forms.Padding(6);
            this.txbCategoryName.Name = "txbCategoryName";
            this.txbCategoryName.Size = new System.Drawing.Size(298, 30);
            this.txbCategoryName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên danh mục:";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.txbCategoryID);
            this.panel16.Controls.Add(this.label8);
            this.panel16.Location = new System.Drawing.Point(6, 6);
            this.panel16.Margin = new System.Windows.Forms.Padding(6);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(558, 84);
            this.panel16.TabIndex = 1;
            // 
            // txbCategoryID
            // 
            this.txbCategoryID.Location = new System.Drawing.Point(250, 16);
            this.txbCategoryID.Margin = new System.Windows.Forms.Padding(6);
            this.txbCategoryID.Name = "txbCategoryID";
            this.txbCategoryID.ReadOnly = true;
            this.txbCategoryID.Size = new System.Drawing.Size(298, 30);
            this.txbCategoryID.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 33);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID:";
            // 
            // dtgvCategory
            // 
            this.dtgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIDCategory,
            this.cNameCategory});
            this.dtgvCategory.Location = new System.Drawing.Point(15, 15);
            this.dtgvCategory.Margin = new System.Windows.Forms.Padding(6);
            this.dtgvCategory.Name = "dtgvCategory";
            this.dtgvCategory.RowHeadersWidth = 62;
            this.dtgvCategory.Size = new System.Drawing.Size(914, 756);
            this.dtgvCategory.TabIndex = 8;
            // 
            // cIDCategory
            // 
            this.cIDCategory.DataPropertyName = "ID";
            this.cIDCategory.HeaderText = "ID";
            this.cIDCategory.MinimumWidth = 6;
            this.cIDCategory.Name = "cIDCategory";
            this.cIDCategory.Width = 200;
            // 
            // cNameCategory
            // 
            this.cNameCategory.DataPropertyName = "Name";
            this.cNameCategory.HeaderText = "Tên danh mục";
            this.cNameCategory.MinimumWidth = 6;
            this.cNameCategory.Name = "cNameCategory";
            this.cNameCategory.Width = 300;
            // 
            // fCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panel24);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.dtgvCategory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fCategory";
            this.Text = "Danh sách danh mục";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TextBox txbFindCategory;
        private System.Windows.Forms.Button btnSearchCategory;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox txbCategoryName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox txbCategoryID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtgvCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameCategory;
    }
}