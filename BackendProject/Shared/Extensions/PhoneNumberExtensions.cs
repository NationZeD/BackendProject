namespace BackendProject.Shared.Extensions;

public static class PhoneNumberExtensions
{
    public static string ToNormalizedPhoneNumber(this string phoneNumber)
    {
        phoneNumber = phoneNumber.Replace(" ", "");
        phoneNumber = phoneNumber.Replace("+995", "");
        phoneNumber = phoneNumber.Replace("-", "");
        phoneNumber = phoneNumber.Replace("_", "");
        phoneNumber = phoneNumber.Replace("/", "");

        if (phoneNumber.StartsWith("995"))
        {
            phoneNumber = new string(phoneNumber.Skip(3).ToArray());
        }

        return phoneNumber;
    }
}