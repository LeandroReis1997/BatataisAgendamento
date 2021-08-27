using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll.Interface
{
    public interface IAgendamentoBll
    {
        List<AgendamentoInfo> GetAllScheduling();
        AgendamentoInfo GetByScheduling(int id);
        Task<AgendamentoInfo> AddScheduling(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditScheduling(int id, AgendamentoInfo scheduling);
        Task<int> DeleteScheduling(int id);
    }
}
