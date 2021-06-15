using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BUS
{
    public interface IKhoaBUS
    {
        void Add(string maKhoa, string tenKhoa,string maTruongKhoa);

        void Update(string maKhoa, string tenKhoa,string maTruongKhoa);

        void Delete(string maKhoa);

        int CountGiangVien(string maKhoa);
        int CountSinhVien(string maKhoa);

        IEnumerable<Khoa> GetAll(string[] includes = null);
    }
    public class KhoaBUS : IKhoaBUS
    {
        private static KhoaBUS instance;

        public static KhoaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoaBUS();
                return instance;
            }
        }
        public void Add(string maKhoa, string tenKhoa, string maTruongKhoa)
        {
            var k = new Khoa
            {
                MaKhoa = maKhoa,
                TenKhoa = tenKhoa,
                MaTruongKhoa = maTruongKhoa
            };
            UnitOfWork.Instance.Khoas.Add(k);
            UnitOfWork.Instance.Complete();
        }

        public int CountGiangVien(string maKhoa)
        {
            return UnitOfWork.Instance.GiangViens.Count(e => e.MaKhoa == maKhoa);
        }

        public int CountSinhVien(string maKhoa)
        {
            return UnitOfWork.Instance.SinhViens.Count(e => e.MaKhoa == maKhoa);
        }

        public void Delete(string maKhoa)
        {
            Khoa k = UnitOfWork.Instance.Khoas.GetSingleById(maKhoa);
            UnitOfWork.Instance.Khoas.Delete(k);
            UnitOfWork.Instance.Complete();

        }
        public IEnumerable<Khoa> GetAll(string[] includes = null)
        {
            return UnitOfWork.Instance.Khoas.GetAll(includes);
        }

        public void Update(string maKhoa, string tenKhoa, string maTruongKhoa)
        {
            Khoa k = UnitOfWork.Instance.Khoas.GetSingleById(maKhoa);
            if (k == null)
            {
                this.Add(maKhoa, tenKhoa, maTruongKhoa);
            }
            else
            {
                k.TenKhoa = tenKhoa;
                k.MaTruongKhoa = maTruongKhoa;
                UnitOfWork.Instance.Khoas.Update(k);
            }
            UnitOfWork.Instance.Complete();
        }
    }
}
