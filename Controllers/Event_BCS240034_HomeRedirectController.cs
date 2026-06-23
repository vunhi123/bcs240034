using Microsoft.AspNetCore.Mvc;

namespace MID_BCS240034.Controllers
{
    // Catch requests to /Event_BCS240034/Home (or HOME) and redirect to Index
    public class Event_BCS240034_HomeRedirectController : Controller
    {
        [HttpGet("/Event_BCS240034/Home")]
        [HttpGet("/Event_BCS240034/HOME")]
        public IActionResult HomeRedirect()
        {
            return RedirectToAction("Index", "Event_BCS240034");
        }
    }
}
