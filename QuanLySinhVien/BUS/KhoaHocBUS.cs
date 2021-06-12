using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;
using QuanLySinhVien.Data;
using QuanLySinhVien.Data.Reponsitories;
using QuanLySinhVien.Data.Infrastucture;

namespace QuanLySinhVien.BUS
{
    public interface IKhoaHocBUS
    {
        void Add(string maKH, DateTime namBatDau, DateTime namKetThuc);

        void Update(string maKH, DateTime namBatDau, DateTime namKetThuc);

        void Delete(string maKH);

        IEnumerable<KhoaHoc> GetAll();

    }
    public class KhoaHocBUS : IKhoaHocBUS
    {
        private static KhoaHocBUS instance;

        public static KhoaHocBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoaHocBUS();
                return instance;
            }
        }
        public void Add(string maKH, DateTime namBatDau, DateTime namKetThuc)
        {
            var a = new KhoaHoc
            {
                MaKH = maKH,
                NamKetThuc = namKetThuc,
                NamBatDau = namBatDau
            };
            UnitOfWork.Instance.KhoaHocs.Add(a);
            UnitOfWork.Instance.Complete();
        }

        public void Delete(string maKH)
        {
            KhoaHoc a = UnitOfWork.Instance.KhoaHocs.GetSingleById(maKH);
            UnitOfWork.Instance.KhoaHocs.Delete(a);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<KhoaHoc> GetAll()
        {
            return UnitOfWork.Instance.KhoaHocs.GetAll(); 
        }
        public void Update(string maKH, DateTime namBatDau, DateTime namKetThuc)
        {
            KhoaHoc a = UnitOfWork.Instance.KhoaHocs.GetSingleById(maKH);
            a.NamBatDau = namBatDau;
            a.NamKetThuc = namKetThuc;
            UnitOfWork.Instance.KhoaHocs.Update(a);
            UnitOfWork.Instance.Complete();
        }
    }
}
