using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using QuanLySinhVien.Model.Common;

namespace QuanLySinhVien.BUS
{
    public interface IGiangVienBUS
    {
        void Add(string maGV, string tenGV, GioiTinh gioiTinh
            , string diaChi, string sdt, string email, string maKhoa);

        void Update(string maGV, string tenGV, GioiTinh gioiTinh
            , string diaChi, string sdt, string email, string maKhoa);

        void Delete(string maGV);
        int CountLopHP(string maGV);


        IEnumerable<GiangVien> GetAll(string[] includes = null);
    }
    public class GiangVienBUS : IGiangVienBUS
    {
        private static GiangVienBUS instance;

        public static GiangVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiangVienBUS();
                return instance;
            }
        }
        public void Add(string maGV, string tenGV, GioiTinh gioiTinh, string diaChi, string sdt, string email, string maKhoa)
        {
            var gv = new GiangVien
            { 
                MaGV = maGV,
                TenGV = tenGV,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                Sdt = sdt,
                Email = email,
                MaKhoa = maKhoa,
            };
            UnitOfWork.Instance.GiangViens.Add(gv);
            UnitOfWork.Instance.Complete();
        }

        public int CountLopHP(string maGV)
        {
            return UnitOfWork.Instance.LopHPs.Count(e => e.MaGV == maGV);
        }
        public void Delete(string maGV)
        {
            GiangVien gv = UnitOfWork.Instance.GiangViens.GetSingleById(maGV);
            UnitOfWork.Instance.GiangViens.Delete(gv);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<GiangVien> GetAll(string[] includes = null)
        {
            return UnitOfWork.Instance.GiangViens.GetAll(includes);
        }
        public void Update(string maGV, string tenGV, GioiTinh gioiTinh
            , string diaChi, string sdt, string email, string maKhoa)
        {
            GiangVien gv = UnitOfWork.Instance.GiangViens.GetSingleById(maGV);
            if (gv == null)
            {
                this.Add(maGV, tenGV, gioiTinh, diaChi, sdt, email, maKhoa);
            }
            else
            {
                gv.TenGV = tenGV;
                gv.GioiTinh = gioiTinh;
                gv.DiaChi = diaChi;
                gv.Sdt = sdt;
                gv.Email = email;
                gv.MaKhoa = maKhoa;
                UnitOfWork.Instance.GiangViens.Update(gv);
            }
            UnitOfWork.Instance.Complete();
        }
    }
}
