using BackendProject.Shared.Annotations;

namespace BackendProject.App.Accounts.Customers.Commands.SignUp;

public class SignUpCustomerRequest
{
    [CustomPhoneNumber]
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int VerificationCode { get; set; }
}