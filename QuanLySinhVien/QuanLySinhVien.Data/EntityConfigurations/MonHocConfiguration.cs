using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class MonHocConfiguration : EntityTypeConfiguration<MonHoc>
    {
        public MonHocConfiguration()
        {
            HasKey(e => e.MaMH);

            Property(e => e.MaMH)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.TenMH)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);
            Property(e => e.SoTC)
                .IsRequired();


            HasMany(e => e.Diems)
                         .WithRequired(e => e.MonHoc)
                         .WillCascadeOnDelete(false);
            HasMany(e => e.LopHPs)
                .WithRequired(e => e.MonHoc)
                .HasForeignKey(e => e.MaMH)
                .WillCascadeOnDelete(false);

        }
    }
}
