using LibreriaDemo1.Models;
using System.Threading.Tasks;

namespace LibreriaDemo1.Interfaces
{
    public interface IReqResService
    {
        Task<DatiEsterni> GetData();
        void Cancel();
        Task<string> Create(ReqResPost nuovoUtente);
    }
}
