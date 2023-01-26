using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class DetailedTestInfoConfiguration : IEntityTypeConfiguration<DetailedTestInfo>
    {
        public void Configure( EntityTypeBuilder<DetailedTestInfo> builder )
        {
            builder.ToTable( "DetailedTestInfo" ).HasKey( i => i.DetailedTestInfoId );
            builder.Property( i => i.AverageTestCompletionTime );
            builder.Property( i => i.AttemptCount ).IsRequired();

            builder.HasOne( i => i.Test ).WithOne( t => t.DetailedTestInfo ).HasForeignKey<Test>( t => t.DetailedTestInfoId );
        }
    }
}
