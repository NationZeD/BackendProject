namespace BackendProject.Shared.Exceptions;

public class BaseException : Exception
{
    public BaseException(string error) : base(error)
    {
    }
}