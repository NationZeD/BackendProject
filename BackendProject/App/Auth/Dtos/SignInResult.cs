namespace BackendProject.App.Auth.Dtos;

public class SignInResult
{
    public string Id { get; set; }
    public string AccessToken { get; set; }
    public int ExpiresAt { get; set; }
    public string Role { get; set; }
}