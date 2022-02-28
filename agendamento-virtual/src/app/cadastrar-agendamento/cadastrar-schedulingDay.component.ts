import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SchedulingDay } from '../models/schedulingDay';
import { SchedulingDayService } from '../services/schedulingDay.service';

@Component({
  selector: 'app-cadastrar-agendamento',
  templateUrl: './cadastrar-schedulingDay.component.html',
  styleUrls: ['./cadastrar-schedulingDay.component.css']
})
export class CadastrarSchedulingDayComponent implements OnInit {

  schedulingDay: SchedulingDay;

  constructor(private schedulingDayServices: SchedulingDayService,
    private route: ActivatedRoute,
    private router: Router,
    public datePipe: DatePipe) {
    this.schedulingDay = {} as SchedulingDay;
  }

  ngOnInit(): void {
    const idAgendamento = this.route.snapshot.params['id'];
    if (idAgendamento != null && idAgendamento != undefined) {
      this.schedulingDay.id = idAgendamento;
      this.schedulingDayServices.getSchedulingDayId(this.schedulingDay).subscribe((agenda: any) => {
        var dateFormat = this.datePipe.transform(agenda.dia, 'yyyy-MM-dd'); // yyyy-MM-ddTHH:mm
        agenda.dia = dateFormat;
        this.schedulingDay = agenda;
      });
    }
  }

  enviar(id: number): void {
    if (id == null && id == undefined) {
      this.schedulingDayServices.postSchedulingDay(this.schedulingDay).subscribe(schedulingDayPost => {
        this.schedulingDay = schedulingDayPost;
        this.router.navigate(["/schedulingDay"]);
      });
    }
    else {
      this.schedulingDayServices.putSchedulingDay(this.schedulingDay).subscribe(schedulingDayPut => {
        this.schedulingDay = schedulingDayPut;
        this.router.navigate(["/schedulingDay"]);
      });
    }
  }
}
