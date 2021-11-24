using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nest;
using System;

namespace BatataisAgendamento.Web.Info
{
    public class AgendamentoInfo
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public string Horario { get; set; }
    }
}
