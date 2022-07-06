namespace IntroductionToLINQandASP.NetMVC_SD115.Models
{
    public class Reservation
    {
        public int IdCounter { get; set; } = 1;
        public DateTime Created { get; set; }
        public DateTime StartDate { get; set; }
        public int Occupants { get; set; }
        public bool Current { get; set; } = false;
        public Client Client { get; set; }
        public List<Client> Clients { get; set; }
        public Room Room { get; set; }

        public Reservation(Room room, Client client)
        {
            Room = room;
            Client = client;
            IdCounter++;
            Created = DateTime.Now;
            StartDate = DateTime.Today.AddDays(1);

        }
    }
}
