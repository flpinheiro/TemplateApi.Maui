using TemplateApi.Domain.Models.Enums;

namespace TemplateApi.Domain.Models.Queries;

public class PersonQuery
{
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public SortAsEnum SortAs { get; set; } = SortAsEnum.Asc;
    public PersonEnum SortBy { get; set; } = PersonEnum.Name;
}
