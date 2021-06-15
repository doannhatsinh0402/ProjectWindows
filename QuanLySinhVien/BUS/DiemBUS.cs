using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BUS
{
    public interface IDiemBUS
    {
        void Add(string maSV, string maMH, float diemQT, float diemThi, float diemTB);

        void Update(string maSV, string maMH, float diemQT, float diemThi, float diemTB);

        void Delete(string maSV, string maMH);
        IEnumerable<Diem> GetMany(Expression<Func<Diem, bool>> where);

        IEnumerable<Diem> GetAll();
    }
    public class DiemBUS :  IDiemBUS
    {
        private static DiemBUS instance;

        public static DiemBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiemBUS();
                return instance;
            }
        }
        public void Add(string maSV, string maMH, float diemQT, float diemThi, float diemTB)
        {
            
            var d = new Diem
            {
                MaSV = maSV,
                MaMH = maMH,
                DiemQT = diemQT,
                DiemThi = diemThi,
                DiemTB = diemTB
            };
            UnitOfWork.Instance.Diems.Add(d);
            UnitOfWork.Instance.Complete();
        }

        public void Delete(string maSV, string maMH)
        {
            var d = UnitOfWork.Instance.Diems.GetMany(e =>e.MaSV == maSV && e.MaMH == maMH ).FirstOrDefault();
            UnitOfWork.Instance.Diems.Delete(d);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<Diem> GetAll()
        {
            return UnitOfWork.Instance.Diems.GetAll();
        }

        public IEnumerable<Diem> GetMany(Expression<Func<Diem, bool>> where)
        {
            return UnitOfWork.Instance.Diems.GetMany(where);
        }

        public void Update(string maSV, string maMH, float diemQT, float diemThi, float diemTB)
        {
            Diem d = UnitOfWork.Instance.Diems.GetMany(e => e.MaSV == maSV && e.MaMH == maMH).FirstOrDefault();
            if (d == null)
            {
                this.Add(maSV, maMH, diemQT, diemThi, diemTB);
            }
            else
            {
                d.DiemQT = diemQT;
                d.DiemThi = diemThi;
                d.DiemTB = diemTB;
                UnitOfWork.Instance.Diems.Update(d);
            }
            UnitOfWork.Instance.Complete();
        }
    }
}
