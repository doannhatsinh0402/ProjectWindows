namespace QuanLySinhVien.Model
{
    public class LopHP
    {
        public string MaLHP { get; set; }
        public string MaMH { get; set; }
        public string MaGV { get; set; }
        public int NamHoc { get; set; }
        public int HocKy { get; set; }

        public virtual MonHoc MonHoc { get; set; }     
        public virtual GiangVien GiangVien { get; set; }
    }
}