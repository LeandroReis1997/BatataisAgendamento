using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll.Interface
{
    public interface IAgendamentoBll
    {
        List<AgendamentoInfo> GetAllSchedulingAsync();
        AgendamentoInfo GetBySchedulingAsync(int id);
        Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditSchedulingAsync(int id, AgendamentoInfo scheduling);
        Task DeleteSchedulingAsync(int id);
    }
}
