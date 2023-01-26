using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class DetailedUserInfoConfiguration : IEntityTypeConfiguration<DetailedUserInfo>
    {
        public void Configure( EntityTypeBuilder<DetailedUserInfo> builder )
        {
            builder.ToTable( "DetailedUserInfo" ).HasKey( i => i.DetailedUserInfoId );
            builder.Property( i => i.PassedTestCount ).IsRequired();
            builder.Property( i => i.CreatedTestCount ).IsRequired();
            builder.Property( i => i.Gender ).HasColumnType( "tinyint" ).IsRequired();
            builder.Property( i => i.RegistrationDate ).IsRequired();

            builder.HasOne( i => i.User ).WithOne( u => u.DetailedUserInfo ).HasForeignKey<User>( u => u.DetailedUserInfoId );
        }
    }
}
