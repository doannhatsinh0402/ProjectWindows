using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.Model.Common;


namespace QuanLySinhVien.GUI
{
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        DialogResult DeleteQuestion()
        {
            var result = MessageBox.Show("Chắc không zậy? Bấm OK là mất tiêu luôn á", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }
        //
        void Exit()
        {
            DialogResult traloi;
            traloi = MessageBox.Show(" Thoát luôn hả?", "Nhắc nhẹ",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) this.Close();
        }
        void showDiem()
        {
            dgvDiem.DataSource = DiemBUS.Instance.GetAll().Select(
                c => new { c.MaSV, c.MaMH, c.DiemQT, c.DiemThi, c.DiemTB }
                ).ToList();
        }
        void showGiangVien()
        {
            dgvGV.DataSource = GiangVienBUS.Instance.GetAll().Select(
                        c => new { c.MaGV, c.MaKhoa, c.TenGV, c.GioiTinh, c.DiaChi, c.Sdt, c.Email, }
                        ).ToList();
        }
        void showKhoa()
        {
            dgvKhoa.DataSource = KhoaBUS.Instance.GetAll().Select(
                        c => new { c.MaKhoa, c.TenKhoa, c.MaTruongKhoa }
                        ).ToList();
        }
        void showLopHP()
        {
            dgvLHP.DataSource = LopHPBUS.Instance.GetAll().Select(
                      c => new { c.MaLHP, c.MaMH, c.MaGV, c.NamHoc, c.HocKy }
                      )
                      .ToList();
        }
        void showMonHoc()
        {
            dgvMH.DataSource = MonHocBUS.Instance.GetAll().Select(
                        c => new { c.MaMH, c.TenMH, c.SoTC }
                        ).ToList();
        }
        void showSinhVien()
        {
            dgvSV.DataSource = SinhVienBUS.Instance.GetAll().Select(
                        c => new
                        {
                            c.MaSV,
                            c.TenSV,
                            c.Lop,
                            c.NgaySinh,
                            c.GioiTinh,
                            c.DiaChi,
                            c.QueQuan,
                            c.Sdt
                        ,
                            c.Email,
                            c.MaKhoa,
                            c.MaKH
                        }
                        ).ToList();
        }

        //
        // QL Khoa
        private void bthThoat_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        // QL Giảng Viên
        private void chkNuGV_Click(object sender, EventArgs e)
        {
            chkNuGV.CheckState = CheckState.Unchecked;
        }

        private void chkNamGV_Click(object sender, EventArgs e)
        {
            chkNuGV.CheckState = CheckState.Unchecked;
        }
        private void btnAddGV_Click(object sender, EventArgs e)
        {
            string maGV = txtMaGV.Text;
            string tenGV = txtTenGV.Text;
            GioiTinh gioiTinh = chkNamGV.CheckState == CheckState.Checked ? GioiTinh.Nam : GioiTinh.Nu;
            string diaChi = txtDCGV.Text;
            string sdt = txtDTGV.Text;
            string email = txtEmailGV.Text;
            string maKhoa = txtKhoaGV.Text.Trim();
            if (Search(maGV, dgvGV, 0) == -1)
                GiangVienBUS.Instance.Add(maGV, tenGV, gioiTinh, diaChi, sdt, email, maKhoa);
            showGiangVien();
        }
        private void btnDelGV_Click(object sender, EventArgs e)
        {
            if (DeleteQuestion().Equals(DialogResult.OK))
            {
                GiangVienBUS.Instance.Delete(this.txtMaGV.Text);
                showGiangVien();
            }
        }
        private void btnUpdateGV_Click(object sender, EventArgs e)
        {
            string maGV = txtMaGV.Text;
            string tenGV = txtTenGV.Text;
            GioiTinh gioiTinh = chkNamGV.CheckState == CheckState.Checked ? GioiTinh.Nam : GioiTinh.Nu;
            string diaChi = txtDCGV.Text;
            string sdt = txtDTGV.Text;
            string email = txtEmailGV.Text;
            string maKhoa = txtKhoaGV.Text;
            GiangVienBUS.Instance.Update(maGV, tenGV, gioiTinh, diaChi, sdt, email, maKhoa);
            showGiangVien();
        }

        private void btnCanGV_Click(object sender, EventArgs e)
        {
            dgvGV.DataSource = GiangVienBUS.Instance.GetAll().ToList();
        }
        private void btnExitGV_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
        // QL Sinh Vien
        private void checkNamSV_Click(object sender, EventArgs e)
        {
            checkNamSV.CheckState = CheckState.Unchecked;
        }

        private void checkNuSV_Click(object sender, EventArgs e)
        {
            checkNuSV.CheckState = CheckState.Unchecked;
        }
        private void btnAddSV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string tenSV = txtTenSV.Text;
            string lop = txtLop.Text;
            DateTime ngaySinh;
            ngaySinh = dtpNgSinh.Value;
            GioiTinh gioiTinh = chkNamGV.CheckState == CheckState.Checked ? GioiTinh.Nam : GioiTinh.Nu;
            string diaChi = txtDiaChiSV.Text;
            string queQuan = txtQQ.Text;
            string sdt = txtDienThoaiSV.Text;
            string email = txtEmaiSV.Text;
            string maKhoa = txtKhoaSV.Text;
            string maKH = txtKH.Text;
            if (Search(maSV, dgvSV, 0) == -1)
                SinhVienBUS.Instance.Add(maSV, tenSV, lop, ngaySinh, gioiTinh, diaChi, queQuan, sdt, email, maKhoa, maKH);
            showSinhVien();

        }

        private void btnDelSV_Click(object sender, EventArgs e)
        {
            if (DeleteQuestion().Equals(DialogResult.OK))
            {
                SinhVienBUS.Instance.Delete(this.txtMaSV.Text);
                showSinhVien();
            }
        }
        private void btnUpdSV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string tenSV = txtTenSV.Text;
            string lop = txtLop.Text;
            DateTime ngaySinh;
            ngaySinh = dtpNgSinh.Value;
            GioiTinh gioiTinh = checkNamSV.CheckState == CheckState.Checked ? GioiTinh.Nam : GioiTinh.Nu;
            string diaChi = txtDiaChiSV.Text;
            string queQuan = txtQQ.Text;
            string sdt = txtDienThoaiSV.Text;
            string email = txtEmaiSV.Text;
            string maKhoa = txtKhoaSV.Text;
            string maKH = txtKH.Text;
            SinhVienBUS.Instance.Update(maSV, tenSV, lop, ngaySinh, gioiTinh, diaChi, queQuan, sdt, email, maKhoa, maKH);
            showSinhVien();
        }

        private void btnCanSV_Click(object sender, EventArgs e)
        {
            dgvSV.DataSource = SinhVienBUS.Instance.GetAll().ToList();
        }
        private void btnExitSV_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
        bool SearchDouble(string value1, string value2, int cell1, int cell2, DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[cell1].Value.ToString().Equals(value1)
                    && row.Cells[cell2].Value.ToString().Equals(value2))
                    return true;
            }
            return false;
        }
        private void btnAddDiem_Click(object sender, EventArgs e)
        {
            string maSV = this.cbMaSV.SelectedValue.ToString();
            string maMH = this.cbMaMH.SelectedValue.ToString();
            float diemQT = float.Parse(this.txtQT.Text);
            float diemThi = float.Parse(this.txtThi.Text);
            float diemTB = (diemQT + diemThi) / 2;
            if (!SearchDouble(maSV, maMH, 0, 1, dgvDiem))
                DiemBUS.Instance.Add(maSV, maMH, diemQT, diemThi, diemTB);
            showDiem();
        }
        private void btnDelDiem_Click(object sender, EventArgs e)
        {
            if (DeleteQuestion().Equals(DialogResult.OK))
            {
                string maSV = this.cbMaSV.SelectedValue.ToString();
                string maMH = this.cbMaMH.SelectedValue.ToString();
                DiemBUS.Instance.Delete(maSV, maMH);
                showDiem();
            }
        }
        private void btnUpdDiem_Click(object sender, EventArgs e)
        {
            string maSV = this.cbMaSV.SelectedValue.ToString();
            string maMH = this.cbMaMH.SelectedValue.ToString();
            float diemQT = float.Parse(this.txtQT.Text);
            float diemThi = float.Parse(this.txtThi.Text);
            float diemTB = (diemQT + diemThi) / 2;
            DiemBUS.Instance.Update(maSV, maMH, diemQT, diemThi, diemTB);
            showDiem();
        }

        private void btnCanDiem_Click(object sender, EventArgs e)
        {
            dgvDiem.DataSource = DiemBUS.Instance.GetAll().ToList();
        }
        // exit
        private void button8_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
        //QL Lớp HP
        private void btnAddLopHP_Click(object sender, EventArgs e)
        {
            string maLHP = txtMaLHP.Text;
            string maMH = txtMH.Text;
            string maGV = txtGV.Text;
            int namHoc = Convert.ToInt32(txtNH.Text);
            int hocKy = Convert.ToInt32(txtHK.Text);
            if (Search(maLHP, dgvLHP, 0) == -1)
                LopHPBUS.Instance.Add(maLHP, maMH, maGV, namHoc, hocKy);
            showLopHP();
        }
        private void btnDelLopHP_Click(object sender, EventArgs e)
        {
            if (DeleteQuestion().Equals(DialogResult.OK))
            {
                LopHPBUS.Instance.Delete(this.txtMaLHP.Text);
                showLopHP();
            }
        }
        private void btnUpdLopHP_Click(object sender, EventArgs e)
        {
            string maLHP = txtMaLHP.Text;
            string maMH = txtMH.Text;
            string maGV = txtGV.Text;
            int namHoc = Convert.ToInt32(txtNH.Text);
            int hocKy = Convert.ToInt32(txtHK.Text);
            LopHPBUS.Instance.Update(maLHP, maMH, maGV, namHoc, hocKy);
            showLopHP();
        }

        private void btnCanLopHP_Click(object sender, EventArgs e)
        {
            dgvLHP.DataSource = LopHPBUS.Instance.GetAll().ToList();
        }

        private void btnExitLopHP_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
        // QL Môn Học
        // Add Môn Học
        private void button6_Click(object sender, EventArgs e)
        {
            string maMH = this.txtMaMH.Text;
            string tenMH = this.txtTenMH.Text;
            int soTC = Convert.ToInt32(this.txtSTC.Text);
            if (Search(maMH, dgvMH, 0) == -1)
                MonHocBUS.Instance.Add(maMH, tenMH, soTC);
            showMonHoc();
        }
        private void btnDelMH_Click(object sender, EventArgs e)
        {
            if (DeleteQuestion().Equals(DialogResult.OK))
            {
                string maMH = txtMaMH.Text;
                MonHocBUS.Instance.Delete(maMH);
                showMonHoc();
            }
        }

        private void btnUpdateMH_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text;
            string tenMH = txtTenMH.Text;
            int soTC = Convert.ToInt32(txtSTC.Text);
            MonHocBUS.Instance.Update(maMH, tenMH, soTC);
            showMonHoc();
        }

        private void btnCancelMH_Click(object sender, EventArgs e)
        {
            dgvMH.DataSource = MonHocBUS.Instance.GetAll().ToList();
        }

        private void btnExitMH_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            showKhoa();
            showGiangVien();
            showDiem();
            showLopHP();
            showMonHoc();
            showSinhVien();
            cbMaMH.DataSource = MonHocBUS.Instance.GetAll().Select(c => c.MaMH).ToList();
            cbMaSV.DataSource = SinhVienBUS.Instance.GetAll().Select(c => c.MaSV).ToList();
        }
        int Search(string searchValue, DataGridView dgv, int cellIndex)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[cellIndex].Value.ToString().Equals(searchValue))
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string maKhoa = this.txtMaKhoa.Text;
            string tenKhoa = this.txtTenKhoa.Text;
            string maTruongKhoa = this.txtTruongKhoa.Text;
            if (Search(maKhoa, dgvKhoa, 0) == -1)
                KhoaBUS.Instance.Add(maKhoa, tenKhoa, maTruongKhoa);
            showKhoa();
        }
        private void btnReload_Click_1(object sender, EventArgs e)
        {
            dgvKhoa.DataSource = KhoaBUS.Instance.GetAll().ToList();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (DeleteQuestion().Equals(DialogResult.OK))
            {
                KhoaBUS.Instance.Delete(txtMaKhoa.Text);
                showKhoa();
            }
        }
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string maKhoa = this.txtMaKhoa.Text;
            string tenKhoa = this.txtTenKhoa.Text;
            string maTruongKhoa = this.txtTruongKhoa.Text;
            KhoaBUS.Instance.Update(maKhoa, tenKhoa, maTruongKhoa);
            showKhoa();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKhoa.CurrentCell.RowIndex;
            this.txtMaKhoa.Text = dgvKhoa.Rows[r].Cells[0].Value.ToString();
            this.txtTenKhoa.Text = dgvKhoa.Rows[r].Cells[1].Value.ToString();
            this.txtTruongKhoa.Text = dgvKhoa.Rows[r].Cells[2].Value.ToString();

            int k = KhoaBUS.Instance.CountGiangVien(txtMaKhoa.Text)
                + KhoaBUS.Instance.CountSinhVien(txtMaKhoa.Text);
            if (k > 0) btnDelKhoa.Enabled = false;
            else btnDelKhoa.Enabled = true;

        }

        private void chkNamGV_Click_1(object sender, EventArgs e)
        {
            if (chkNamGV.CheckState == CheckState.Checked)
                chkNuGV.CheckState = CheckState.Unchecked;
        }

        private void chkNuGV_Click_1(object sender, EventArgs e)
        {
            if (chkNuGV.CheckState == CheckState.Checked)
                chkNamGV.CheckState = CheckState.Unchecked;
        }

        private void dgvGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvGV.CurrentCell.RowIndex;
            this.txtMaGV.Text = dgvGV.Rows[r].Cells[0].Value.ToString();
            this.txtTenGV.Text = dgvGV.Rows[r].Cells[2].Value.ToString();
            this.txtKhoaGV.Text = dgvGV.Rows[r].Cells[1].Value.ToString();
            this.txtDTGV.Text = dgvGV.Rows[r].Cells[5].Value.ToString();
            this.txtEmailGV.Text = dgvGV.Rows[r].Cells[6].Value.ToString();
            this.txtDCGV.Text = dgvGV.Rows[r].Cells[4].Value.ToString();
            string gioiTinh = dgvGV.Rows[r].Cells[3].Value.ToString();
            if (gioiTinh == "Nam")
            {
                this.chkNamGV.CheckState = CheckState.Checked;
                this.chkNuGV.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.chkNuGV.CheckState = CheckState.Checked;
                this.chkNuGV.CheckState = CheckState.Unchecked;
            }
            int k = GiangVienBUS.Instance.CountLopHP(this.txtMaGV.Text);
            if (k > 0) btnDelGV.Enabled = false;
            else btnDelGV.Enabled = true;
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSV.CurrentCell.RowIndex;
            this.txtMaSV.Text = dgvSV.Rows[r].Cells[0].Value.ToString();
            this.txtTenSV.Text = dgvSV.Rows[r].Cells[1].Value.ToString();
            this.txtLop.Text = dgvSV.Rows[r].Cells[2].Value.ToString();
            this.dtpNgSinh.Value = Convert.ToDateTime(dgvSV.Rows[r].Cells[3].Value.ToString());
            string gioiTinh = dgvSV.Rows[r].Cells[4].Value.ToString();
            if (gioiTinh == "Nam")
            {
                this.checkNamSV.CheckState = CheckState.Checked;
                this.checkNuSV.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.checkNuSV.CheckState = CheckState.Checked;
                this.checkNamSV.CheckState = CheckState.Unchecked;
            }
            this.txtDiaChiSV.Text = dgvSV.Rows[r].Cells[5].Value.ToString();
            this.txtQQ.Text = dgvSV.Rows[r].Cells[6].Value.ToString();
            this.txtDienThoaiSV.Text = dgvSV.Rows[r].Cells[7].Value.ToString();
            this.txtEmaiSV.Text = dgvSV.Rows[r].Cells[8].Value.ToString();
            this.txtKhoaSV.Text = dgvSV.Rows[r].Cells[9].Value.ToString();
            this.txtKH.Text = dgvSV.Rows[r].Cells[10].Value.ToString();
            int k = SinhVienBUS.Instance.CountDiem(this.txtMaSV.Text);
            if (k > 0) btnDelSV.Enabled = false;
            else btnDelSV.Enabled = true;

        }

        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDiem.CurrentCell.RowIndex;
            this.cbMaSV.SelectedIndex = cbMaSV.FindStringExact(
                dgvDiem.Rows[r].Cells[0].Value.ToString());
            this.cbMaMH.SelectedIndex = cbMaMH.FindStringExact(
                dgvDiem.Rows[r].Cells[1].Value.ToString());
            this.lblTenSV.Text = SinhVienBUS.Instance.GetSingleById(cbMaSV.SelectedValue.ToString()).TenSV;
            this.txtQT.Text = dgvDiem.Rows[r].Cells[2].Value.ToString();
            this.txtThi.Text = dgvDiem.Rows[r].Cells[3].Value.ToString();
        }

        private void cbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTenSV.Text = SinhVienBUS.Instance.GetSingleById(cbMaSV.SelectedValue.ToString()).TenSV;
        }

        private void dgvLHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLHP.CurrentCell.RowIndex;
            this.txtMaLHP.Text = dgvLHP.Rows[r].Cells[0].Value.ToString();
            this.txtMH.Text = dgvLHP.Rows[r].Cells[1].Value.ToString();
            this.txtGV.Text = dgvLHP.Rows[r].Cells[2].Value.ToString();
            this.txtNH.Text = dgvLHP.Rows[r].Cells[3].Value.ToString();
            this.txtHK.Text = dgvLHP.Rows[r].Cells[4].Value.ToString();

        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvMH.CurrentCell.RowIndex;
            this.txtMaMH.Text = dgvMH.Rows[r].Cells[0].Value.ToString();
            this.txtTenMH.Text = dgvMH.Rows[r].Cells[1].Value.ToString();
            this.txtSTC.Text = dgvMH.Rows[r].Cells[2].Value.ToString();
            int k = MonHocBUS.Instance.CountDiem(txtMaMH.Text)
                + MonHocBUS.Instance.CountLopHP(txtMaMH.Text);
            if (k > 0) btnDelMH.Enabled = false;
            else btnDelMH.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            showMonHoc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showKhoa();
        }


        private void checkNuSV_Click_1(object sender, EventArgs e)
        {
            if (checkNuSV.CheckState == CheckState.Checked)
                checkNamSV.CheckState = CheckState.Unchecked;
        }

        private void checkNamSV_Click_1(object sender, EventArgs e)
        {
            if (checkNamSV.CheckState == CheckState.Checked)
                checkNuSV.CheckState = CheckState.Unchecked;
        }
    }
}
  
