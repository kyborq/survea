using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseStorage.MsSql.ModelConfiguration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure( EntityTypeBuilder<Answer> builder )
        {
            builder.ToTable( "Answer" ).HasKey( a => a.AnswerId );
            builder.Property( a => a.QuestionNumber ).IsRequired();
            builder.Property( a => a.QuestionType ).HasColumnType( "tinyint" ).IsRequired();
            builder.Property( a => a.AnswerText ).IsRequired().HasMaxLength( 250 );

            builder.HasOne( a => a.TestPassing ).WithMany( t => t.Answers );
        }
    }
}
