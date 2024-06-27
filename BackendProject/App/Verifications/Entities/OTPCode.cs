using BackendProject.App.Verifications.ValueObjects;
using BackendProject.Shared;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Extensions;

namespace BackendProject.App.Verifications.Entities;

public class OTPCode : BaseEntity<OTPCodeId>
{
    public string Source { get; private set; }
    public int Code { get; private set; }
    public DateTimeOffset ExpiresAt { get; private set; }

    protected OTPCode()
    {
        
    }

    public OTPCode(string source, int code): base(new OTPCodeId(Guid.NewGuid()))
    {
        Source = source.ToNormalizedPhoneNumber();
        Code = code;
        ExpiresAt = NormalizedTime.Now.AddMinutes(3);
    }

    public OTPCode(string source): this(source, new Random().Next(1111,9999))
    {
        
    }

    public bool Suit(int code)
    {
        return Code == code && NormalizedTime.Now <= ExpiresAt;
    }
}