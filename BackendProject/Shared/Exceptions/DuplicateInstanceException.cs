namespace BackendProject.Shared.Exceptions;

public class DuplicateInstanceException : BaseException
{
    public DuplicateInstanceException(string entityName= "Entity") : base($"{entityName} with given parameters already exists")
    {
    }
}