using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions.CRUD;

namespace BackendProject.App.AcademicYears.Services.IServices;

public interface IAcademicYearService : ICrudService<AcademicYear, AcademicYearId, AcademicYearDto>;