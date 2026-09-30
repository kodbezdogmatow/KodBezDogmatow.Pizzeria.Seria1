using Schikeria.Interfaces.Common;
using Schikeria.Model.Services.Duplications;

namespace Schikeria.Interfaces.Services.Duplications
{
    public interface IDuplicationService
    {
        List<Duplication> Get(List<IUniqueKey> items);
    }
}