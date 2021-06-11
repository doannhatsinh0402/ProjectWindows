using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;
using System.Data.Entity.ModelConfiguration;

namespace QuanLySinhVien.Data.EntityConfigurations
{
    public class LopHPConfiguration : EntityTypeConfiguration<LopHP>
    {
        public LopHPConfiguration()
        {
            HasKey(k => k.MaLHP);

            Property(e => e.MaLHP)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.MaGV)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);
            Property(e => e.MaMH)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
