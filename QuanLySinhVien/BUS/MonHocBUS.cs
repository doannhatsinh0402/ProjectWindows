using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BUS
{
    public interface IMonHocBUS
    {
        void Add(string maMH, string tenMH, int soTC, string maMHTQ);

        void Update(string maMH, string tenMH, int soTC, string maMHTQ);

        void Delete(string maMH);

        IEnumerable<MonHoc> GetAll();
    }
    public class MonHocBUS : IMonHocBUS
    {
        private static MonHocBUS instance;

        public static MonHocBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new MonHocBUS();
                return instance;
            }
        }
        public void Add(string maMH, string tenMH, int soTC, string maMHTQ)
        {
            var m = new MonHoc
            {
                TenMH = tenMH,
                SoTC = soTC,
                MaMHTQ = maMHTQ
            };
            UnitOfWork.Instance.MonHocs.Add(m);
            UnitOfWork.Instance.Complete();
        }

        public void Delete(string maMH)
        {
            MonHoc m = UnitOfWork.Instance.MonHocs.GetSingleById(maMH);
            UnitOfWork.Instance.MonHocs.Delete(m);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<MonHoc> GetAll()
        {
            return UnitOfWork.Instance.MonHocs.GetAll();
        }

        public void Update(string maMH, string tenMH, int soTC, string maMHTQ)
        {

            MonHoc m = UnitOfWork.Instance.MonHocs.GetSingleById(maMH);
            m.TenMH = tenMH;
            m.SoTC = soTC;
            m.MaMHTQ = maMHTQ;
            UnitOfWork.Instance.MonHocs.Update(m);
            UnitOfWork.Instance.Complete();
        }
    }
}
