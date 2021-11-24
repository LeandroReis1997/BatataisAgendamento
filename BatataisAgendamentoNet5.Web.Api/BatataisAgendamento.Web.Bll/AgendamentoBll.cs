using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using System;
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

        public async Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling)
        {
            return await _dal.AddSchedulingAsync(scheduling);
            //return await _dal.AddSchedulingAsync(new AgendamentoInfo
            //{
            //    Id = scheduling.Id,
            //    Dia = DateTime.Now.Date,
            //    Horario = DateTime.Now.ToString("HH:mm")
            //});
        }

        public async Task DeleteSchedulingAsync(int id)
        {
            await _dal.DeleteSchedulingAsync(id);
        }

        public async Task<AgendamentoInfo> EditSchedulingAsync(int id, AgendamentoInfo scheduling)
        {
            return await _dal.EditSchedulingAsync(id, new AgendamentoInfo
            {
                Id = id,
                Dia = scheduling.Dia,
                Horario = scheduling.Horario
            });
        }

        public List<AgendamentoInfo> GetAllSchedulingAsync()
        {
            return _dal.GetAllSchedulingAsync();
        }

        public AgendamentoInfo GetBySchedulingAsync(int id)
        {
            return _dal.GetBySchedulingIdAsync(id);
        }
    }
}
