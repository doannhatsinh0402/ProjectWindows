using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Model
{
    public  class KhoaHoc
    {
        public KhoaHoc()
        {
            SinhViens = new HashSet<SinhVien>(); 
        }
        public string MaKH { get; set; }
        public DateTime NamBatDau { get; set; }
        public DateTime NamKetThuc { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}