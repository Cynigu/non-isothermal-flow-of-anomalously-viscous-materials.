namespace ProgramSystem.Bll.Services.DTO;

public class UserDTO
{
    /// <summary>
    /// ID не обязательно при создании нового объекта
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;
    /// <summary>
    /// Роль
    /// </summary>
    public string Role { get; set; } = null!;
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;
}