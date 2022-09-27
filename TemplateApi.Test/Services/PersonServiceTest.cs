using Moq;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public PersonServiceTest()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();

            _mockHttp = new MockHttpMessageHandler();
            var client = _mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("http://localhost");
            httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            _service = new PersonService(httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task GetTestAsync()
        {
            _mockHttp
                .When("")
                .Respond("application/json", Fixture.PersonViewModelListString);
            var content = await _service.Get(Fixture.PersonQuery);
            Assert.NotNull(content);
        }

        [Fact]
        public async Task GetPaginatedTestAsync()
        {
            _mockHttp
                .When("")
                .Respond("application/json", Fixture.PersonViewModelListString);
            var content = await _service.Get(Fixture.PersonQuery, Fixture.PaginationQuery);
            Assert.NotNull(content);
            //Assert.Equal(Fixture.PersonViewModels, content);
        }
    }
}
