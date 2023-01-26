using Core.Entities;
using DatabaseStorage.MsSql.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.MsSql
{
    public class ApplicationContext : DbContext, IDbContext
    {
        // DbSet не обязателен
        /*public DbSet<Answer> Answer { get; set; }
        public DbSet<DetailedTestInfo> DetailedTestInfo { get; set; }
        public DbSet<DetailedUserInfo> DetailedUserInfo { get; set; }
        public DbSet<PassedTest> PassedTest { get; set; }
        public DbSet<ReferalCode> ReferalCode { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<User> User { get; set; }*/

        public ApplicationContext( DbContextOptions<ApplicationContext> options )
            : base( options )
        {
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
