using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using QuanLySinhVien.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BUS
{
    public interface ISinhVienBUS
    {
        void Add(string maSV, string tenSV, string lop, DateTime ngaySinh, GioiTinh gioiTinh
            , string diaChi, string queQuan, string sdt, string email, string maKhoa, string maKH);

        void Update(string maSV, string tenSV, string lop, DateTime ngaySinh, GioiTinh gioiTinh
            , string diaChi, string queQuan, string sdt, string email, string maKhoa, string maKH);

        void Delete(string maSV);
        SinhVien GetSingleById(string maSV);
        int CountDiem(string maSV);
        IEnumerable<SinhVien> GetMany(Expression<Func<SinhVien, bool>> where);

        IEnumerable<SinhVien> GetAll();
    }
    public class SinhVienBUS : ISinhVienBUS
    {
        private static SinhVienBUS instance;

        public static SinhVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new SinhVienBUS();
                return instance;
            }
        }
        public void Add(string maSV, string tenSV, string lop, DateTime ngaySinh, GioiTinh gioiTinh
            , string diaChi, string queQuan, string sdt, string email, string maKhoa, string maKH)
        {
            var sv = new SinhVien
            {
                MaSV = maSV,
                TenSV = tenSV,
                Lop = lop,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                QueQuan = queQuan,
                Sdt = sdt,
                Email = email,
                MaKH = maKH,
                MaKhoa = maKhoa
            };
            UnitOfWork.Instance.SinhViens.Add(sv);
            UnitOfWork.Instance.Complete();
        }

        public int CountDiem(string maSV)
        {
            return UnitOfWork.Instance.Diems.Count(e => e.MaSV == maSV);
        }

        public void Delete(string maSV)
        {
            SinhVien sv = UnitOfWork.Instance.SinhViens.GetSingleById(maSV);
            UnitOfWork.Instance.SinhViens.Delete(sv);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<SinhVien> GetAll()
        {
            return UnitOfWork.Instance.SinhViens.GetAll();
        }

        public IEnumerable<SinhVien> GetMany(Expression<Func<SinhVien, bool>> where)
        {
            return UnitOfWork.Instance.SinhViens.GetMany(where);
        }

        public SinhVien GetSingleById(string maSV)
        {
            return UnitOfWork.Instance.SinhViens.GetSingleById(maSV);
        }

        public void Update(string maSV, string tenSV, string lop, DateTime ngaySinh
            , GioiTinh gioiTinh, string diaChi, string queQuan, string sdt, string email
            , string maKhoa, string maKH)
        {
            SinhVien sv = UnitOfWork.Instance.SinhViens.GetSingleById(maSV);
            if (sv == null)
            {
                this.Add(maSV, tenSV, lop, ngaySinh, gioiTinh, diaChi, queQuan, sdt, email, maKhoa, maKH);
            }
            else
            {
                sv.TenSV = tenSV;
                sv.Lop = lop;
                sv.NgaySinh = ngaySinh;
                sv.GioiTinh = gioiTinh;
                sv.DiaChi = diaChi;
                sv.QueQuan = queQuan;
                sv.Sdt = sdt;
                sv.Email = email;
                sv.MaKhoa = maKhoa;
                sv.MaKH = maKH;
                UnitOfWork.Instance.SinhViens.Update(sv);
            }
            UnitOfWork.Instance.Complete();
        }
    }
}
