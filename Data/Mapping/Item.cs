using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TARSTestJosue.Models;

namespace TARSTestJosue.Data
{
	public class ItemMap : IEntityTypeConfiguration<Item>
	{
		public void Configure(EntityTypeBuilder<Item> builder)
		{
			builder.ToTable("tb_item");
			builder.Property(c => c.Id)
				.HasColumnName("Id").ValueGeneratedOnAdd();

			builder.Property(c => c.LastUpdated)
				.IsRequired();

			builder.Property(c => c.Store)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(c => c.URL)
				.HasColumnType("varchar(300)")
				.HasMaxLength(300);

			builder.OwnsOne(i => i.Price)
				.Property(p => p.Currency)
				.HasColumnType("varchar(5)")
				.HasMaxLength(5)
				.IsRequired();

			builder.OwnsOne(i => i.Price)
				.Property(p => p.Amount)
				.IsRequired();
		}
	}
}
