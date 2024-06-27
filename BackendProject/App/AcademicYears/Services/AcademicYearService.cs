using BackendProject.App.AcademicYears.Dtos;
using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.AcademicYears.Repositories.IRepositories;
using BackendProject.App.AcademicYears.Services.IServices;
using BackendProject.App.AcademicYears.ValueObjects;
using BackendProject.Shared.Abstractions.CRUD;

namespace BackendProject.App.AcademicYears.Services;

public class AcademicYearService : BaseCrudService<AcademicYear, AcademicYearId, AcademicYearDto>, IAcademicYearService
{
    private readonly IAcademicYearRepository _repository;

    public AcademicYearService(IAcademicYearRepository repository, IReadRepository<AcademicYearDto> readRepository)
        : base(repository, readRepository)
    {
        _repository = repository;
    }

    protected override async Task<AcademicYear> GenerateEntityAsync(AcademicYearDto dto)
    {
        if (dto.Id != null)
            return await _repository.GetAsync(new AcademicYearId(dto.Id.Value));


        var entity = new AcademicYear(dto.Value);

        return entity;
    }
}