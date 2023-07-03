using System.Linq.Expressions;

namespace BookingSystem.UnitTest
{
    [TestFixture]
    public class RouteServiceTests
    {
        private Mock<IRoutesRepository> mockRoutesRepository;
        private RouteService routeService;

        [SetUp]
        public void Setup()
        {
            mockRoutesRepository = new Mock<IRoutesRepository>();
            routeService = new RouteService(mockRoutesRepository.Object);
        }

        [Test]
        public async Task GetRouteBySourceAndDestinationAsync_ValidIds_ReturnsSuccessWithRouteDto()
        {
            // Arrange
            int sourceId = 1;
            int destinationId = 2;
            var route = new Routes { Id = 1, SourceId = sourceId, DestinationId = destinationId };
            mockRoutesRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Routes, bool>>>(), It.IsAny<Expression<Func<Routes, object>>[]>()))
                .ReturnsAsync(new List<Routes> { route });

            // Act
            var result = await routeService.GetRouteBySourceAndDestinationAsync(sourceId, destinationId);

            // Assert
            Assert.IsTrue(result.isSuccess);
            Assert.IsNotNull(result.routeDto);
            Assert.AreEqual("", result.errorMessage);
        }

        [Test]
        public async Task GetRouteBySourceAndDestinationAsync_NoMatchingRoute_ReturnsFailureWithErrorMessage()
        {
            // Arrange
            int sourceId = 1;
            int destinationId = 2;
            mockRoutesRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Routes, bool>>>(), It.IsAny<Expression<Func<Routes, object>>[]>()))
                .ReturnsAsync(new List<Routes>());

            // Act
            var result = await routeService.GetRouteBySourceAndDestinationAsync(sourceId, destinationId);

            // Assert
            Assert.IsFalse(result.isSuccess);
            Assert.IsNull(result.routeDto);
            Assert.AreEqual("Sequence contains no elements", result.errorMessage); // or specify an expected error message
        }

        [Test]
        public async Task GetRouteBySourceAndDestinationAsync_ExceptionThrown_ReturnsFailureWithErrorMessage()
        {
            // Arrange
            int sourceId = 1;
            int destinationId = 2;
            var errorMessage = "Failed to get route";
            mockRoutesRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Routes, bool>>>(), It.IsAny<Expression<Func<Routes, object>>[]>()))
                .ThrowsAsync(new Exception(errorMessage));

            // Act
            var result = await routeService.GetRouteBySourceAndDestinationAsync(sourceId, destinationId);

            // Assert
            Assert.IsFalse(result.isSuccess);
            Assert.IsNull(result.routeDto);
            Assert.AreEqual(errorMessage, result.errorMessage);
        }
    }
}
