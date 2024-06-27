namespace BackendProject.Shared.Abstractions.LanguagedCRUD;

public interface IForm<TEntity>
{
    Guid? Id { get; set; }
    void Write(TEntity entity);
    void Read(TEntity entity);
}