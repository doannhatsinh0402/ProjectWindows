using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using QuanLySinhVien.Model.Common;

namespace BUS
{
    public interface IGiangVienBUS
    {
        void Add(string maGV, string tenGV, GioiTinh gioiTinh
            , string diaChi, string sdt, string email, string maKhoa);

        void Update(string maGV, string tenGV, GioiTinh gioiTinh
            , string diaChi, string sdt, string email, string maKhoa);

        void Delete(string maGV);

        IEnumerable<GiangVien> GetAll();
    }
    public class GiangVienBUS : IGiangVienBUS
    {
        public void Add(string maGV, string tenGV, GioiTinh gioiTinh, string diaChi, string sdt, string email, string maKhoa)
        {
            var gv = new GiangVien
            { 
                TenGV = tenGV,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                Sdt = sdt,
                Email = email,
                MaKhoa = maKhoa
            };
            UnitOfWork.Instance.GiangViens.Add(gv);
            UnitOfWork.Instance.Complete();
        }

        public void Delete(string maGV)
        {
            GiangVien gv = UnitOfWork.Instance.GiangViens.GetSingleById(maGV);
            UnitOfWork.Instance.GiangViens.Delete(gv);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<GiangVien> GetAll()
        {
            return UnitOfWork.Instance.GiangViens.GetAll();
        }

        public void Update(string maGV, string tenGV, GioiTinh gioiTinh, string diaChi, string sdt, string email, string maKhoa)
        {
            GiangVien gv = UnitOfWork.Instance.GiangViens.GetSingleById(maGV);
            gv.TenGV = tenGV;
            gv.GioiTinh = gioiTinh;
            gv.DiaChi = diaChi;
            gv.Sdt = sdt;
            gv.Email = email;
            gv.MaKhoa = maKhoa;
            UnitOfWork.Instance.GiangViens.Update(gv);
            UnitOfWork.Instance.Complete();
        }
    }
}
