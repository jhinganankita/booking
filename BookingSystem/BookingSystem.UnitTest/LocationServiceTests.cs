namespace BookingSystem.UnitTest
{
    [TestFixture]
    internal class LocationServiceTests
    {
        private Mock<ILocationRepository> mockLocationRepository;
        private LocationService locationService;

        [SetUp]
        public void Setup()
        {
            mockLocationRepository = new Mock<ILocationRepository>();
            locationService = new LocationService(mockLocationRepository.Object);
        }

        [Test]
        public async Task GetAsync_ValidData_ReturnsSuccessWithLocations()
        {
            // Arrange
            var locations = new List<Location> {
            new Location { Id = 1, Name = "Location 1" },
            new Location { Id = 2, Name = "Location 2" }
        };
            mockLocationRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(locations);

            // Act
            var result = await locationService.GetAsync();

            // Assert
            Assert.IsTrue(result.isSuccess);
            Assert.AreEqual(2, result.locations.Count());
            Assert.AreEqual("", result.errorMessage);
        }

        [Test]
        public async Task GetAsync_EmptyData_ReturnsSuccessWithNoLocations()
        {
            // Arrange
            var locations = new List<Location>();
            mockLocationRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(locations);

            // Act
            var result = await locationService.GetAsync();

            // Assert
            Assert.IsTrue(result.isSuccess);
            Assert.AreEqual(0, result.locations.Count());
            Assert.AreEqual("", result.errorMessage);
        }

        [Test]
        public async Task GetAsync_RepositoryError_ReturnsFailureWithErrorMessage()
        {
            // Arrange
            var errorMessage = "Failed to retrieve locations";
            mockLocationRepository.Setup(r => r.GetAllAsync()).ThrowsAsync(new Exception(errorMessage));

            // Act
            var result = await locationService.GetAsync();

            // Assert
            Assert.IsFalse(result.isSuccess);
            Assert.IsNull(result.locations);
            Assert.AreEqual(errorMessage, result.errorMessage);
        }
    }
}
