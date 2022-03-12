namespace ProgramSystem.Bll.Services.DTO;

public class UserDTO : IEntityDTO
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Password { get; set; } = null!;
}