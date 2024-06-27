using BackendProject.Shared.Annotations;

namespace BackendProject.App.Verifications.Commands.SendVerificationCode;

public class SendVerificationCodeRequest
{ 
    [CustomPhoneNumber]
    public string PhoneNumber { get; set; }
}