using System;
using Xunit;
using Moq;

namespace RefreshingCatch.CatchService.Test
{
    public class CatchServiceTest
    {
        [Fact]
        public void Get_Item_From_LocalCatchService()
        {
            var fetchServiceMoq = new Mock<IFetchService>();
            fetchServiceMoq.Setup(x=>x.Fetch("1")).Returns("TestValue");
            var catchService = new CatchService(fetchServiceMoq.Object);

            string acualValue = "TestValue";
            string expectedValue = catchService.Get("1");
            expectedValue = catchService.Get("1");
            fetchServiceMoq.Verify(mock => mock.Fetch("1"), Times.Once());

            Assert.Equal(acualValue, expectedValue);
        }

        [Fact]
        public void Get_Item_From_ExternalService()
        {
            var fetchServiceMoq = new Mock<IFetchService>();
            fetchServiceMoq.Setup(x=>x.Fetch("1")).Returns("TestValue");
            var catchService = new CatchService(fetchServiceMoq.Object);

            string acualValue = "TestValue";
            string expectedValue = catchService.Get("1");

            Assert.Equal(acualValue, expectedValue);
        }

        [Fact]
        public void Check_LeastRecentItem_From_LocalCatchService()
        {
            var fetchServiceMoq = new Mock<IFetchService>();
            fetchServiceMoq.Setup(x=>x.Fetch("1")).Returns("TestValue");
            fetchServiceMoq.Setup(x=>x.Fetch("2")).Returns("TestValue2");
            fetchServiceMoq.Setup(x=>x.Fetch("3")).Returns("TestValue3");

            var catchService = new CatchService(fetchServiceMoq.Object);
            
            string acualValue = "TestValue";
            string expectedValue = catchService.Get("1");

            Assert.Equal(acualValue, expectedValue);
        }

    }
}
