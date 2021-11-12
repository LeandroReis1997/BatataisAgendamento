using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal.Interface
{
    public interface IAgendamentoDal
    {
        Task<List<AgendamentoInfo>> GetAllSchedulingAsync();
        Task<AgendamentoInfo> GetBySchedulingIdAsync(string id);
        Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditSchedulingAsync(string id, AgendamentoInfo scheduling);
        void DeleteSchedulingAsync(string id);
    }
}
