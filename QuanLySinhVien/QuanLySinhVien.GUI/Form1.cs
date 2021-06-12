using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.BUS;

namespace QuanLySinhVien.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = KhoaHocBUS.Instance.GetAll().ToList();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KhoaHocBUS.Instance.Delete("K19_CNTT");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime namBatDau = DateTime.Parse("3/2/2011");
            DateTime namKetThuc = DateTime.Parse("4/5/2020");
            KhoaHocBUS.Instance.Update("K1_KTDL", namBatDau, namKetThuc);
        }
    }
}
