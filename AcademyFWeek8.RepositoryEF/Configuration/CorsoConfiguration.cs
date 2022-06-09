using AcademyFWeek8.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyFWeek8.RepositoryEF
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {
            builder.ToTable("Corso");
            builder.HasKey(c => c.CorsoCodice);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Descrizione).IsRequired();

            //relazione corso studente 1: molti
            builder.HasMany(c => c.Studenti).WithOne(s => s.Corso).HasForeignKey(s => s.CorsoCodice);

            //relazione con lezione 1:m
            builder.HasMany(c => c.Lezioni).WithOne(l => l.Corso).HasForeignKey(l => l.CorsoCodice);
        }
    }
}