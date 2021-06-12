using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BUS
{
    public interface ILopHPBUS
    {
        void Add(string maLHP, string maMH, string maGV, int namHoc, int hocKy);

        void Update(string maLHP, string maMH, string maGV, int namHoc, int hocKy);

        void Delete(string maLHP);

        IEnumerable<LopHP> GetAll();
    }
    public class LopHPBUS : ILopHPBUS
    {
        private static LopHPBUS instance;

        public static LopHPBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopHPBUS();
                return instance;
            }
        }
        public void Add(string maLHP, string maMH, string maGV, int namHoc, int hocKy)
        {
            var l = new LopHP
            {
                MaMH = maMH,
                MaGV = maGV,
                NamHoc = namHoc,
                HocKy = hocKy
            };
            UnitOfWork.Instance.LopHPs.Add(l);
            UnitOfWork.Instance.Complete();
        }

        public void Delete(string maLHP)
        {
            LopHP l = UnitOfWork.Instance.LopHPs.GetSingleById(maLHP);
            UnitOfWork.Instance.LopHPs.Delete(l);
            UnitOfWork.Instance.Complete();
        }

        public IEnumerable<LopHP> GetAll()
        {
            return UnitOfWork.Instance.LopHPs.GetAll();
        }

        public void Update(string maLHP, string maMH, string maGV, int namHoc, int hocKy)
        {
            LopHP l = UnitOfWork.Instance.LopHPs.GetSingleById(maLHP);
            l.MaMH = maMH;
            l.MaGV = maGV;
            l.NamHoc = namHoc;
            l.HocKy = hocKy;
            UnitOfWork.Instance.LopHPs.Update(l);
            UnitOfWork.Instance.Complete();
        }
    }
}
