using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Client.Services;

namespace Testing.Tests.Services
{
    [TestClass]
    public class NumberVerificationApiFixture
    {
        [TestMethod]
        public void TestA()
        {
            var mockNumberVerificationApi = new Mock<INumberVerificationApiClient>();
            mockNumberVerificationApi.Setup(s => s.GetNumberIsVerifiedResponse(It.IsAny<long>())).Returns(new HttpResponseMessage());
            var myApi = new NumberVerificationApi(mockNumberVerificationApi.Object);
        }
    }
}
