namespace BatataisAgendamento.Web.Info.Data.Configuration.Interface
{
    public interface IProductStoreDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
