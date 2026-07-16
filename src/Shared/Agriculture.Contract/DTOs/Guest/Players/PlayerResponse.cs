using Agriculture.Domain.Entites.Guest;

namespace Agriculture.Contract.DTOs.Guest.Players
{
    public class PlayerResponse
    {
        public Guid PublicId { get; set; }
        public string Username { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public PlayerResponse(Player player)
        {
            PublicId = player.PublicId;
            Username = player.User.Username;
            Balance = player.User.Balance;
            RoleName = player.User.Role.Name;
        }
    }
}
