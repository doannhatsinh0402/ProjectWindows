using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Model
{
    public class MonHoc
    {
        public MonHoc()
        {
            Diems = new HashSet<Diem>();
            LopHPs = new HashSet<LopHP>();
        }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTC { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<LopHP> LopHPs { get; set; }
    }
}
