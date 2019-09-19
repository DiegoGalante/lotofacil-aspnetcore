using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Infra.Data.Mappings
{
    public class TypeLotteryMap : IEntityTypeConfiguration<TypeLottery>
    {
        public void Configure(EntityTypeBuilder<TypeLottery> builder)
        {
            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(120)")
                .IsRequired();

            builder.Property(c => c.Tens_Min)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Bet_Min)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.Hit_Min)
                .HasColumnType("int")
                .IsRequired();


            builder.Property(c => c.Hit_Max)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
