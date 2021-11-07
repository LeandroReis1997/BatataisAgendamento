import { DatePipe } from '@angular/common';
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

  constructor(private agendamentoService: AgendamentoService,
    public datePipe: DatePipe) {
  }

  ngOnInit(): void {
    this.listar();
  }

  listar() {
    this.agendamentoService.getAgendamento().subscribe((agendamento: Agendamento[]) => {
      this.agendamento = agendamento;
    });
  }

  delete(agendamento: Agendamento): void {
    if (agendamento.id != null) {
      if (confirm(`Deseja remover o agendamento do dia ${this.datePipe.transform(agendamento.dia, 'dd/MM/yyyy')}?`)) {
        this.agendamentoService.deleteAgendamento(agendamento).subscribe(() => {
         return this.listar();
        });
      }
    }
  }
}
