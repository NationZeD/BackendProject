using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Delete;

public class BaseLanguagedDeleteCommandHandler<TEntity, TEntityId, TForm, TDto, TRequest> : IRequestHandler<TRequest>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : BaseEntityId
    where TForm : IForm<TEntity>
    where TRequest : BaseLanguagedDeleteCommand<TEntity, TEntityId, TForm, TDto>
{
    private readonly ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> _service;
    private readonly IUnitOfWork _unitOfWork;

    public BaseLanguagedDeleteCommandHandler(ILanguagedCrudService<TEntity, TEntityId, TForm, TDto> service,
        IUnitOfWork unitOfWork)
    {
        _service = service;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();
    }
}