using BackendProject.App.AcademicYears.Entities;
using BackendProject.Shared.Abstractions.CRUD;

namespace BackendProject.App.AcademicYears.Dtos;

public class AcademicYearDto: ICrudDTO<AcademicYear>
{
    public Guid? Id { get; set; }
    public int Value { get; set; }
    
    public void Read(AcademicYear entity)
    {
        Id = entity.Id.Value;
        Value = entity.Value;
    }

    public void Write(AcademicYear entity)
    {
        entity.Value = Value;
    }
}