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

        public void DeleteSchedulingAsync(string id)
        {
            _dal.DeleteSchedulingAsync(id);
        }

        public async Task<AgendamentoInfo> EditSchedulingAsync(string id, AgendamentoInfo scheduling)
        {
            return await _dal.EditSchedulingAsync(id, new AgendamentoInfo
            {
                Id = id,
                Dia = scheduling.Dia,
                Horario = scheduling.Horario
            });
        }

        public async Task<List<AgendamentoInfo>> GetAllSchedulingAsync()
        {
            return await _dal.GetAllSchedulingAsync();
        }

        public async Task<AgendamentoInfo> GetBySchedulingAsync(string id)
        {
            return await _dal.GetBySchedulingIdAsync(id);
        }
    }
}
