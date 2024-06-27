namespace BackendProject.Shared.Abstractions.CRUD;

public interface ICrudDTO<TEntity>
{
    Guid? Id { get; set; }
    void Read(TEntity entity);
    void Write(TEntity entity);
}