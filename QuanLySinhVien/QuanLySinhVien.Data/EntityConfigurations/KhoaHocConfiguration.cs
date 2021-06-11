using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class KhoaHocConfiguration : EntityTypeConfiguration<KhoaHoc>
    {
        public KhoaHocConfiguration()
        {
            HasKey(k => k.MaKH)
                .Property(e => e.MaKH)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.NamBatDau)
                .IsRequired();
            Property(e => e.NamKetThuc)
                .IsRequired();
            HasMany(e => e.SinhViens)
                .WithRequired(e => e.KhoaHoc)
                .HasForeignKey(e => e.MaKH)
                .WillCascadeOnDelete(false);
        }
    }
}
