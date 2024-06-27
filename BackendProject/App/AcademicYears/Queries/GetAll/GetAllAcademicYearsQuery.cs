using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.Shared.Abstractions.CRUD.Queries.GetAll;

namespace BackendProject.App.AcademicYears.Queries.GetAll;

public class GetAllAcademicYearsQuery : BaseGetAllQuery<AcademicYear, AcademicYearDto>;