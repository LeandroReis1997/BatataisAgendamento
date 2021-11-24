using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using BatataisAgendamento.Web.Info.Data.Configuration.Interface;
using BatataisAgendamento.Web.Info.SqlDbContext;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal
{
    public class AgendamentoDal : IAgendamentoDal
    {
        private readonly SqlDbContext _agendamento;
        public AgendamentoDal(SqlDbContext sqlDbContext)
        {
            _agendamento = sqlDbContext;
        }

        public async Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling)
        {
            await _agendamento.AddAsync(scheduling);
            await _agendamento.SaveChangesAsync();

            return scheduling;
        }

        public async Task DeleteSchedulingAsync(int id)
        {
            var entity = _agendamento.Agendamento.FirstOrDefault(x => x.Id.Equals(id));
            _agendamento.Remove(entity);
            await _agendamento.SaveChangesAsync();
        }

        public async Task<AgendamentoInfo> EditSchedulingAsync(int id, AgendamentoInfo scheduling)
        {
            _agendamento.Update(scheduling);
            await _agendamento.SaveChangesAsync();
            return scheduling;
        }

        public List<AgendamentoInfo> GetAllSchedulingAsync() =>
            _agendamento.Agendamento.ToList();


        public AgendamentoInfo GetBySchedulingIdAsync(int id) =>
            _agendamento.Agendamento.FirstOrDefault(x => x.Id.Equals(id));
    }
}
