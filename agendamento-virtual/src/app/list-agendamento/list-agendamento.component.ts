import { Component, OnInit } from '@angular/core';
import { Agendamento } from '../models/Agendamento';
import { AgendamentoService } from '../services/agendamento.service';

@Component({
  selector: 'list-agendamento',
  templateUrl: './list-agendamento.component.html',
  styleUrls: ['./list-agendamento.component.css']
})
export class ListAgendamentoComponent implements OnInit {

  agendamento: Agendamento[] = [];

  constructor(private agendamentoService: AgendamentoService) { }

  ngOnInit(): void {
    this.agendamentoService.getAgendamento().subscribe(x =>{
      this.agendamento = x;
      console.log(this.agendamento);
    }, erro =>{
      console.log(erro);
    })
  }

}