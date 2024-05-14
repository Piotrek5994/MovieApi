using Core.Model;
using Core.ModelDto;
using Microsoft.AspNetCore.Mvc.Testing;
using MovieApi;
using System.Net;
using System.Text.Json;

public class Integration
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly string _path = "/api/Movie";

    public Integration()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task Get_MovieById_ReturnsStatusOk()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"{_path}?Id=2");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("id",responseString);
    }

    [Fact]
    public async Task Get_Movie_ReturnsNotFound()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"{_path}?Id=5");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}