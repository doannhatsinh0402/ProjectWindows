
namespace QuanLySinhVien.Model
{
    public class Diem
    {
        public string MaSV { get; set; }
        public string MaMH { get; set; }
        public string DiemQT { get; set; }
        public string DiemThi { get; set; }
        public string DiemTB { get; set; }

        public virtual SinhVien SinhVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}