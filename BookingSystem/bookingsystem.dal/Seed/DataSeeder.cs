using BookingSystem.dal.Entity;


namespace BookingSystem.dal.Seed
{
    public class DataSeeder
    {
        private readonly BookingSystemDbContext _dbContext;

        public DataSeeder(BookingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedAdminUser()
        {
            _dbContext.Users.Add(new Users()
            {
                Username = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                Mobile = "8888888888",
                Password = "12345678"
            });

            _dbContext.Users.Add(new Users()
            {
                Username = "jhingan.ankita@gmail.com",
                FirstName = "jhingan",
                LastName = "ankita",
                Mobile = "8888888888",
                Password = "12345678"
            });
        }
        public void SeedLocation()
        {
            // Create instances of your entity classes
            var entity1 = new Location { Id = 1, Name = "Munich" };
            var entity2 = new Location { Id = 2, Name = "Berlin" };
            var entity3 = new Location { Id = 3, Name = "Stuttgart" };
            var entity4 = new Location { Id = 4, Name = "Cologne" };
            //var entity5 = new Location { Id = 5, Name = "Cologne" };
            //var entity6 = new Location { Id = 6, Name = "Hamburg" };
            //var entity7 = new Location { Id = 7, Name = "Bonn" };
            // ...

            // Add entities to the in-memory database
            _dbContext.Location.AddRange(entity1, entity2, entity3, entity4);
            _dbContext.SaveChanges();
        }

        public void SeedTrains()
        {
            // Create instances of your entity classes
            var entity1 = new Trains { Id = 1, Name = "ICEMuSt", Capacity = 50 };
            var entity2 = new Trains { Id = 2, Name = "ICEBeMu", Capacity = 50 };
            var entity3 = new Trains { Id = 3, Name = "ICEMuCo", Capacity = 50 };
            var entity4 = new Trains { Id = 4, Name = "ICEBeSt", Capacity = 50 };
            var entity5 = new Trains { Id = 5, Name = "ICEBeCo", Capacity = 50 };
            var entity6 = new Trains { Id = 6, Name = "ICECoSt", Capacity = 50 };
            // ...

            // Add entities to the in-memory database
            _dbContext.Trains.AddRange(entity1, entity2, entity3, entity4, entity5, entity6);
            _dbContext.SaveChanges();
        }

        public void SeedBuses()
        {
            // Create instances of your entity classes
            var entity1 = new Buses { Id = 1, Name = "BusMuSt", Capacity = 20 };
            var entity2 = new Buses { Id = 2, Name = "BusBeMu", Capacity = 20 };
            var entity3 = new Buses { Id = 3, Name = "BusMuCo", Capacity = 20 };
            var entity4 = new Buses { Id = 4, Name = "BusBeSt", Capacity = 20 };
            var entity5 = new Buses { Id = 5, Name = "BusBeCo", Capacity = 20 };
            var entity6 = new Buses { Id = 6, Name = "BusStCo", Capacity = 20 };

            // Add entities to the in-memory database
            _dbContext.Buses.AddRange(entity1, entity2, entity3, entity4, entity5, entity6);
            _dbContext.SaveChanges();
        }

        public void SeedPlanes()
        {
            // Create instances of your entity classes
            var entity1 = new Planes { Id = 1, Name = "Airway12", Capacity = 20 };
            var entity2 = new Planes { Id = 2, Name = "Airway23", Capacity = 20 };
            var entity3 = new Planes { Id = 3, Name = "Airway34", Capacity = 20 };
            var entity4 = new Planes { Id = 4, Name = "Airway67", Capacity = 20 };
            var entity5 = new Planes { Id = 5, Name = "Airway55", Capacity = 20 };
            var entity6 = new Planes { Id = 6, Name = "Airway88", Capacity = 20 };

            // Add entities to the in-memory database
            _dbContext.Planes.AddRange(entity1, entity2, entity3, entity4, entity5, entity6);
            _dbContext.SaveChanges();
        }

        public void SeedTicketType()
        {
            // Create instances of your entity classes
            var entity1 = new TicketType { Id = 1, Name = "Bus" };
            var entity2 = new TicketType { Id = 2, Name = "Train" };
            var entity3 = new TicketType { Id = 3, Name = "Plane" };
            // ...

            // Add entities to the in-memory database
            _dbContext.TicketType.AddRange(entity1, entity2, entity3);
            _dbContext.SaveChanges();
        }

        public void SeedRoutes()
        {
            // Create instances of your entity classes
            var entity1 = new Routes { Id = 1, SourceId = 1, DestinationId = 2, JourneyTime = 5, Stops = 3 };
            var entity2 = new Routes { Id = 2, SourceId = 2, DestinationId = 1, JourneyTime = 5, Stops = 3 };
            var entity3 = new Routes { Id = 3, SourceId = 1, DestinationId = 3, JourneyTime = 5, Stops = 3 };
            var entity4 = new Routes { Id = 4, SourceId = 3, DestinationId = 1, JourneyTime = 5, Stops = 3 };
            var entity5 = new Routes { Id = 5, SourceId = 1, DestinationId = 4, JourneyTime = 2, Stops = 3 };
            var entity6 = new Routes { Id = 6, SourceId = 4, DestinationId = 1, JourneyTime = 2, Stops = 3 };
            var entity7 = new Routes { Id = 7, SourceId = 2, DestinationId = 3, JourneyTime = 2, Stops = 3 };
            var entity8 = new Routes { Id = 8, SourceId = 3, DestinationId = 2, JourneyTime = 2, Stops = 3 };
            var entity9 = new Routes { Id = 9, SourceId = 2, DestinationId = 4, JourneyTime = 6, Stops = 3 };
            var entity10 = new Routes { Id = 10, SourceId = 4, DestinationId = 2, JourneyTime = 6, Stops = 3 };
            var entity11 = new Routes { Id = 11, SourceId = 3, DestinationId = 4, JourneyTime = 6, Stops = 3 };
            var entity12 = new Routes { Id = 12, SourceId = 4, DestinationId = 3, JourneyTime = 6, Stops = 3 };

            // Add entities to the in-memory database
            _dbContext.Routes.AddRange(entity1, entity2, entity3, entity4, entity5, entity6, entity7, entity8, entity9, entity10, entity11, entity12);
            _dbContext.SaveChanges();
        }

        public void SeedTrainSchedules()
        {
            // Create instances of your entity classes
            var entity1 = new TrainSchedules { Id = 1, DepartureTime = "6:00", ArrivalTime = "11:30", TrainId = 2, RouteId = 2, Fare = 105 };
            var entity2 = new TrainSchedules { Id = 2, DepartureTime = "12:00", ArrivalTime = "17:30", TrainId = 2, RouteId = 1, Fare = 115 };
            var entity3 = new TrainSchedules { Id = 3, DepartureTime = "18:00", ArrivalTime = "23:30", TrainId = 2, RouteId = 2, Fare = 125 };
            var entity4 = new TrainSchedules { Id = 4, DepartureTime = "00:00", ArrivalTime = "5:30", TrainId = 2, RouteId = 1, Fare = 135 };
            var entity5 = new TrainSchedules { Id = 5, DepartureTime = "5:00", ArrivalTime = "7:30", TrainId = 1, RouteId = 3, Fare = 145 };
            var entity6 = new TrainSchedules { Id = 6, DepartureTime = "8:00", ArrivalTime = "10:30", TrainId = 1, RouteId = 4, Fare = 155 };
            var entity7 = new TrainSchedules { Id = 7, DepartureTime = "1:00", ArrivalTime = "15:30", TrainId = 1, RouteId = 3, Fare = 115 };
            var entity8 = new TrainSchedules { Id = 8, DepartureTime = "16:00", ArrivalTime = "18:30", TrainId = 1, RouteId = 4, Fare = 125 };
            var entity9 = new TrainSchedules { Id = 9, DepartureTime = "5:00", ArrivalTime = "11:00", TrainId = 3, RouteId = 5, Fare = 135 };
            var entity10 = new TrainSchedules { Id = 10, DepartureTime = "18:00", ArrivalTime = "00:00", TrainId = 3, RouteId = 5, Fare = 145 };
            var entity11 = new TrainSchedules { Id = 11, DepartureTime = "11:00", ArrivalTime = "17:00", TrainId = 3, RouteId = 6, Fare = 205 };
            var entity12 = new TrainSchedules { Id = 12, DepartureTime = "00:00", ArrivalTime = "6:00", TrainId = 3, RouteId = 6, Fare = 345 };
            var entity13 = new TrainSchedules { Id = 13, DepartureTime = "5:00", ArrivalTime = "13:00", TrainId = 4, RouteId = 7, Fare = 185 };
            var entity14 = new TrainSchedules { Id = 14, DepartureTime = "15:00", ArrivalTime = "23:00", TrainId = 4, RouteId = 7, Fare = 165 };
            var entity15 = new TrainSchedules { Id = 15, DepartureTime = "8:00", ArrivalTime = "16:00", TrainId = 4, RouteId = 8, Fare = 145 };
            var entity16 = new TrainSchedules { Id = 16, DepartureTime = "17:00", ArrivalTime = "1:00", TrainId = 4, RouteId = 8, Fare = 195 };
            var entity17 = new TrainSchedules { Id = 17, DepartureTime = "5:00", ArrivalTime = "13:00", TrainId = 5, RouteId = 9, Fare = 125 };
            var entity18 = new TrainSchedules { Id = 18, DepartureTime = "15:00", ArrivalTime = "23:00", TrainId = 5, RouteId = 9, Fare = 155 };
            var entity19 = new TrainSchedules { Id = 19, DepartureTime = "8:00", ArrivalTime = "13:00", TrainId = 5, RouteId = 10, Fare = 115 };
            var entity20 = new TrainSchedules { Id = 20, DepartureTime = "15:00", ArrivalTime = "23:00", TrainId = 5, RouteId = 10, Fare = 155 };
            var entity21 = new TrainSchedules { Id = 21, DepartureTime = "6:00", ArrivalTime = "11:30", TrainId = 6, RouteId = 11, Fare = 185 };
            var entity22 = new TrainSchedules { Id = 22, DepartureTime = "12:00", ArrivalTime = "17:30", TrainId = 6, RouteId = 11, Fare = 115 };
            var entity23 = new TrainSchedules { Id = 23, DepartureTime = "18:00", ArrivalTime = "23:30", TrainId = 6, RouteId = 12, Fare = 145 };
            var entity24 = new TrainSchedules { Id = 24, DepartureTime = "00:00", ArrivalTime = "5:30", TrainId = 6, RouteId = 12, Fare = 195 };

            // Add entities to the in-memory database
            _dbContext.TrainSchedules.AddRange(entity1, entity2, entity3, entity4, entity5, entity6, entity7, entity8, entity9, entity10, entity11, entity12, entity13, entity14, entity15, entity16, entity17, entity18, entity19, entity20, entity21, entity22, entity23, entity24);
            _dbContext.SaveChanges();
        }

        public void SeedBusSchedules()
        {
            // Create instances of your entity classes
            var entity1 = new BusSchedules { Id = 1, DepartureTime = "6:00", ArrivalTime = "11:30", BusId = 2, RouteId = 2, Fare = 105 };
            var entity2 = new BusSchedules { Id = 2, DepartureTime = "12:00", ArrivalTime = "17:30", BusId = 2, RouteId = 1, Fare = 102 };
            var entity3 = new BusSchedules { Id = 3, DepartureTime = "18:00", ArrivalTime = "23:30", BusId = 2, RouteId = 2, Fare = 104 };
            var entity4 = new BusSchedules { Id = 4, DepartureTime = "00:00", ArrivalTime = "5:30", BusId = 2, RouteId = 1, Fare = 103 };
            var entity5 = new BusSchedules { Id = 5, DepartureTime = "5:00", ArrivalTime = "7:30", BusId = 1, RouteId = 3, Fare = 205 };
            var entity6 = new BusSchedules { Id = 6, DepartureTime = "8:00", ArrivalTime = "10:30", BusId = 1, RouteId = 4, Fare = 444 };
            var entity7 = new BusSchedules { Id = 7, DepartureTime = "1:00", ArrivalTime = "15:30", BusId = 1, RouteId = 3, Fare = 333 };
            var entity8 = new BusSchedules { Id = 8, DepartureTime = "16:00", ArrivalTime = "18:30", BusId = 1, RouteId = 4, Fare = 543 };
            var entity9 = new BusSchedules { Id = 9, DepartureTime = "5:00", ArrivalTime = "11:00", BusId = 3, RouteId = 5, Fare = 124 };
            var entity10 = new BusSchedules { Id = 10, DepartureTime = "18:00", ArrivalTime = "00:00", BusId = 3, RouteId = 5, Fare = 543 };
            var entity11 = new BusSchedules { Id = 11, DepartureTime = "11:00", ArrivalTime = "17:00", BusId = 3, RouteId = 6, Fare = 876 };
            var entity12 = new BusSchedules { Id = 12, DepartureTime = "00:00", ArrivalTime = "6:00", BusId = 3, RouteId = 6, Fare = 232 };
            var entity13 = new BusSchedules { Id = 13, DepartureTime = "5:00", ArrivalTime = "13:00", BusId = 4, RouteId = 7, Fare = 305 };
            var entity14 = new BusSchedules { Id = 14, DepartureTime = "15:00", ArrivalTime = "23:00", BusId = 4, RouteId = 7, Fare = 305 };
            var entity15 = new BusSchedules { Id = 15, DepartureTime = "8:00", ArrivalTime = "16:00", BusId = 4, RouteId = 8, Fare = 135 };
            var entity16 = new BusSchedules { Id = 16, DepartureTime = "17:00", ArrivalTime = "1:00", BusId = 4, RouteId = 8, Fare = 155 };
            var entity17 = new BusSchedules { Id = 17, DepartureTime = "5:00", ArrivalTime = "13:00", BusId = 5, RouteId = 9, Fare = 175 };
            var entity18 = new BusSchedules { Id = 18, DepartureTime = "15:00", ArrivalTime = "23:00", BusId = 5, RouteId = 9, Fare = 505 };
            var entity19 = new BusSchedules { Id = 19, DepartureTime = "8:00", ArrivalTime = "13:00", BusId = 5, RouteId = 10, Fare = 305 };
            var entity20 = new BusSchedules { Id = 20, DepartureTime = "15:00", ArrivalTime = "23:00", BusId = 5, RouteId = 10, Fare = 305 };
            var entity21 = new BusSchedules { Id = 21, DepartureTime = "6:00", ArrivalTime = "11:30", BusId = 6, RouteId = 11, Fare = 145 };
            var entity22 = new BusSchedules { Id = 22, DepartureTime = "12:00", ArrivalTime = "17:30", BusId = 6, RouteId = 11, Fare = 405 };
            var entity23 = new BusSchedules { Id = 23, DepartureTime = "18:00", ArrivalTime = "23:30", BusId = 6, RouteId = 12, Fare = 605 };
            var entity24 = new BusSchedules { Id = 24, DepartureTime = "00:00", ArrivalTime = "5:30", BusId = 6, RouteId = 12, Fare = 165 };

            // Add entities to the in-memory database
            _dbContext.BusSchedules.AddRange(entity1, entity2, entity3, entity4, entity5, entity6, entity7, entity8, entity9, entity10, entity11, entity12, entity13, entity14, entity15, entity16, entity17, entity18, entity19, entity20, entity21, entity22, entity23, entity24);
            _dbContext.SaveChanges();
        }

        public void SeedPlaneSchedules()
        {
            // Create instances of your entity classes
            var entity1 = new PlaneSchedules { Id = 1, DepartureTime = "6:00", ArrivalTime = "11:30", PlaneId = 2, RouteId = 2, Fare = 105 };
            var entity2 = new PlaneSchedules { Id = 2, DepartureTime = "12:00", ArrivalTime = "17:30", PlaneId = 2, RouteId = 1, Fare = 324 };
            var entity3 = new PlaneSchedules { Id = 3, DepartureTime = "18:00", ArrivalTime = "23:30", PlaneId = 2, RouteId = 2, Fare = 543 };
            var entity4 = new PlaneSchedules { Id = 4, DepartureTime = "00:00", ArrivalTime = "5:30", PlaneId = 2, RouteId = 1, Fare = 434 };
            var entity5 = new PlaneSchedules { Id = 5, DepartureTime = "5:00", ArrivalTime = "7:30", PlaneId = 1, RouteId = 3, Fare = 222 };
            var entity6 = new PlaneSchedules { Id = 6, DepartureTime = "8:00", ArrivalTime = "10:30", PlaneId = 1, RouteId = 4, Fare = 444 };
            var entity7 = new PlaneSchedules { Id = 7, DepartureTime = "1:00", ArrivalTime = "15:30", PlaneId = 1, RouteId = 3, Fare = 555 };
            var entity8 = new PlaneSchedules { Id = 8, DepartureTime = "16:00", ArrivalTime = "18:30", PlaneId = 1, RouteId = 4, Fare = 333 };
            var entity9 = new PlaneSchedules { Id = 9, DepartureTime = "5:00", ArrivalTime = "11:00", PlaneId = 3, RouteId = 5, Fare = 343 };
            var entity10 = new PlaneSchedules { Id = 10, DepartureTime = "18:00", ArrivalTime = "00:00", PlaneId = 3, RouteId = 5, Fare = 205 };
            var entity11 = new PlaneSchedules { Id = 11, DepartureTime = "11:00", ArrivalTime = "17:00", PlaneId = 3, RouteId = 6, Fare = 205 };
            var entity12 = new PlaneSchedules { Id = 12, DepartureTime = "00:00", ArrivalTime = "6:00", PlaneId = 3, RouteId = 6, Fare = 305 };
            var entity13 = new PlaneSchedules { Id = 13, DepartureTime = "5:00", ArrivalTime = "13:00", PlaneId = 4, RouteId = 7, Fare = 505 };
            var entity14 = new PlaneSchedules { Id = 14, DepartureTime = "15:00", ArrivalTime = "23:00", PlaneId = 4, RouteId = 7, Fare = 605 };
            var entity15 = new PlaneSchedules { Id = 15, DepartureTime = "8:00", ArrivalTime = "16:00", PlaneId = 4, RouteId = 8, Fare = 155 };
            var entity16 = new PlaneSchedules { Id = 16, DepartureTime = "17:00", ArrivalTime = "1:00", PlaneId = 4, RouteId = 8, Fare = 165 };
            var entity17 = new PlaneSchedules { Id = 17, DepartureTime = "5:00", ArrivalTime = "13:00", PlaneId = 5, RouteId = 9, Fare = 175 };
            var entity18 = new PlaneSchedules { Id = 18, DepartureTime = "15:00", ArrivalTime = "23:00", PlaneId = 5, RouteId = 9, Fare = 175 };
            var entity19 = new PlaneSchedules { Id = 19, DepartureTime = "8:00", ArrivalTime = "13:00", PlaneId = 5, RouteId = 10, Fare = 135 };
            var entity20 = new PlaneSchedules { Id = 20, DepartureTime = "15:00", ArrivalTime = "23:00", PlaneId = 5, RouteId = 10, Fare = 305 };
            var entity21 = new PlaneSchedules { Id = 21, DepartureTime = "6:00", ArrivalTime = "11:30", PlaneId = 6, RouteId = 11, Fare = 155 };
            var entity22 = new PlaneSchedules { Id = 22, DepartureTime = "12:00", ArrivalTime = "17:30", PlaneId = 6, RouteId = 11, Fare = 605 };
            var entity23 = new PlaneSchedules { Id = 23, DepartureTime = "18:00", ArrivalTime = "23:30", PlaneId = 6, RouteId = 12, Fare = 305 };
            var entity24 = new PlaneSchedules { Id = 24, DepartureTime = "00:00", ArrivalTime = "5:30", PlaneId = 6, RouteId = 12, Fare = 155 };

            // Add entities to the in-memory database
            _dbContext.PlaneSchedules.AddRange(entity1, entity2, entity3, entity4, entity5, entity6, entity7, entity8, entity9, entity10, entity11, entity12, entity13, entity14, entity15, entity16, entity17, entity18, entity19, entity20, entity21, entity22, entity23, entity24);
            _dbContext.SaveChanges();
        }
    }
}
