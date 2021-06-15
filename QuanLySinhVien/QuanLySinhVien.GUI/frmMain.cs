using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void hêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void xemDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void XemDanhMuc(int intDanhMuc)
        {
            Form frm = new frmXemDanhMuc();
            frm.Text = intDanhMuc.ToString();
            frm.ShowDialog();
        }

        private void damnhMụcKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        private void danhMụcGiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }

        private void danhMụcSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        private void danhMụcMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }

        private void danhMụcLớpHọcPhầnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }

        private void trangQuanLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmQuanLy();
            frm.ShowDialog();
        }
    }
}
