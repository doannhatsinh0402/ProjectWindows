
namespace QuanLySinhVien.Model
{
    public class Diem
    {
        public string MaSV { get; set; }
        public string MaMH { get; set; }
        public float DiemQT { get; set; }
        public float DiemThi { get; set; }
        public float DiemTB { get; set; }

        public virtual SinhVien SinhVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}