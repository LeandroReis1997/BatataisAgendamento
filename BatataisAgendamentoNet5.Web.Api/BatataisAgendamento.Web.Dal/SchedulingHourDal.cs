using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using BatataisAgendamento.Web.Info.SqlDbContext;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal
{
    public class SchedulingHourDal : ISchedulingHourDal
    {
        private readonly SqlDbContext _agendamentoHour;
        public SchedulingHourDal(SqlDbContext sqlDbContext)
        {
            _agendamentoHour = sqlDbContext;
        }

        public async Task<SchedulingHourInfo> AddSchedulingHourAsync(SchedulingHourInfo schedulingHour)
        {
            await _agendamentoHour.AddAsync(schedulingHour);
            await _agendamentoHour.SaveChangesAsync();

            return schedulingHour;
        }

        public async Task DeleteSchedulingHourAsync(int id)
        {
            var entity = _agendamentoHour.SchedulingHour.FirstOrDefault(x => x.Id.Equals(id));
            _agendamentoHour.Remove(entity);
            await _agendamentoHour.SaveChangesAsync();
        }

        public async Task<SchedulingHourInfo> EditSchedulingHourAsync(int id, SchedulingHourInfo schedulingHour)
        {
            _agendamentoHour.Update(schedulingHour);
            await _agendamentoHour.SaveChangesAsync();
            return schedulingHour;
        }

        public List<SchedulingHourInfo> GetAllSchedulingHourAsync() =>
            _agendamentoHour.SchedulingHour.ToList();


        public SchedulingHourInfo GetBySchedulingHourIdAsync(int id) =>
            _agendamentoHour.SchedulingHour.FirstOrDefault(x => x.Id.Equals(id));
    }
}
