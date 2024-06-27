using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.AcademicYears.Entities;

public class AcademicYear : BaseEntity<AcademicYearId>
{
    public int Value { get; set; }

    private AcademicYear() : base(new AcademicYearId(Guid.NewGuid()))
    {
    }

    public AcademicYear(int value) : base(new AcademicYearId(Guid.NewGuid()))
    {
        Value = value;
    }
}