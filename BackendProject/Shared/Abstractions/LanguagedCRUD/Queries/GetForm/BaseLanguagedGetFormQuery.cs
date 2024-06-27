using MediatR;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD.Queries.GetForm;

public class BaseLanguagedGetFormQuery<TEntity, TForm> : IRequest<TForm> where TForm : IForm<TEntity>;