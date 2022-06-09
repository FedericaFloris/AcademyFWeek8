using AcademyFWeek8.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyFWeek8.RepositoryEF
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            builder.ToTable("Lezione");
            builder.HasKey(l => l.LezioneId);

            //relazione con docente
            builder.HasOne(l => l.Docente).WithMany(d => d.Lezioni).HasForeignKey(l => l.DocenteID);
            
            //relazione con corso
            builder.HasOne(l => l.Corso).WithMany(d => d.Lezioni).HasForeignKey(l => l.CorsoCodice );

        }
    }
}