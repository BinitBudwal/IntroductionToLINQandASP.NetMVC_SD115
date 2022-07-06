using Microsoft.AspNetCore.Mvc;
using IntroductionToLINQandASP.NetMVC_SD115.Models;

namespace IntroductionToLINQandASP.NetMVC_SD115.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllRooms()
        {
            List<Room> allRooms = Hotel.Rooms.ToList();
            return View(allRooms);
        }
    }
}
