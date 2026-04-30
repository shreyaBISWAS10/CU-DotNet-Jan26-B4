
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Loans.Models;
namespace Loans.Data.Configurations
{
    public class LoanConfig : IEntityTypeConfiguration<LoanApplication>
    {
        public void Configure(EntityTypeBuilder<LoanApplication> builder)
        {
            builder.ToTable("LoanApplications");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LoanAmount)
                   .HasPrecision(18, 2);

            builder.Property(x => x.InterestRate)
                   .HasPrecision(5, 2);

            builder.Property(x => x.Status)
                   .HasMaxLength(20);
        }
    }

}
