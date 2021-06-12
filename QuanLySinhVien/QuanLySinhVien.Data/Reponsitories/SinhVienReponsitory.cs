using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Reponsitories
{
    public interface ISinhVienReponsitory : IRepository<SinhVien>
    {

    }
    public class SinhVienReponsitory : RepositoryBase<SinhVien>, ISinhVienReponsitory
    {
        public SinhVienReponsitory(QLSVDbContext context) : base(context)
        {

        }
        public QLSVDbContext QLSVDbContext
        {
            get { return Context as QLSVDbContext; }
        }
    }
}
