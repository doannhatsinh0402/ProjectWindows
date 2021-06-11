using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class GiangVienConfiguration : EntityTypeConfiguration<GiangVien>
    {
        public GiangVienConfiguration()
        {
            HasKey(k => k.MaGV);

            Property(e => e.MaGV)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.TenGV)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);
            Property(e => e.DiaChi)
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
            Property(e => e.MaKhoa)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.LopHPs)
                .WithRequired(e => e.GiangVien)
                .HasForeignKey(e => e.MaGV)
                .WillCascadeOnDelete(false);
            HasOptional(e => e.KhoaChuNhiem)
                .WithRequired(e => e.TruongKhoa);
        }
    }
}
