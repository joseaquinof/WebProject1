using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject1.Models;
using Newtonsoft.Json;

namespace WebProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //List<Root> members = new List<Root>();
            Root members = null;

            //for (int i = 0; i < 10; i++)
            //{
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("https://randomuser.me/api/?results=100");

                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        members = JsonConvert.DeserializeObject<Root>(content);
                        //members.Add(member);
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        members = null;

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            //}
            return View(members);
        }

        public ActionResult Detail(SelectedMemberModel member)
        {
            //Root selectedMember = members.Where(p=>p.info.seed == id).Single();
            return View(member);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}