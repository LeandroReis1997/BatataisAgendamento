using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal.Interface
{
    public interface IAgendamentoDal
    {
        List<AgendamentoInfo> GetAllScheduling();
        AgendamentoInfo GetBySchedulingId(int id);
        Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditSchedulingAsync(int id, AgendamentoInfo scheduling);
        Task<int> DeleteScheduling(int id);
    }
}
