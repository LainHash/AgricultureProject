using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Identity.Roles.Queries.GetById
{
    public class GetRoleByIdSpecification
        : BaseSpecification<Role>
    {
        public GetRoleByIdSpecification(GetRoleByIdQuery query)
        {
            Criteria = r => r.PublicId == query.Id;
            EnableSoftDeleteFilter();
        }
    }
}
