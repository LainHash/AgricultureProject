using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Guest;

namespace Agriculture.Domain.Entites.Identity
{
    public partial class User : SoftDeletableEntity
    {
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public decimal Balance { get; private set; }
        public bool IsActive { get; private set; }

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationCodeExpiresAt { get; private set; }

        public int RoleId { get; private set; }

        public Role Role { get; private set; } = null!;
        public Player Player { get; private set; } = null!;
    }

    public partial class User
    {
        public void SetRole(int roleId)
        {
            RoleId = roleId;
        }

        public void SetPassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void SetVerificationCode(string verificationCode)
        {
            VerificationCode = verificationCode;
            VerificationCodeExpiresAt = DateTime.UtcNow.AddMinutes(15);
        }

        public void CompleteVerification()
        {
            IsActive = true;
            VerificationCode = null;
            VerificationCodeExpiresAt = null;
        }
    }
}
