using BackendProject.App.Components.Entities;
using BackendProject.App.Multilinguals.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.Components.Dtos;

public class ComponentForm : IForm<Component>
{
    public Guid? Id { get; set; }
    public MultiLingualInput Name { get; set; }
    public string Code { get; set; }

    public ComponentForm()
    {
    }

    public void Write(Component entity)
    {
        Name.Write(entity.Name);
        entity.Code = Code;
    }

    public void Read(Component entity)
    {
        Id = entity.Id.Value;
        Name.Read(entity.Name);
        Code = entity.Code;
    }

    public static ComponentForm GetNewInstance()
    {
        return new ComponentForm
        {
            Id = null,
            Name = MultiLingualInput.GetNewInstance(),
            Code = null
        };
    }
}