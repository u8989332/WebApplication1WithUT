using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using WebApplication1WithUT.Controllers;

namespace NUnitTestProject1
{
    public class HomeControllerTests
    {
        const string FakeUserId = "5566";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Get_UserId_FromHttpContext()
        {
            // arrange
            var loggerMock = Substitute.For<ILogger<HomeController>>();
          
            var httpContext = new DefaultHttpContext();
            httpContext.Items["userId"] = FakeUserId;
            var context = new ControllerContext(new ActionContext(
                 httpContext,
                 new RouteData(),
                 new ControllerActionDescriptor()));

            HomeController hc = new HomeController(loggerMock) { 
            
                ControllerContext = context
            };

            // act
            var view = hc.Index() as ViewResult;
            var result = view.Model as string;

            // assert
            Assert.AreEqual(FakeUserId, result);
        }

    }
}