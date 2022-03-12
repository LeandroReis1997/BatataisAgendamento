﻿using AutoMapper.Configuration.Annotations;
using BatataisAgendamento.Web.Api.DTO.SchedulingDayDTO;

namespace BatataisAgendamento.Web.Api.DTO.SchedulingHourDTO
{
    public class SchedulingHourCreateDTO
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public int IdDay { get; set; }
    }
}
