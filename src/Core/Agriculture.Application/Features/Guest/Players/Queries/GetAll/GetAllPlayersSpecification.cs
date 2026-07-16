using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Application.Features.Guest.Players.Queries.GetAll
{
    public class GetAllPlayersSpecification
        : BaseSpecification<Player>
    {
        public GetAllPlayersSpecification(GetAllPlayersQuery query)
        {
            AddIncludeAggregator(x => x.Include(p => p.User)
                                        .ThenInclude((User u) => u.Role));
            EnableSoftDeleteFilter();
        }
    }
}
