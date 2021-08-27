using Microsoft.EntityFrameworkCore;

namespace BatataisAgendamento.Web.Info.SqlDbContext
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options) { }

        public DbSet<AgendamentoInfo> Agendamento { get; set; }
    }
}
