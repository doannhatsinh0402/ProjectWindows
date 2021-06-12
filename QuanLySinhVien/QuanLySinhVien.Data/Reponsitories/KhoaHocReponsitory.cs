using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.Infrastucture;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.Reponsitories
{
    public interface IKhoaHocReponsitory : IRepository<KhoaHoc>
    {

    }
    public class KhoaHocReponsitory : RepositoryBase<KhoaHoc>, IKhoaHocReponsitory
    {
        public KhoaHocReponsitory(QLSVDbContext context) : base(context)
        {

        }
        public QLSVDbContext QLSVDbContext
        {
            get { return Context as QLSVDbContext; }
        }
    }
}
