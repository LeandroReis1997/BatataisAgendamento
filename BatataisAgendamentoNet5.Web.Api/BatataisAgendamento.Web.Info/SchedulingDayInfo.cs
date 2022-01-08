using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nest;
using System;

namespace BatataisAgendamento.Web.Info
{
    public class SchedulingDayInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
