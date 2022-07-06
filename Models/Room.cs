namespace IntroductionToLINQandASP.NetMVC_SD115.Models
{
    public class Room
    {
        public string Number { get; set; }
        public int Capacity { get; set; }
        public bool Occupied { get; set; } = false;
        public string Rating { get; set; }
        public int Occupants { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Reservation Reservation { get; set; }
        public Room(string number, int capacity, string rating)
        {
            Number = number;
            Capacity = capacity;
            Rating = rating;
        }
    }
}
