using TemplateApi.Domain.Interfaces;
using TemplateApi.Domain.Models.Queries;
using TemplateApi.Domain.Models.ViewModels;

namespace TemplateApi.Domain.Services;

public class PersonService : IPersonService
{
    private readonly HttpClient _client;
    public PersonService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient(nameof(PersonService));
    }

    public Task<PersonViewModel> Add(PersonViewModel person)
    {
        throw new NotImplementedException();
    }

    public Task<PaginationResponse> Count(PersonQuery query, PaginationQuery pagination)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonViewModel> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonViewModel>> Get(PersonQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonViewModel>> Get(PersonQuery query, PaginationQuery pagination)
    {
        throw new NotImplementedException();
    }

    public Task Update(PersonViewModel person)
    {
        throw new NotImplementedException();
    }
}
