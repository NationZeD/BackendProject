using BackendProject.App.Categories.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Categories.Entities;

public class Category : BaseEntity<CategoryId>
{
    public Multilingual Name { get; private set; }

    private Category() : base(new CategoryId(Guid.NewGuid()))
    {
    }

    private Category(Multilingual name) : base(new CategoryId(Guid.NewGuid()))
    {
        Name = name;
    }

    public static Category Create(Multilingual name)
    {
        return new Category(name);
    }
}