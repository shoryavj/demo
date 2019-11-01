using System;
using NSuperTest;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Api.Models;

namespace Api.IntegrationTests.ArticleControllerTest
{
    public class ArticleControllerTest: Connection
    {

        //Server server;

        public ArticleControllerTest()
        {
            //server = new Server<Startup>();

        }

        [Fact]
        public void ShouldGiveGetValues()
        {
            server
              .Get("/api/articles/")
              .Set("Accept", "application/json")
              .ExpectNotFound()
              .End();

        }

        [Fact]
        public void ShouldPostValues()
        {
            var article = new Article();
            article.Title = "Hi there";

            server
              .Post("/api/articles/")
              .Send(article)
              .ExpectNotFound()
              .End();

            server
                .Get("/api/articles/")
                .Set("Accept", "application/json")
                .ExpectOk()
                .End();
        }

        //[Fact]
        //public void ShouldPutValues()
        //{
        //    server
        //        .Put("/api/articles/")
        //        .ExpectOk()
        //        .End();
        //}

        //[Fact]
        //public void ShouldDeleteValues()
        //{
        //    server
        //       .Delete("/api/articles/")
        //       .ExpectOk()
        //       .End();

        //}
    }
}
