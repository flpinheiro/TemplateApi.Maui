using Moq;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemplateApi.Domain.Services;
using TemplateApi.Test.TestUtils;

namespace TemplateApi.Test.Services
{
    public class PersonServiceTest
    {
        private readonly PersonService _service;
        private readonly MockHttpMessageHandler _mockHttp;
        private const string _url = "http://localhost";

        public PersonServiceTest()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();

            _mockHttp = new MockHttpMessageHandler();
            var client = _mockHttp.ToHttpClient();
            client.BaseAddress = new Uri(_url);
            httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            _service = new PersonService(httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task Add_Test()
        {
            _mockHttp
                .When($"{_url}/Person")
                .Respond("application/json", Fixture.PersonViewModelString);
            var content = await _service.Add(Fixture.PersonViewModel);
            Assert.NotNull(content);
            Assert.Equal(Fixture.PersonViewModel.Name, content.Name);
            Assert.Equal(Fixture.PersonViewModel.Surname, content.Surname);
            Assert.Equal(Fixture.PersonViewModel.Birthday, content.Birthday);
        }

        [Fact]
        public async Task Update_Test()
        {
            _mockHttp
                .When($"{_url}/Person/id")
                .Respond(HttpStatusCode.NoContent);
            await _service.Update(Fixture.PersonViewModel);
        }

        [Fact]
        public async Task Delete_Test()
        {
            _mockHttp
                .When($"{_url}/Person/id")
                .Respond(HttpStatusCode.NoContent);
            await _service.Delete("id");
        }

        [Fact]
        public async Task GetById_Test()
        {
            _mockHttp
                .When($"{_url}/Person/*")
                .Respond("application/json", Fixture.PersonViewModelString);
            var content = await _service.Get("id");
            Assert.NotNull(content);
            Assert.Equal(Fixture.PersonViewModel.Name, content.Name);
            Assert.Equal(Fixture.PersonViewModel.Surname, content.Surname);
            Assert.Equal(Fixture.PersonViewModel.Birthday, content.Birthday);
        }

        [Fact]
        public async Task Get_Test()
        {
            _mockHttp
                .When($"{_url}/Person")
                .Respond("application/json", Fixture.PersonViewModelListString);
            var content = await _service.Get(Fixture.PersonQuery);
            Assert.NotNull(content);
            var result = content.First();
            Assert.NotNull(result);
            Assert.Equal(Fixture.PersonViewModel.Name, result.Name);
            Assert.Equal(Fixture.PersonViewModel.Surname, result.Surname);
            Assert.Equal(Fixture.PersonViewModel.Birthday, result.Birthday);
        }

        [Fact]
        public async Task GetPaginated_Test()
        {
            _mockHttp
                .When($"{_url}/Person")
                .Respond("application/json", Fixture.PersonViewModelListString);
            var content = await _service.Get(Fixture.PersonQuery, Fixture.PaginationQuery);
            Assert.NotNull(content);
            var result = content.First();
            Assert.NotNull(result);
            Assert.Equal(Fixture.PersonViewModel.Name, result.Name);
            Assert.Equal(Fixture.PersonViewModel.Surname, result.Surname);
            Assert.Equal(Fixture.PersonViewModel.Birthday, result.Birthday);
        }

        [Fact]
        public async Task Count_test()
        {
            _mockHttp
                .When($"{_url}/Person/Count")
                .Respond("application/json", Fixture.PaginationResponseString);

            var content = await _service.Count(Fixture.PersonQuery, Fixture.PaginationQuery);
            Assert.NotNull(content);
            Assert.Equal(Fixture.PaginationResponse.Pages, content.Pages);
            Assert.Equal(Fixture.PaginationResponse.Total, content.Total);
        }
    }
}
