using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.ToTable( "Tag" ).HasKey( t => t.TagId );
            builder.Property( t => t.TagValue ).IsRequired().HasMaxLength( 50 );

            builder.HasMany( t => t.Users ).WithMany( u => u.Tags ).UsingEntity( e => e.ToTable( "UserTag" ) );
            builder.HasMany( t => t.Tests ).WithMany( t => t.Tags ).UsingEntity( e => e.ToTable( "TestTag" ) );
        }
    }
}
