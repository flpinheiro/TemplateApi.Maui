using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TemplateApi.Domain.Models.Queries;
using TemplateApi.Domain.Models.ViewModels;
using TemplateApi.Domain.Utils;

namespace TemplateApi.Test.TestUtils
{
    internal static class Fixture
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = JsonExtensions.GetJsonSerializerOptions();
        public static PersonQuery PersonQuery { get; } = new PersonQuery()
        {
            Name = "Test_user"
        };

        public static PaginationResponse PaginationResponse { get; } = new PaginationResponse(2,15);

        public static PaginationQuery PaginationQuery { get; } = new PaginationQuery();

        public static PersonViewModel PersonViewModel { get; } = new PersonViewModel()
        {
            Cpf = "",
            Birthday = new DateOnly(),
            Name = "test_user",
            Surname = "user_test",
            Id = "id"
        };

        public static IEnumerable<PersonViewModel> PersonViewModels { get; } = new List<PersonViewModel>()
        {
            PersonViewModel,
        };

        public static HttpResponseMessage PersonViewModelResponse { get; } = new HttpResponseMessage()
        {
            Content = JsonContent.Create(PersonViewModels),
            StatusCode = System.Net.HttpStatusCode.OK,
        };

        public static string PersonViewModelString { get; } = JsonSerializer.Serialize(PersonViewModel, jsonSerializerOptions);
        public static string PersonViewModelListString { get; } = JsonSerializer.Serialize(PersonViewModels, jsonSerializerOptions);
        public static string PaginationResponseString { get; } = JsonSerializer.Serialize(PaginationResponse, jsonSerializerOptions);
    }
}
