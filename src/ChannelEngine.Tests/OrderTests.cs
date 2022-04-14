using System.Linq;
using System.Threading;
using ChannelEngine.Services.HttpClients;
using ChannelEngine.Services.Services;
using Moq;
using NUnit.Framework;
using Xunit;

namespace ChannelEngine.Tests;

public class OrderTests
{
    private Mock<OrderService> _orderServiceMock;

    public OrderTests()
    {
        var _orderClient = new Mock<OrderHttpClient>();
        _orderServiceMock = new Mock<OrderService>(_orderClient.Object);

        _orderServiceMock.Setup(a => a.GetTopSoldProducts(5,CancellationToken.None)).ReturnsAsync(DataGenerator.CreateDummyData());
    }

    [Fact]
    public void ShouldReturnTop5Products()
    {
        //Arrange
        //In this case we don't have arrange

        //Act
        var result = _orderServiceMock.Object.GetTopSoldProducts(5,CancellationToken.None)
            .GetAwaiter()
            .GetResult();
        
        //Assert
        Assert.Equals(5, result.Count());
    }
}
