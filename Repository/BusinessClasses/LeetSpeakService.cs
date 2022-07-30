using AFS_.NET_Developer_Test.InfraStructure;
using AFS_.NET_Developer_Test.Models;
using AFS_.NET_Developer_Test.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AFS_.NET_Developer_Test.Repository.BusinessClasses
{
    public class LeetSpeakService : RepoService<LeetSpeakTranslator>, ILeetSpeak
    {
        private readonly HttpClient _client;
        private readonly ProjectContext _context;
        Uri baseAddress = new Uri("https://api.funtranslations.com/translate/leetspeak.json?text=");

        public LeetSpeakService(ProjectContext context) : base(context)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }


        public async Task<LeetSpeakTranslator> Create(LeetSpeakTranslator leetSpeakTranslator)
        {
            string data = JsonConvert.SerializeObject(leetSpeakTranslator);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + leetSpeakTranslator.contents.text, content).Result;

            if ((response.IsSuccessStatusCode))
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                var convert = JsonConvert.DeserializeObject<LeetSpeakTranslator>(jsonstring);
                var contents = new Contents();// table that saves text and its translation.
                contents.translated = convert.contents.translated;
                contents.text = convert.contents.text;
                _context.Contents.Add(contents);
                _context.SaveChanges();
            }

            return leetSpeakTranslator;

        }

        

        public Contents GetContent(Expression<Func<Contents, bool>> filter)
        {
            return _context.Set<Contents>().FirstOrDefault(filter);
        }



        public void DeleteContent(int id)
        {
            var deleteContent = GetContent(a=>a.Id==id);
            deleteContent.IsActive = false;
           _context.Update(deleteContent);
            _context.SaveChanges();
        }

        
    }
}
