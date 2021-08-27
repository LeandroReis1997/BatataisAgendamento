using Nest;
using System;

namespace BatataisAgendamento.Web.Api.DTO
{
    public class AgendamentoDTO
    {
        public DateTime Dia { get; set; }
        public string Horario { get; set; }

    }
}
