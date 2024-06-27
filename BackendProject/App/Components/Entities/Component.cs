using BackendProject.App.Components.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Components.Entities;

public class Component : BaseEntity<ComponentId>
{
    public Multilingual? Name { get; private set; }
    public string? Code { get; set; }

    private Component(ComponentId id, Multilingual name, string code) : base(id)
    {
        Name = name;
        Code = code;
    }

    private Component(ComponentId id) : base(id)
    {
    }

    public static Component Create(Multilingual name, string code)
    {
        return new Component(new ComponentId(Guid.NewGuid()), name, code);
    }
}