using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info;
using BatataisAgendamento.Web.Info.Data.Configuration.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatataisAgendamento.Web.Dal
{
    public class AgendamentoDal : IAgendamentoDal
    {
        private readonly IMongoCollection<AgendamentoInfo> _agendamento;
        public AgendamentoDal(IProductStoreDatabaseSettings configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);
            var database = client.GetDatabase(configuration.DatabaseName);
            _agendamento = database.GetCollection<AgendamentoInfo>(configuration.ProductCollectionName);
        }

        public async Task<AgendamentoInfo> AddSchedulingAsync(AgendamentoInfo scheduling)
        {
            await _agendamento.InsertOneAsync(scheduling);
            return scheduling;
        }

        public void DeleteSchedulingAsync(string id)
        {
            _agendamento.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<AgendamentoInfo> EditSchedulingAsync(string id, AgendamentoInfo scheduling)
        {
            await _agendamento.ReplaceOneAsync(x => x.Id == id, scheduling);
            return scheduling;
        }

        public async Task<List<AgendamentoInfo>> GetAllSchedulingAsync() =>
            await _agendamento.FindAsync(x => true).Result.ToListAsync();


        public async Task<AgendamentoInfo> GetBySchedulingIdAsync(string id) =>
           await _agendamento.FindAsync(x => x.Id.Equals(id)).Result.FirstOrDefaultAsync();
    }
}
