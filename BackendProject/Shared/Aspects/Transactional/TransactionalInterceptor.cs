using System.Reflection;
using BackendProject.Shared.Abstractions;

namespace BackendProject.Shared.Aspects.Transactional;

public class TransactionalInterceptor
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionalInterceptor(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<T> InterceptAsync<T>(Func<Task<T>> action, MethodInfo methodInfo)
    {
        var result = await action();
        if (methodInfo.GetCustomAttribute<TransactionalAttribute>() != null)
        {
            await _unitOfWork.SaveAsync();
        }

        return result;
    }
}