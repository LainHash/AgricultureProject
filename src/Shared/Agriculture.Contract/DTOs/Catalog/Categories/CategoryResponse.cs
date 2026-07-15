namespace Agriculture.Contract.DTOs.Catalog.Categories
{
    public class CategoryResponse
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
