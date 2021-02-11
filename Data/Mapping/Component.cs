using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TARSTestJosue.Models;

namespace TARSTestJosue.Data
{
	public class ComponentMap : IEntityTypeConfiguration<Component>
	{
		public void Configure(EntityTypeBuilder<Component> builder)
		{
			builder.ToTable("tb_component");
			builder.Property(c => c.Id)
				.HasColumnName("Id").ValueGeneratedOnAdd();

			builder.Property(c => c.Name)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(c => c.Company)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100);

			builder.Property(c => c.LastUpdated)
				.IsRequired();

			builder.Property(c => c.Product)
				.HasColumnType<string>("varchar(100)")
				.HasMaxLength(100);

			builder.Property(c => c.URL)
				.HasColumnType<string>("varchar(100)")
				.HasMaxLength(100);

			builder.OwnsOne(c => c.Status)
				.Property(s => s.Description)
				.HasColumnName("Status")
				.HasColumnType("varchar(30)")
				.HasMaxLength(30)
				.IsRequired();

			builder.Property(c => c.Company)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100);

			builder.Property(c => c.Priority)
				.HasDefaultValue(0);

			builder.Property(c => c.Extra)
				.HasColumnType<string>("varchar(200)")
				.HasMaxLength(200);

			builder.Property(c => c.Version)
				.HasColumnType<string>("varchar(100)")
				.HasMaxLength(100);

			builder.HasMany(c => c.Prices)
				.WithOne(p => p.Component)
				.HasForeignKey(p => p.ComponentId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
