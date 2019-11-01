using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Api.Controllers;
using Api;
using Api.Models;
using System.Net;
using NSuperTest;
using System.Collections.Generic;
using System.Linq;

namespace Api.IntegrationTests
{
    public class EmptyClass: Connection
    {




        //Server server;

      
        public EmptyClass()
        {
            //server = new Server<Startup>();
        }

        [Fact]
        public void ShouldGiveValues()
        {
            server
                .Get("/api/values")
                .Set("Accept", "application/json")
                .ExpectOk()
                .End<IEnumerable<string>>((r, m) => {
                    Assert.Equal(3, m.Count());
                    Assert.Equal("this", m.ElementAt(0));
                    Assert.Equal("is", m.ElementAt(1));
                    Assert.Equal("codebit", m.ElementAt(2));
                });
        }

        [Fact]
        public void ShouldGiveValue()

        {
            server
                .Get("/api/values/2")
                .Set("Accept", "application/json")
                .ExpectOk()
                .End<string>((r, m) =>
               {
                   Assert.Equal("value", m);
               });
        }

        //private readonly HttpClient _client;

        //public EmptyClass()
        //{
        //    var appfactory = new WebApplicationFactory<Startup>();
        //    _client = appfactory.CreateClient();
        //}

        //[Fact]

        //public async Task Test1()
        //{
        //    var response = await _client.GetAsync(("api/articles/{id}").Replace("{id}", "3"));
        //    response.StatusCode.Equals(HttpStatusCode.OK);
        //    (await response.Content.ReadAsAsync<Article>()).();
        //}

    }
}
