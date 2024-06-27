using MediatR;

namespace BackendProject.Shared.Abstractions.CRUD.Commands.Create;

public abstract class BaseCreateCommandHandler<TEntity, TEntityId, TDto, TRequest> : IRequestHandler<TRequest>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TDto : ICrudDTO<TEntity>
    where TRequest : BaseCreateCommand<TEntity, TDto>
{
    private readonly ICrudService<TEntity, TEntityId, TDto> _service;
    private readonly IUnitOfWork _unitOfWork;

    public BaseCreateCommandHandler(ICrudService<TEntity, TEntityId, TDto> service, IUnitOfWork unitOfWork)
    {
        _service = service;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(request.Request);
        await _unitOfWork.SaveAsync();
    }
}