using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Commands.Edit;

public class BaseEditCommandHandler<TEntity, TEntityId, TDto, TRequest> :
    IRequestHandler<TRequest> where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TDto : ICrudDTO<TEntity>
    where TRequest : BaseEditCommand<TEntity, TDto>
{
    private readonly ICrudService<TEntity, TEntityId, TDto> _service;
    private readonly IUnitOfWork _unitOfWork;

    public BaseEditCommandHandler(ICrudService<TEntity, TEntityId, TDto> service, IUnitOfWork unitOfWork)
    {
        _service = service;
        _unitOfWork = unitOfWork;
    }


    public virtual async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _service.UpdateAsync(request.Request);
        await _unitOfWork.SaveAsync();
    }
}