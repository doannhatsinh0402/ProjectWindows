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
            MonHocSaus = new HashSet<MonHoc>();
            Diems = new HashSet<Diem>();
            LopHPs = new HashSet<LopHP>();
        }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTC { get; set; }

        public string MaMHTQ { get; set; }

        public virtual MonHoc MonHocTQ { get; set; }
        public virtual ICollection<MonHoc> MonHocSaus { get; set; } // DS môn học cần học mô học tiên quyết
        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<LopHP> LopHPs { get; set; }
    }
}
