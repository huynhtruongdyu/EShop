using EShop.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Configurations
{
    public class CategoyConfig : IEntityTypeConfiguration<Category>
    {
        private const string TableName = "Categories";

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}