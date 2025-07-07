namespace EShop.Data.Domain
{
    public class CategoryTranslation
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        // Navigation properties
        public virtual Category Category { get; set; } = null!;
    }
}