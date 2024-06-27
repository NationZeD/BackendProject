using BackendProject.App.Components.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.App.Subjects.Dtos;
using BackendProject.App.Subjects.Entities;
using BackendProject.App.Subjects.Repositories.IRepositories;
using BackendProject.App.Subjects.Services.IServices;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.App.SystemFiles.Dtos;
using BackendProject.App.SystemFiles.Repositories.IRepositories;
using BackendProject.App.SystemFiles.ValueObjects;

namespace BackendProject.App.Subjects.Services;

public class SubjectService(
    ISubjectRepository repository,
    ISystemFileRepository fileRepository)
    : ISubjectService
{
    public async Task CreateAsync(SubjectForm form)
    {
        var subjectId = new SubjectId(Guid.NewGuid());
        var subjectName = Multilingual.GetNewInstance();
        form.Name.Write(subjectName);

        var subjectComponents = new List<SubjectComponent>();

        foreach (var component in form.SubjectComponents)
        {
            var componentEntity = SubjectComponent.Create(subjectId, new ComponentId(component.ComponentId.Value));
            subjectComponents.Add(componentEntity);
        }

        var subject = Subject.Create(subjectId, new SystemFileId(form.Image.Id),
            subjectName, form.Code, subjectComponents.Select(x => new ComponentId(x.ComponentId.Value)).ToList());

        await repository.CreateAsync(subject);
    }

    public async Task<SubjectForm> GetForm()
    {
        var result = SubjectForm.GetNewInstance();
        result.SubjectComponents.Add(new SubjectComponentDto());

        return result;
    }

    public async Task UpdateAsync(SubjectForm form)
    {
        var subject = await repository.GetAsync(new SubjectId(form.Id.Value));

        form.Name.Write(subject.Name);

        subject.Update(form.Code, new SystemFileId(form.Image.Id));

        var components = form.SubjectComponents
            .Select(x => new ComponentId(x.ComponentId.Value))
            .ToList();
        subject.SetComponents(components);

        repository.Update(subject);
    }

    public async Task<SubjectForm> GetAsync(SubjectId id)
    {
        var entity = await repository.GetAsync(id);
        if (entity is null)
            throw new Exception("No records were found with given parameters");
        var form = SubjectForm.GetNewInstance();

        form.Read(entity);
        form.Image = new FileDto(await fileRepository.GetAsync(entity.ImageId));

        return form;
    }
}