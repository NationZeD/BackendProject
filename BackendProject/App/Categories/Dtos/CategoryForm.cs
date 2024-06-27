using BackendProject.App.Categories.Entities;
using BackendProject.App.Multilinguals.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Categories.Dtos;

public class CategoryForm : IForm<Category>
{
    public Guid? Id { get; set; }
    public MultiLingualInput Name { get; set; }

    public void Write(Category entity)
    {
        Name.Write(entity.Name);
    }

    public void Read(Category entity)
    {
        Id = entity.Id.Value;
        Name.Read(entity.Name);
    }

    public static CategoryForm GetNewInstance()
    {
        return new CategoryForm
        {
            Id = null,
            Name = MultiLingualInput.GetNewInstance()
        };
    }
}