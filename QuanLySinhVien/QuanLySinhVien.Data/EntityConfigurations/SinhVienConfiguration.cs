using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class SinhVienConfiguration : EntityTypeConfiguration<SinhVien>
    {
        public SinhVienConfiguration()
        {
            HasKey(k => k.MaSV);

            Property(e => e.MaSV)
                .HasMaxLength(9)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.TenSV)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);
            Property(e => e.Lop)
                .HasMaxLength(10)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.DiaChi)
                .HasMaxLength(150)
                .IsUnicode(true);
            Property(e => e.QueQuan)
                .HasMaxLength(150)
                .IsUnicode(true);
            Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.Email)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.MaKH)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.MaKhoa)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.Diems)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);
        }
    }
}
