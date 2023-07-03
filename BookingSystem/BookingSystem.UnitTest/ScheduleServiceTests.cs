using System.Linq.Expressions;

namespace BookingSystem.UnitTest
{
    [TestFixture]
    public class ScheduleServiceTests
    {
        private Mock<IRouteService> mockRouteService;
        private Mock<IBusSchedulesRepository> mockBusScheduleRepository;
        private Mock<ITrainSchedulesRepository> mockTrainScheduleRepository;
        private Mock<IPlaneSchedulesRepository> mockPlaneScheduleRepository;
        private ScheduleService scheduleService;

        [SetUp]
        public void Setup()
        {
            mockRouteService = new Mock<IRouteService>();
            mockBusScheduleRepository = new Mock<IBusSchedulesRepository>();
            mockTrainScheduleRepository = new Mock<ITrainSchedulesRepository>();
            mockPlaneScheduleRepository = new Mock<IPlaneSchedulesRepository>();

            scheduleService = new ScheduleService(
                mockRouteService.Object,
                mockBusScheduleRepository.Object,
                mockTrainScheduleRepository.Object,
                mockPlaneScheduleRepository.Object
            );
        }

        [Test]
        public async Task GetAsync_ValidRequest_ReturnsSchedules()
        {
            // Arrange
            var scheduleRequest = new ScheduleRequestDto
            {
                SourceId = 1,
                DestinationId = 2,
                TicketType = TicketTypeEnum.Bus,
                DepartureDate = DateTime.Now
            };

            var route = (true, new RouteDto { Id = 1 }, string.Empty);
            var busSchedules = new List<BusSchedules> { new BusSchedules { Id = 1 } };

            mockRouteService.Setup(r => r.GetRouteBySourceAndDestinationAsync(scheduleRequest.SourceId, scheduleRequest.DestinationId))
            .ReturnsAsync(route);
            mockBusScheduleRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<BusSchedules, bool>>>(), It.IsAny<Expression<Func<BusSchedules, object>>[]>()))
                .ReturnsAsync(busSchedules);

            // Act
            var result = await scheduleService.GetAsync(scheduleRequest);

            // Assert
            Assert.IsTrue(result.isSuccess);
            Assert.AreEqual(1, result.schedules.Count());
            Assert.AreEqual(string.Empty, result.errorMessage);
        }

      
        [Test]
        public async Task GetAsync_ExceptionThrown_ReturnsFailureWithErrorMessage()
        {
            // Arrange
            var scheduleRequest = new ScheduleRequestDto
            {
                SourceId = 1,
                DestinationId = 2,
                TicketType = TicketTypeEnum.Bus,
                DepartureDate = DateTime.Now
            };

            mockRouteService.Setup(r => r.GetRouteBySourceAndDestinationAsync(scheduleRequest.SourceId, scheduleRequest.DestinationId))
                .ThrowsAsync(new Exception("Failed to retrieve route"));

            // Act
            var result = await scheduleService.GetAsync(scheduleRequest);

            // Assert
            Assert.IsFalse(result.isSuccess);
            Assert.IsNull(result.schedules);
            Assert.AreEqual("Failed to retrieve route", result.errorMessage);
        }
    }
}
