using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure( EntityTypeBuilder<Test> builder )
        {
            builder.ToTable( "Test" ).HasKey( t => t.TestId );
            builder.Property( t => t.Name ).IsRequired().HasMaxLength( 100 );
            builder.Property( t => t.AgeRestriction ).IsRequired();
            builder.Property( t => t.QuestionCount ).IsRequired();
            builder.Property( t => t.Description ).IsRequired().HasMaxLength( 250 );

            builder.HasOne( t => t.DetailedTestInfo ).WithOne( i => i.Test );
            builder.HasMany( t => t.Attempts ).WithOne( a => a.Test ).HasForeignKey( a => a.TestId );
            builder.HasMany( t => t.Tags ).WithMany( t => t.Tests ).UsingEntity( e => e.ToTable( "TestTag" ) );

            builder.Ignore( t => t.Questions );
        }
    }
}
