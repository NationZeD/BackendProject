namespace BackendProject.App.Auth.Constants;

public static class Roles
{
    public const string Admin = "Admin";
    public const string Customer = "Customer";
    public const string Lecturer = "Lecturer";

    public static IEnumerable<string> GetRoles()
    {
        yield return Admin;
        yield return Customer;
        yield return Lecturer;
    }
}