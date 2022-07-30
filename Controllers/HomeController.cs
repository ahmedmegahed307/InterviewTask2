using AFS_.NET_Developer_Test.InfraStructure;
using AFS_.NET_Developer_Test.Models;
using AFS_.NET_Developer_Test.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AFS_.NET_Developer_Test.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILeetSpeak _leetSpeak;
        public HomeController(ILeetSpeak leetSpeak)
        {
            _leetSpeak = leetSpeak;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCalls()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

        _leetSpeak.DeleteContent(id);
            return View("GetCalls");
        }

    }
}
