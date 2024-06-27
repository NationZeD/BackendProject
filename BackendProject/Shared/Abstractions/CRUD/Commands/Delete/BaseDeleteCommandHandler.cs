using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Commands.Delete;

public class BaseDeleteCommandHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TDto : ICrudDTO<TEntity>
    where TRequest : BaseDeleteCommand<TEntity, TEntityId, TDto>
{
    private readonly ICrudService<TEntity, TEntityId, TDto> _service;
    private readonly IUnitOfWork _unitOfWork;

    public BaseDeleteCommandHandler(ICrudService<TEntity, TEntityId, TDto> service, IUnitOfWork unitOfWork)
    {
        _service = service;
        _unitOfWork = unitOfWork;
    }

    public virtual async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();
    }
}