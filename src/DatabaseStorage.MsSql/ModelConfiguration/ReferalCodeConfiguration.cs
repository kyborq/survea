using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class ReferalCodeConfiguration : IEntityTypeConfiguration<ReferalCode>
    {
        public void Configure( EntityTypeBuilder<ReferalCode> builder )
        {
            builder.ToTable( "ReferalCode" ).HasKey( r => r.ReferalCodeId );
            builder.Property( r => r.Code ).IsRequired().HasMaxLength( 30 );

            builder.HasOne( r => r.Owner ).WithOne( u => u.ReferalCode ).HasForeignKey<User>( u => u.ReferalCodeId );
        }
    }
}
