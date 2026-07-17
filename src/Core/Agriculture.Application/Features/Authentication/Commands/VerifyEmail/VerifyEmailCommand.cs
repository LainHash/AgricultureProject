using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.VerifyEmail
{
    public record VerifyEmailCommand(VerifyEmailRequest Body)
        : IRequest<Result<object>>
    {
    }
}
