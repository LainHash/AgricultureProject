using Agriculture.Application.Features.Catalog.Categories.Commands.Update;
using Agriculture.Application.Features.Catalog.Categories.Queries.GetAll;
using Agriculture.Application.Features.Catalog.Categories.Queries.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Categories;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Catalog
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        public async Task<Result<CategoryResponse>> GetByIdAsync(GetCategoryByIdSpecification specification, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(specification, cancellationToken);
            if (category is null)
            {
                return Result<CategoryResponse>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Retrieved);
        }

        public async Task<Result<CategoryResponse>> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            _categoryRepository.Add(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<CategoryResponse>> UpdateAsync(UpdateCategorySpecification specification, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(specification, cancellationToken);
            if (category is null)
            {
                return Result<CategoryResponse>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.NotFound);
            }

            _mapper.Map(specification.Body, category);
            _categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Updated, HttpStatusCode.Accepted);
        }
    }
}
