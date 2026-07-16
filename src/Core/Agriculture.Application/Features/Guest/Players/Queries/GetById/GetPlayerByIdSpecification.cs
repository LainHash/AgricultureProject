using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Application.Features.Guest.Players.Queries.GetById
{
    public class GetPlayerByIdSpecification
        : BaseSpecification<Player>
    {
        public GetPlayerByIdSpecification(GetPlayerByIdQuery query)
        {
            Criteria = p => p.PublicId == query.Id;

            AddIncludeAggregator(x => x.Include(p => p.User)
                                        .ThenInclude((User u) => u.Role));
            EnableSoftDeleteFilter();
        }
    }
}
