using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public interface IDiemBUS
    {
        void Add(string maSV, string maMH, int diemQT, int diemThi, int diemTB);

        void Update(string maSV, string maMH, int diemQT, int diemThi, int diemTB);

        void Delete(string maSV, string maMH);

        IEnumerable<Diem> GetAll();
    }
    public class DiemBUS : IDiemBUS
    {
        public void Add(string maSV, string maMH, int diemQT, int diemThi, int diemTB)
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
            var d = UnitOfWork.Instance.Diems.GetMany(e => e.MaSV == maSV && e.MaMH == maMH ).First();
            UnitOfWork.Instance.Diems.Delete(d);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<Diem> GetAll()
        {
            return UnitOfWork.Instance.Diems.GetAll();
        }

        public void Update(string maSV, string maMH, int diemQT, int diemThi, int diemTB)
        {
            Diem d = UnitOfWork.Instance.Diems.GetMany(e => e.MaSV == maSV && e.MaMH == maMH).First();
            d.DiemQT = diemQT;
            d.DiemThi = diemThi;
            d.DiemTB = diemTB;
            UnitOfWork.Instance.Diems.Update(d);
        }
    }
}
