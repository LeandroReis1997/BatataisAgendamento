import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agendamento } from '../models/Agendamento';
import { AgendamentoService } from '../services/agendamento.service';

@Component({
  selector: 'app-cadastrar-agendamento',
  templateUrl: './cadastrar-agendamento.component.html',
  styleUrls: ['./cadastrar-agendamento.component.css']
})
export class CadastrarAgendamentoComponent implements OnInit {

  agendamento: Agendamento;

  constructor(private agendamentoServices: AgendamentoService,
    private route: ActivatedRoute,
    private router: Router,
    public datePipe: DatePipe) {
    this.agendamento = {} as Agendamento;
  }

  ngOnInit(): void {
    const idAgendamento = this.route.snapshot.params['id'];
    if (idAgendamento != null && idAgendamento != undefined) {
      this.agendamento.id = idAgendamento;
      this.agendamentoServices.getAgendamentoId(this.agendamento).subscribe((agenda: any) => {
        var dateFormat = this.datePipe.transform(agenda.dia, 'yyyy-MM-dd'); // yyyy-MM-ddTHH:mm
        agenda.dia = dateFormat;
        this.agendamento = agenda;
      });
    }
  }

  enviar(id: string): void {
    if (id == null && id == undefined) {
      this.agendamentoServices.postAgendamento(this.agendamento).subscribe(agendamentoPost => {
        this.agendamento = agendamentoPost;
        this.router.navigate(["/agendamento"]);
      });
    }
    else {
      this.agendamentoServices.putAgendamento(this.agendamento).subscribe(agendamentoPut => {
        this.agendamento = agendamentoPut;
        this.router.navigate(["/agendamento"]);
      });
    }
  }
}
