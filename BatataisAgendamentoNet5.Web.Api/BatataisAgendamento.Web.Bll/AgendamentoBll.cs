using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Bll
{
    public class AgendamentoBll : IAgendamentoBll
    {
        private IAgendamentoDal _dal;

        public AgendamentoBll(IAgendamentoDal agendamentoDal)
        {
            _dal = agendamentoDal;
        }

        public async Task<AgendamentoInfo> AddScheduling(AgendamentoInfo scheduling)
        {
            return await _dal.AddSchedulingAsync(scheduling);
        }

        public async Task<int> DeleteScheduling(int id)
        {
            return await _dal.DeleteScheduling(id);
        }

        public async Task<AgendamentoInfo> EditScheduling(int id, AgendamentoInfo scheduling)
        {
            return await _dal.EditSchedulingAsync(id, scheduling);
        }

        public List<AgendamentoInfo> GetAllScheduling()
        {
            return _dal.GetAllScheduling();
        }

        public AgendamentoInfo GetByScheduling(int id)
        {
            return _dal.GetBySchedulingId(id);
        }
    }
}
