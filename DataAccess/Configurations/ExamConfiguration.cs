using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Exams).HasForeignKey(x => x.UserId);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.ToTable("Exams");
        }
    }
}
