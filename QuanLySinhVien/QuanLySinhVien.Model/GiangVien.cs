using System.Collections.Generic;

namespace QuanLySinhVien.Model
{
    public class GiangVien
    {
        public GiangVien()
        {
            LopHPs = new HashSet<LopHP>();
        }
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public Common.GioiTinh GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public string Sdt { get; set; }
        public string Email { get; set; }
        public string MaKhoa { get; set; }

        public virtual ICollection<LopHP> LopHPs { get; set; }

        public virtual Khoa KhoaChuNhiem { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}