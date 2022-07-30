using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using AFS_.NET_Developer_Test.InfraStructure;
using AFS_.NET_Developer_Test.Models;
using AFS_.NET_Developer_Test.Repository.Interfaces;

namespace AFS_.NET_Developer_Test.Controllers
{
    
    public class TranslationController : Controller
    {
        //this is the main controller for all translators.
        //if we needed to use another translator later, we can inject it here and overload Create method.
        private readonly ILeetSpeak _leetspeak;
        public TranslationController(ILeetSpeak leetSpeak) 
        {
            _leetspeak = leetSpeak;
            
        }

        [HttpPost] 
        public IActionResult Create(LeetSpeakTranslator translate)
        {
            var data = _leetspeak.Create(translate);
            return RedirectToAction("GetCalls","Home");
        }
       

    }
}
