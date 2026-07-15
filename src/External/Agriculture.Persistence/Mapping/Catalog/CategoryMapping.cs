using Agriculture.Contract.DTOs.Catalog.Categories;
using Agriculture.Domain.Entites.Catalog;
using AutoMapper;
using static Agriculture.Persistence.Seeders.Catalog.CategorySeeder;

namespace Agriculture.Persistence.Mapping.Catalog
{
    internal class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryRecord, Category>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
