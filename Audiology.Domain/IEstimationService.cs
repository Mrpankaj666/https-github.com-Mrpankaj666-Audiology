using System.IO;
using System.Threading.Tasks;

namespace Audiology.Domain
{
    public interface IEstimationService
    {
        MemoryStream PrintToTextFile(float value);
        Task PrintToPaper(float value);
    }
}
