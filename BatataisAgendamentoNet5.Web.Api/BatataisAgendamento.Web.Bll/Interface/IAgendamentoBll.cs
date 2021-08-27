using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll.Interface
{
    public interface IAgendamentoBll
    {
        List<AgendamentoInfo> GetAllScheduling();
        AgendamentoInfo GetByScheduling(string id);
        Task<AgendamentoInfo> AddScheduling(AgendamentoInfo scheduling);
        Task<AgendamentoInfo> EditScheduling(string id, AgendamentoInfo scheduling);
        Task<string> DeleteScheduling(string id);
    }
}
