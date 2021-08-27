using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using BatataisAgendamento.Web.Info.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal
{
    public class AgendamentoDal : IAgendamentoDal
    {
        private SqlDbContext _sqlDbContext;
        public AgendamentoDal(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling)
        {
            try
            {
                await _sqlDbContext.AddAsync(scheduling);
                await _sqlDbContext.SaveChangesAsync();
                return scheduling;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteScheduling(int id)
        {
            var entity = _sqlDbContext.Agendamento.FirstOrDefault(x => x.Id.Equals(id));
            _sqlDbContext.Remove(entity);
            _sqlDbContext.SaveChanges();

            return await Task.FromResult(id);
        }

        public async Task<AgendamentoInfo> EditSchedulingAsync(int id, AgendamentoInfo scheduling)
        {
            _sqlDbContext.Agendamento.Update(scheduling);
            await _sqlDbContext.SaveChangesAsync();
            return scheduling;
        }

        public List<AgendamentoInfo> GetAllScheduling() =>
            _sqlDbContext.Agendamento.ToList();

        public AgendamentoInfo GetBySchedulingId(int id) =>
            _sqlDbContext.Agendamento.FirstOrDefault(x => x.Id.Equals(id));
    }
}
