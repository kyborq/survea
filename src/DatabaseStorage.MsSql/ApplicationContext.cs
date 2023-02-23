using DatabaseStorage.MsSql.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.MsSql
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions<ApplicationContext> options )
            : base( options )
        {
            Database.SetCommandTimeout( 9000 );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new AnswerConfiguration() );
            modelBuilder.ApplyConfiguration( new DetailedTestInfoConfiguration() );
            modelBuilder.ApplyConfiguration( new DetailedUserInfoConfiguration() );
            modelBuilder.ApplyConfiguration( new PassedTestConfiguration() );
            modelBuilder.ApplyConfiguration( new ReferalCodeConfiguration() );
            modelBuilder.ApplyConfiguration( new TagConfiguration() );
            modelBuilder.ApplyConfiguration( new TestConfiguration() );
            modelBuilder.ApplyConfiguration( new UserConfiguration() );
        }
    }
}
