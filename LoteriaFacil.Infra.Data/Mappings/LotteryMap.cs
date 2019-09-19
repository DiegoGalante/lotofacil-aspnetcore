using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Infra.Data.Mappings
{
    public class LotteryMap : IEntityTypeConfiguration<Lottery>
    {
        public void Configure(EntityTypeBuilder<Lottery> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Concurse)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.DtConcurse)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Game)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(c => c.Hit15)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Hit14)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Hit13)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Hit12)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Hit11)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Shared15)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.Shared14)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.Shared13)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();


            builder.Property(c => c.Shared12)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.Shared11)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.DtNextConcurse)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(c => c.TypeLottery);

        }
    }
}
