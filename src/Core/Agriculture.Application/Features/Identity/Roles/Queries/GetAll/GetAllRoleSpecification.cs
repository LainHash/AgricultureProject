using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Identity.Roles.Queries.GetAll
{
    public class GetAllRoleSpecification
        : BaseSpecification<Role>
    {
        public GetAllRoleSpecification(GetAllRoleQuery query)
        {
            EnableSoftDeleteFilter();
        }
    }
}
