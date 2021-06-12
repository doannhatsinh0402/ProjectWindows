using QuanLySinhVien.Data.Reponsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QLSVDbContext _context;
        private static UnitOfWork instance;

        public static UnitOfWork Instance
        {
            get
            {
                if (instance == null)
                    instance = new UnitOfWork(new QLSVDbContext());
                return instance;
            }
        }
        public UnitOfWork(QLSVDbContext context)
        {
            _context = context;
            KhoaHocs = new KhoaHocReponsitory(_context);
            Diems = new DiemReponsitory(_context);
            GiangViens = new GiangVienReponsitory(_context);
            Khoas = new KhoaReponsitory(_context);
            LopHPs = new LopHPReponsitory(_context);
            MonHocs = new MonHocReponsitory(_context);
            SinhViens = new SinhVienReponsitory(_context);

        }

        public IKhoaHocReponsitory KhoaHocs { get; private set; }

        public IDiemReponsitory Diems { get; private set; }

        public IGiangVienReponsitory GiangViens { get; private set; }


        public IKhoaReponsitory Khoas { get; private set; }


        public ILopHPReponsitory LopHPs { get; private set; }


        public IMonHocReponsitory MonHocs { get; private set; }


        public ISinhVienReponsitory SinhViens { get; private set; }


        /*   public ICourseRepository Courses { get; private set; }
public IAuthorRepository Authors { get; private set; }*/

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
