using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable( "User" ).HasKey( u => u.UserId );
            builder.Property( u => u.Name ).IsRequired().HasMaxLength( 50 );
            builder.Property( u => u.DateOfBirth );
            builder.Property( u => u.Email ).IsRequired().HasMaxLength( 50 );
            builder.Property( u => u.AccountMode ).HasColumnType( "tinyint" ).IsRequired();

            builder.HasOne( u => u.DetailedUserInfo ).WithOne( i => i.User );
            builder.HasMany( u => u.Tests ).WithOne( t => t.Owner ).HasForeignKey( t => t.OwnerId );
            builder.HasMany( u => u.Tags ).WithMany( u => u.Users ).UsingEntity( e => e.ToTable( "UserTag" ) );
            builder.HasMany( u => u.PassedTests ).WithOne( p => p.User ).HasForeignKey( p => p.UserId ).OnDelete( DeleteBehavior.NoAction );
            builder.HasOne( u => u.ReferalCode ).WithOne( r => r.Owner ).HasForeignKey<ReferalCode>( r => r.OwnerId );
        }
    }
}
