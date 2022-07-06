namespace IntroductionToLINQandASP.NetMVC_SD115.Models
{
    public class Reservation
    {
        public int IdCounter { get; set; } = 1;
        public DateTime Date { get; set; }
        public int Occupants { get; set; }
        public bool IsCurrent { get; set; } = false;
        public Client Client { get; set; }
        public List<Client> Clients { get; set; }
        public Room Room { get; set; }

        public Reservation(Room room, Client client)
        {
            Room = room;
            Client = client;
            IdCounter++;

        }
    }
}
