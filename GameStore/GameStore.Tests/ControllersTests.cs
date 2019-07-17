using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GameStore.Infrastructure;
using GameStore.PL;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RazorPagesProject.Tests;
using Xunit;

namespace GameStore.Tests
{
    public class ControllersTests
        : IClassFixture<CustomWepAppFactory<Startup>>
    {
        private readonly CustomWepAppFactory<Startup> _factory;

        public ControllersTests(CustomWepAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/Game")]
        [InlineData("api/Publisher")]
        [InlineData("api/Genre")]
        public async Task GetGames_EndpointsReturnSuccessAndJsonContentType(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Theory]
        [InlineData("api/Roles")]
        public async Task GetRolesControllerWithoutToken_ShouldReturnUnauthorize(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory]
        [InlineData("api/Roles")]
        [InlineData("api/Roles/User")]
        public async Task PostRolesControllerWithoutToken_ShouldReturnUnauthorize(string url)
        {
            var client = _factory.CreateClient();
            var content = new StringContent("{\"name\":\"manager\"}");

            var response = await client.PostAsync(url, content);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory]
        [InlineData("api/Publisher")]
        public async Task PostPublisherController_CorrectPublisher_ShouldReturnOk(string url)
        {
            var client = _factory.CreateClient();

            CreatePublisherViewModel publisherViewModel = new CreatePublisherViewModel { Name = "Unreal Publisher" };
            var content = new StringContent(JsonConvert.SerializeObject(publisherViewModel), encoding: System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}