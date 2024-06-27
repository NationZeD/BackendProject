using BackendProject.App.FAQs.Entities;
using BackendProject.App.Multilinguals.Dtos;
using BackendProject.Shared.Abstractions.LanguagedCRUD;

namespace BackendProject.App.FAQs.Dtos;

public class FAQItemForm : IForm<FAQItem>
{
    public Guid? Id { get; set; }
    public MultiLingualInput Question { get; set; }
    public MultiLingualInput Answer { get; set; }

    public FAQItemForm()
    {
    }

    public void Write(FAQItem entity)
    {
        Question.Write(entity.Question);
        Answer.Write(entity.Answer);
    }

    public void Read(FAQItem entity)
    {
        Id = entity.Id.Value;
        Question.Read(entity.Question);
        Answer.Read(entity.Answer);
    }

    public static FAQItemForm GetNewInstance()
    {
        return new FAQItemForm
        {
            Id = null,
            Question = MultiLingualInput.GetNewInstance(),
            Answer = MultiLingualInput.GetNewInstance(),
        };
    }
}