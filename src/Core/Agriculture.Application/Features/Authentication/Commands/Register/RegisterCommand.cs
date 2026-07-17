using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.Register
{
    public record RegisterCommand(RegisterRequest Body)
        : IRequest<Result<object>>
    {
    }
}
