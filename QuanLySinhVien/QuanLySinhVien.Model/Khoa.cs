using System.Collections.Generic;
namespace QuanLySinhVien.Model
{
    public class Khoa
    {
        public Khoa()
        {
            GiangViens = new HashSet<GiangVien>();
            SinhViens = new HashSet<SinhVien>();
        }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string MaTruongKhoa { get; set; }
        public virtual ICollection<GiangVien> GiangViens { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}