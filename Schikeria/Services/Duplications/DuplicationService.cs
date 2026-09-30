using Schikeria.Interfaces.Common;
using Schikeria.Interfaces.Services.Duplications;
using Schikeria.Model.Services.Duplications;

namespace Schikeria.Services.Duplications
{
    public class DuplicationService :
        IDuplicationService
    {
        public List<Duplication> Get(
            List<IUniqueKey> items)
        {
            return items
                .GroupBy(i => i.GetUniqueKey())
                .Where(g => g.Count() > 1)
                .Select(g => new Duplication
                {
                    Key = g.Key,
                    Count = g.Count()
                })
                .ToList();
        }
    }
}
