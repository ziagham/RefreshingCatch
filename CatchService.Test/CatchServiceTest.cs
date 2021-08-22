using System;
using Xunit;
using Moq;

namespace RefreshingCatch.CatchService.Test
{
    public class CatchServiceTest
    {
        private const int cacheSize = 2;

        [Fact]
        public void Get_Item_From_LocalCatchService_ShouldPass()
        {
            var fetchServiceMoq = new Mock<IFetchService>();
            fetchServiceMoq.Setup(x=>x.Fetch("1")).Returns("TestValue");
            var catchService = new CatchService(cacheSize, fetchServiceMoq.Object);

            string acualValue = "TestValue";
            string expectedValue = catchService.Get("1");
            expectedValue = catchService.Get("1");
            fetchServiceMoq.Verify(mock => mock.Fetch("1"), Times.Once());

            Assert.Equal(acualValue, expectedValue);
        }

        [Fact]
        public void Get_Item_From_ExternalService_ShouldPass()
        {
            var fetchServiceMoq = new Mock<IFetchService>();
            fetchServiceMoq.Setup(x=>x.Fetch("1")).Returns("TestValue");
            var catchService = new CatchService(cacheSize, fetchServiceMoq.Object);

            string acualValue = "TestValue";
            string expectedValue = catchService.Get("1");

            Assert.Equal(acualValue, expectedValue);
        }

        [Fact]
        public void CatchService_NullReferenceInIFetchServiceParam_ArgumentNullExceptionThrown()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                IFetchService fetchService = null;
                new CatchService(cacheSize, fetchService);
            });
        }
    }
}
