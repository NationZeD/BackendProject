using BackendProject.App.FAQs.ValueObjects;
using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.FAQs.Entities;

public class FAQItem : BaseEntity<FAQItemId>
{
    public Multilingual? Question { get; private set; }
    public Multilingual? Answer { get; private set; }

    private FAQItem(FAQItemId id, Multilingual question, Multilingual answer) : base(id)
    {
        Question = question;
        Answer = answer;
    }

    private FAQItem(FAQItemId id) : base(id)
    {
    }

    public static FAQItem Create(Multilingual question, Multilingual answer)
    {
        return new FAQItem(new FAQItemId(Guid.NewGuid()), question, answer);
    }
}