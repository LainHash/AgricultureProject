using Agriculture.Application.Features.Identity.Roles.Queries.GetAll;
using Agriculture.Application.Features.Identity.Roles.Queries.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Identity;
using Agriculture.Contract.DTOs.Identity.Roles;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Repositories.Identity;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Identity
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<RoleResponse>>> GetAllAsync(
            GetAllRolesSpecification specification,
            CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.ToListAsync(specification, cancellationToken);
            if (!roles.Any())
            {
                return Result<IEnumerable<RoleResponse>>
                    .Fail(Error<Role>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<RoleResponse>>(roles);
            return Result<IEnumerable<RoleResponse>>
                .Succeed(response, Success<Role>.Retrieved);
        }

        public async Task<Result<RoleResponse>> GetByIdAsync(
            GetRoleByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var role = await _roleRepository.FindAsync(specification, cancellationToken);
            if(role is null)
            {
                return Result<RoleResponse>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<RoleResponse>(role);
            return Result<RoleResponse>
                .Succeed(response, Success<Role>.Retrieved);
        }

        public async Task<Result<RoleResponse>> CreateAsync(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request);
            _roleRepository.Add(role);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<RoleResponse>(role);
            return Result<RoleResponse>
                .Succeed(response, Success<Role>.Created, HttpStatusCode.Created);
        }
    }
}
