using TemplateApi.Domain.Models.Queries;
using TemplateApi.Domain.Models.ViewModels;

namespace TemplateApi.Domain.Interfaces;

public interface IPersonService
{
    Task<PersonViewModel> Get(string id);
    Task<IEnumerable<PersonViewModel>> Get(PersonQuery query);
    Task<IEnumerable<PersonViewModel>> Get(PersonQuery query, PaginationQuery pagination);
    Task<PaginationResponse> Count(PersonQuery query, PaginationQuery pagination);

    Task<PersonViewModel> Add(PersonViewModel person);
    Task Update(PersonViewModel person);
    Task Delete(string id);
}
