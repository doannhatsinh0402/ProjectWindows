using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.Reponsitories;

namespace QuanLySinhVien.Data.Infrastucture
{
    public interface IUnitOfWork : IDisposable
    {
        IKhoaHocReponsitory KhoaHocs { get; }
        IDiemReponsitory Diems { get; }
        IGiangVienReponsitory GiangViens { get; }

        IKhoaReponsitory Khoas { get; }
        ILopHPReponsitory LopHPs { get; }
        IMonHocReponsitory MonHocs { get; }
        ISinhVienReponsitory SinhViens { get; }
        int Complete();
    }
}
