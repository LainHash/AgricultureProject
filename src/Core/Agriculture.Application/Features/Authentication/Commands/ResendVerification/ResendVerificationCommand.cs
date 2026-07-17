using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.ResendVerification
{
    public record ResendVerificationCommand(ResendVerificationRequest Body)
        : IRequest<Result<object>>;
}
