using Agriculture.Application.Features.Catalog.Categories.Queries;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Categories;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using AutoMapper;

namespace Agriculture.Persistence.Services.Catalog
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync(GetAllCategoriesSpecification specification, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ToListAsync(specification, cancellationToken);
            if (!categories.Any())
            {
                return Result<IEnumerable<CategoryResponse>>
                    .Fail(Error<Category>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Result<IEnumerable<CategoryResponse>>
                .Succeed(response, Success<Category>.Retrieved);

        }
    }
}
