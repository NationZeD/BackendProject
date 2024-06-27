using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Create;

public class BaseLanguagedCreateCommandHandler<TEntity, TEntityId, TForm, TDto, TRequest> : IRequestHandler<TRequest>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
    where TRequest : BaseLanguagedCreateCommand<TEntity, TEntityId, TForm, TDto>
{
    private readonly ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> _service;
    private readonly IUnitOfWork _unitOfWork;

    public BaseLanguagedCreateCommandHandler(ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> service,
        IUnitOfWork unitOfWork)
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