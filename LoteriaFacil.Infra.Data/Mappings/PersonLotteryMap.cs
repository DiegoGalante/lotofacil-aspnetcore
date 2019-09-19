using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Infra.Data.Mappings
{
    public class PersonLotteryMap : IEntityTypeConfiguration<PersonLottery>
    {
        public void Configure(EntityTypeBuilder<PersonLottery> builder)
        {
            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Concurse)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Game)
               .HasColumnType("varchar(200)")
               .HasMaxLength(200)
               .IsRequired();


            builder.Property(c => c.Hits)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(c => c.Ticket_Amount)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.Game_Checked)
               .HasColumnType("datetime");

            builder.Property(c => c.Game_Register)
               .HasColumnType("datetime")
               .HasDefaultValueSql("GETDATE()")
               .IsRequired();

            builder.HasOne(c => c.Person);
            builder.HasOne(c => c.Lottery);

        }
    }
}
