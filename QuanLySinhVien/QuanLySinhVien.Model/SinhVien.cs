using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Model
{
    public class SinhVien
    {
        public SinhVien()
        {
            Diems = new HashSet<Diem>();            
        }
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string Lop { get; set; }
        public DateTime NgaySinh { get; set; }
        public Common.GioiTinh GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public string QueQuan { get; set; }

        public string Sdt { get; set; }
        public string Email { get; set; }
        public string MaKhoa { get; set; }
        public string MaKH { get; set; }

        public virtual Khoa Khoa { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
        public virtual ICollection<Diem> Diems { get; set; } 
    }
}