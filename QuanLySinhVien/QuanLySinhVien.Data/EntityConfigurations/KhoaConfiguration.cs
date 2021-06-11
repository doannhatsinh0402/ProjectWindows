using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class KhoaConfiguration : EntityTypeConfiguration<Khoa>
    {
        public KhoaConfiguration()
        {
            HasKey(k => k.MaKhoa);

            Property(e => e.MaKhoa)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
            Property(e => e.TenKhoa)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);
            Property(e => e.MaTruongKhoa)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.GiangViens)
                .WithRequired(e => e.Khoa)
                .HasForeignKey(e => e.MaKhoa)
                .WillCascadeOnDelete(false);
            HasMany(e => e.SinhViens)
                .WithRequired(e => e.Khoa)
                .HasForeignKey(e => e.MaKhoa)
                .WillCascadeOnDelete(false);
        }

    }
}
