
namespace QuanLySinhVien.Model
{
    public class Diem
    {
        public string MaSV { get; set; }
        public string MaMH { get; set; }
        public int DiemQT { get; set; }
        public int DiemThi { get; set; }
        public int DiemTB { get; set; }

        public virtual SinhVien SinhVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}