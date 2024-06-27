namespace BackendProject.Shared;

public static class NormalizedTime
{
    public static DateTimeOffset Now
    {
        get
        {
            var sourceDate = DateTime.Now;
            sourceDate = DateTime.SpecifyKind(sourceDate, DateTimeKind.Unspecified);
            const string timeZoneName = "Georgian Standard Time";
            var offset = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetUtcOffset(sourceDate);
            return DateTimeOffset.UtcNow.ToOffset(offset);
        }
    }
}