using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll.Interface
{
    public interface IAgendamentoBll
    {
        Task<List<AgendamentoInfo>> GetAllSchedulingAsync();
        Task<AgendamentoInfo> GetBySchedulingAsync(string id);
        Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditSchedulingAsync(string id, AgendamentoInfo scheduling);
        void DeleteSchedulingAsync(string id);
    }
}
