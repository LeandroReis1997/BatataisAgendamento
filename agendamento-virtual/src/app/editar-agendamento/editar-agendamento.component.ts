import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agendamento } from '../models/Agendamento';
import { AgendamentoService } from '../services/agendamento.service';

@Component({
  selector: 'app-editar-agendamento',
  templateUrl: './editar-agendamento.component.html',
  styleUrls: ['./editar-agendamento.component.css']
})
export class EditarAgendamentoComponent implements OnInit {

  agendamento: Agendamento;

  constructor(private agendamentoServices: AgendamentoService,
    private route: ActivatedRoute,
    private router: Router,
    public datePipe: DatePipe) {
    this.agendamento = {} as Agendamento;
  }

  ngOnInit(): void {
    const idAgendamento = this.route.snapshot.params['id'];
    this.agendamento.id = idAgendamento;
    this.agendamentoServices.getAgendamentoId(this.agendamento).subscribe((agenda: any) => {
      var dateFormat = this.datePipe.transform(agenda.dia, 'yyyy-MM-dd'); // yyyy-MM-ddTHH:mm
      agenda.dia = dateFormat;
      this.agendamento = agenda;
      console.log(this.agendamento)
    })
  }

  atualizar() {

  }

}


