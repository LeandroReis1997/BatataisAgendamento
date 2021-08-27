using BatataisAgendamento.Web.Info.Data.Configuration.Interface;

namespace BatataisAgendamento.Web.Info.Data.Configuration
{
    public class ProductStoreDatabaseSettings : IProductStoreDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
