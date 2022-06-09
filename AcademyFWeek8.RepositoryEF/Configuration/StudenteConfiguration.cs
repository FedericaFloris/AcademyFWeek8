using AcademyFWeek8.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyFWeek8.RepositoryEF
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {
            builder.ToTable("Studente");
            builder.HasKey(s => s.ID);


            //relazione con corso 1:m
            builder.HasOne(s=>s.Corso).WithMany(c=>c.Studenti).HasForeignKey(s=>s.CorsoCodice);
        }
    }
}