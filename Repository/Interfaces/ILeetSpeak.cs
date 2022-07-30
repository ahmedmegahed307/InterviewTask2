using AFS_.NET_Developer_Test.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AFS_.NET_Developer_Test.Repository.Interfaces
{
    public interface ILeetSpeak : IRepo<LeetSpeakTranslator>
    {
        Task<LeetSpeakTranslator> Create(LeetSpeakTranslator leetTranslator);
        Contents GetContent(Expression<Func<Contents, bool>> filter);
        void DeleteContent(int id);
        

    }
}
