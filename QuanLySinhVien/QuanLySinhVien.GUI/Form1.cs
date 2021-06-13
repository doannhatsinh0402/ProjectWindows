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
using QuanLySinhVien.Model.Common;

namespace QuanLySinhVien.GUI
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dsMH = MonHocBUS.Instance.GetAll();
            var smallDsMH = dsMH.Select(c => new { c.MaMH, c.TenMH });
            dataGridView1.DataSource = smallDsMH.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh;
            ngaysinh = dtpickerNS.Value;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text;
            MonHocBUS.Instance.Delete(maMH);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text;
            string tenMH = txtTenMH.Text;
            int soTC = 0;
            if (int.TryParse(txtSoTC.Text, out soTC));
            string maMHTQ = txtMaMHTQ.Text;
            MonHocBUS.Instance.Update(maMH, tenMH, soTC, maMHTQ);
        }

        private void chkNam_Click(object sender, EventArgs e)
        {
            chkNu.CheckState = CheckState.Unchecked;
        }

        private void chkNu_Click(object sender, EventArgs e)
        {
            chkNam.CheckState = CheckState.Unchecked;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
