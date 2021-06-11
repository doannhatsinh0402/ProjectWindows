using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class DiemConfiguration : EntityTypeConfiguration<Diem>
    {
        public DiemConfiguration()
        {
            HasKey(e => new { e.MaSV, e.MaMH });

            Property(e => e.MaSV)
                .HasMaxLength(9)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.MaMH)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
