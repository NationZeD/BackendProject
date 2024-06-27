namespace BackendProject.Shared.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string entityName) : base($"{entityName} with given parameters does not exist")
    {
    }
}