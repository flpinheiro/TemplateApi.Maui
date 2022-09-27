using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TemplateApi.Domain.Interfaces;
using TemplateApi.Domain.Models.Queries;
using TemplateApi.Domain.Models.ViewModels;
using TemplateApi.Domain.Utils;

namespace TemplateApi.Domain.Services;

public class PersonService : IPersonService
{
    private readonly HttpClient _client;
    private readonly Uri _baseUri;
    private readonly JsonSerializerOptions _options;
    public PersonService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient(nameof(PersonService));
        _baseUri = _client.BaseAddress ?? throw new ArgumentNullException("Base Uri");
        _options = JsonExtensions.GetJsonSerializerOptions();
    }

    public async Task<PersonViewModel> Add(PersonViewModel person)
    {
        var uri = new Uri(_baseUri, "Person");
        var msg = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = JsonContent.Create(person),
        };

        return await SendAsync<PersonViewModel>(msg) ?? new PersonViewModel();
    }

    public async Task<PaginationResponse> Count(PersonQuery personQuery, PaginationQuery paginationQuery)
    {
        var query = GetQuery(personQuery, paginationQuery);

        var uri = new Uri(_baseUri, $"Person/Count{query}");
        var msg = new HttpRequestMessage(HttpMethod.Get, uri);

        return await SendAsync<PaginationResponse>(msg) ?? new PaginationResponse(0,0);
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<PersonViewModel> Get(string id)
    {
        var uri = new Uri(_baseUri, $"Person/{id}");
        var msg = new HttpRequestMessage(HttpMethod.Get, uri);
        
        return await SendAsync<PersonViewModel>(msg) ?? new PersonViewModel();
    }

    public async Task<IEnumerable<PersonViewModel>> Get(PersonQuery personQuery)
    {
        var query = GetQuery(personQuery);

        var uri = new Uri(_baseUri, $"Person{query}");
        var msg = new HttpRequestMessage(HttpMethod.Get, uri);
        
        return await SendAsync<IEnumerable<PersonViewModel>>(msg) ?? new List<PersonViewModel>();
    }

    public async Task<IEnumerable<PersonViewModel>> Get(PersonQuery personQuery, PaginationQuery paginationQuery)
    {
        var query = GetQuery(personQuery, paginationQuery);

        var uri = new Uri(_baseUri, $"Person{query}");
        var msg = new HttpRequestMessage(HttpMethod.Get, uri);
        
        return await SendAsync<IEnumerable<PersonViewModel>>(msg) ?? new List<PersonViewModel>();
    }

    public Task Update(PersonViewModel person)
    {
        throw new NotImplementedException();
    }

    private static string GetQuery(PersonQuery personQuery, PaginationQuery? paginationQuery = null)
    {
        var queryList = personQuery.AsDictionary().ToList();
        if (paginationQuery != null)
            queryList.AddRange(paginationQuery.AsDictionary().ToList());

        return QueryString.Create(queryList).ToString();
    }

    private async Task<T?> SendAsync<T>(HttpRequestMessage msg) 
    {
        var response = await _client.SendAsync(msg);
        response.EnsureSuccessStatusCode();
        var returnedJson = await response.Content.ReadAsStringAsync();
        var content = JsonSerializer.Deserialize<T>(returnedJson, _options);
        return content;
    }
}
