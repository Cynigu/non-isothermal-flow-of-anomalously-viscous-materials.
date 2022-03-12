namespace ProgramSystem.Bll.Services.DTO;

public class UserDTO : IEntityDTO
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
}