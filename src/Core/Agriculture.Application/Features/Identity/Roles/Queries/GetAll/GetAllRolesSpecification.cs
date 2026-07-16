using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Identity.Roles.Queries.GetAll
{
    public class GetAllRolesSpecification
        : BaseSpecification<Role>
    {
        public GetAllRolesSpecification(GetAllRolesQuery query)
        {
            EnableSoftDeleteFilter();
        }
    }
}
