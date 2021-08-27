using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal.Interface
{
    public interface IAgendamentoDal
    {
        List<AgendamentoInfo> GetAllScheduling();
        AgendamentoInfo GetBySchedulingId(string id);
        Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditSchedulingAsync(string id, AgendamentoInfo scheduling);
        Task<string> DeleteScheduling(string id);
    }
}
