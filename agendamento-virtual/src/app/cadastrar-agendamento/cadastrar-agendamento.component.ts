import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    private router: Router) {
      this.agendamento = {} as Agendamento;
     }

  ngOnInit(): void {
  }

  cadastrar(): void {
      this.agendamentoServices.postAgendamento(this.agendamento).subscribe(x=>{
        this.agendamento = x;
      });
      this.router.navigate(["/agendamento"]);    
  }

}
