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
        void Add(string maKhoa, string tenKhoa, string maTruongKhoa);

        void Update(string maKhoa, string tenKhoa, string maTruongKhoa);

        void Delete(string maKhoa);

        IEnumerable<Khoa> GetAll();
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

        public void Delete(string maKhoa)
        {
            Khoa k = UnitOfWork.Instance.Khoas.GetSingleById(maKhoa);
            UnitOfWork.Instance.Khoas.Delete(k);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<Khoa> GetAll()
        {
            return UnitOfWork.Instance.Khoas.GetAll();
        }

        public void Update(string maKhoa, string tenKhoa, string maTruongKhoa)
        {
            Khoa k = UnitOfWork.Instance.Khoas.GetSingleById(maKhoa);
            k.TenKhoa = tenKhoa;
            k.MaTruongKhoa = maTruongKhoa;
            UnitOfWork.Instance.Khoas.Update(k);
            UnitOfWork.Instance.Complete();
        }
    }
}
