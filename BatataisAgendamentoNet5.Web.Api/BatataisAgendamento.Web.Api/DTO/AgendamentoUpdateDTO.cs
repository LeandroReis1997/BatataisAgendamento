using Nest;
using System;

namespace BatataisAgendamento.Web.Api.DTO
{
    public class AgendamentoUpdateDTO
    {
        public string Id { get; set; }
        public DateTime Dia { get; set; }
        public string Horario { get; set; }

    }
}
