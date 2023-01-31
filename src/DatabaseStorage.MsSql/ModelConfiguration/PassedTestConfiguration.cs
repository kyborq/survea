using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class PassedTestConfiguration : IEntityTypeConfiguration<PassedTest>
    {
        public void Configure( EntityTypeBuilder<PassedTest> builder )
        {
            builder.ToTable( "PassedTest" ).HasKey( t => t.TestPassingId );
            builder.Property( t => t.FinishedAt ).IsRequired();

            builder.HasOne( t => t.User ).WithMany( u => u.PassedTests );
            builder.HasOne( t => t.Test ).WithMany( t => t.Attempts );

            builder.HasIndex( t => t.UserId );
            builder.HasIndex( t => t.TestId );
        }
    }
}
