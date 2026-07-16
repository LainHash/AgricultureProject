namespace Agriculture.Contract.DTOs.Identity.Roles
{
    public class RoleResponse
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
