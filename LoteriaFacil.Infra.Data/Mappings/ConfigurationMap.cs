using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Infra.Data.Mappings
{
    public class ConfigurationMap : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Calcular_Dezenas_Sem_Pontuacao)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.Enviar_Email_Manualmente)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.Enviar_Email_Automaticamente)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.Checar_Jogo_Online)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();


            builder.Property(c => c.Valor_Minimo_Para_Envio_Email)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            //builder.Property(c => c.PesId)
            //    .HasColumnType("PesId")
            //    .HasDefaultValue(0)
            //    .IsRequired();
        }
    }
}
