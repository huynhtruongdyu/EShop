namespace EShop.Data.Domain
{
    public class Category
    {
        public Guid Id { get; set; }

        public virtual ICollection<CategoryTranslation> Translations { get; set; } = [];
    }
}