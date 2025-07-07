using EShop.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Configurations
{
    public class CategoryTranslationConfig : IEntityTypeConfiguration<CategoryTranslation>
    {
        private const string TableName = "CategoryTranslations";

        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Slug)
                .HasMaxLength(100);
            builder.Property(c => c.Description)
                .HasMaxLength(500);
        }
    }
}