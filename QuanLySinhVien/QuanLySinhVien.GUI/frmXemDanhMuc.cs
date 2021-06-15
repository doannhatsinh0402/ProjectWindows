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
    public partial class frmXemDanhMuc : Form
    {
        public frmXemDanhMuc()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            int intDM = Convert.ToInt32(this.Text);
            switch (intDM)
            {
                case 1:
                    lblDanhMuc.Text = "Danh Mục Khoa";
                    dataGridView1.DataSource = KhoaBUS.Instance.GetAll().Select(
                        c => new {c.MaKhoa,c.TenKhoa,c.MaTruongKhoa}
                        ).ToList();
                    break;
                case 2:
                    lblDanhMuc.Text = "Danh Mục Giảng Viên";
                    dataGridView1.DataSource = GiangVienBUS.Instance.GetAll().Select(
                        c => new {c.MaGV,c.MaKhoa, c.TenGV, c.GioiTinh, c.DiaChi,c.Sdt,c.Email,}
                        ).ToList();
                    break;
                case 3:
                    lblDanhMuc.Text = "Danh Mục Sinh Viên";
                    dataGridView1.DataSource = SinhVienBUS.Instance.GetAll().Select(
                        c => new {c.MaSV, c.TenSV,c.Lop,c.NgaySinh,c.GioiTinh,c.DiaChi,c.QueQuan,c.Sdt
                        ,c.Email,c.MaKhoa,c.MaKH}
                        ).ToList();
                    break;
                case 4:
                    lblDanhMuc.Text = "Danh Mục Môn Học";
                    dataGridView1.DataSource = MonHocBUS.Instance.GetAll().Select(
                        c => new {c.MaMH,c.TenMH,c.SoTC}
                        ).ToList();
                    break;
                case 5:
                    lblDanhMuc.Text = "Danh Mục Lớp Học Phần";
                    dataGridView1.DataSource = LopHPBUS.Instance.GetAll().Select(
                        c => new {c.MaLHP,c.MaMH,c.MaGV,c.NamHoc,c.HocKy}
                        )
                        .ToList();
                    break;
                default:
                    break;
            }
        }

        private void lblDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
