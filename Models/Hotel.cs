namespace IntroductionToLINQandASP.NetMVC_SD115.Models
{
    public static class Hotel
    {
        public static string Name { get; set; }
        public static string Address { get; set; }
        public static ICollection<Room> Rooms { get; set; }
        public static ICollection<Reservation> Reservations { get; set; }
        public static ICollection<Client> Clients { get; set; }
        static Hotel()
        {
            Name = "MITT WINNIPEG Hotel";
            Address = "Henloy Bay";
            Rooms = new HashSet<Room>();
            Reservations = new HashSet<Reservation>();
            Clients = new HashSet<Client>();

            Room room2 = new Room("1002", 1, "Regular");
            Room room1 = new Room("1001", 2, "Regular");
            Room room3 = new Room("1003", 2, "Premium");

            Rooms.Add(room1);
            Rooms.Add(room2);
            Rooms.Add(room3);
            Client client1 = new Client("Honey", 9898656545458787, "Regular");
            Client client2 = new Client("Bunny", 9898232245696161, "Regular");
            Client client3 = new Client("Money", 8084333312984577, "Premium");

            Clients.Add(client1);
            Clients.Add(client2);
            Clients.Add(client3);

        }
        static Client GetClient(int clientId)
        {
            Client client = Clients.First(client => client.IdCounter == clientId);
            return client;
        }

        static Reservation GetReservation(int id)
        {
            Reservation reservation = Reservations.First(reservation => reservation.IdCounter == id);
            return reservation;
        }

        static Room GetRoom(string roomNumber)
        {
            Room room = Rooms.First(room => room.Number == roomNumber);
            return room;
        }

        static List<Room> GetVacantRooms()
        {
            List<Room> vacantRooms = Rooms.Where(room => !room.Occupied).ToList();
            return vacantRooms;
        }

        public static List<Client> TopThreeClients()
        {
            List<Client> listOfClientByReservation = Clients.OrderByDescending(c => c.Reservations.Count).ToList();
            List<Client> topThreeClients = new List<Client>();
            for (int i = 0; i < 3; i++)
            {
                topThreeClients.Add(listOfClientByReservation.ElementAt(i));
            }
            return topThreeClients;
        }

        public static Reservation AutomaticReservation(int clientID, int occupants)
        {
            try
            {
                List<Room> vacantRoom = GetVacantRooms();
                Room suitableRoom = vacantRoom.First(v => v.Capacity >= occupants);
                Client myClient = GetClient(clientID);
                Reservation newReservation = new Reservation(suitableRoom,myClient);
                suitableRoom.Reservations.Add(newReservation);
                myClient.Reservations.Add(newReservation);
                Reservations.Add(newReservation);
                return newReservation;
            }
            catch
            {
                throw new Exception("Invalid Booking");
            }

        }
        public static void Checkin(string clientName)
        {
            Reservation updateReservation = Reservations.First(r => r.Client.Name.Equals(clientName));
            updateReservation.Current = true;
        }

        public static void Checkout(int roomNum)
        {
            Reservation updateReservation = Reservations.First(r => r.Room.Equals(roomNum));
            updateReservation.Current = false;
        }

        public static void Checkout(string clientName)
        {
            Reservation updateReservation = Reservations.First(r => r.Client.Name.Equals(clientName));
            updateReservation.Current = false;
        }

        public static int TotalCapacityRemaining()
        {
            int totalCapacity = Rooms.Sum(r => r.Capacity);
            int occupants = Reservations.Sum(r => r.Occupants);
            int capacityRemaining = totalCapacity - occupants;
            return capacityRemaining;
        }

        public static int AverageOccupancyPercentage()
        {
            List<Reservation> currentReservation = Reservations.Where(r => r.Current.Equals(true)).ToList();
            int totalOccupants = currentReservation.Sum(r => r.Occupants);
            int totalCapacity = currentReservation.Sum(r => r.Room.Capacity);
            int average = (totalOccupants / totalCapacity) * 100;
            return average;
        }

        public static List<Reservation> FutureBooking()
        {
            DateTime todaysDate = new DateTime();
            List<Reservation> futureBooking = Reservations.Where(r => r.StartDate > todaysDate).ToList();
            return futureBooking;
        }
    }
}
