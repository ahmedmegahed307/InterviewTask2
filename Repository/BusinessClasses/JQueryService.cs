using AFS_.NET_Developer_Test.InfraStructure;
using AFS_.NET_Developer_Test.Models;
using AFS_.NET_Developer_Test.Repository.Interfaces;

namespace AFS_.NET_Developer_Test.Repository.BusinessClasses
{
    public class JQueryService : RepoService<Contents>, IJQuery
    {
        
        public JQueryService(ProjectContext context) : base(context)
        {
           
        }

    }
}
