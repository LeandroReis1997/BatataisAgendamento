import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SchedulingDay } from '../models/schedulingDay';
import { SchedulingDayService } from '../services/schedulingDay.service';

@Component({
  selector: 'list-schedulingDay',
  templateUrl: './list-schedulingDay.component.html',
  styleUrls: ['./list-schedulingDay.component.css']
})
export class ListSchedulingDayComponent implements OnInit {

  schedulingDay: SchedulingDay[] = [];

  constructor(private schedulingDayService: SchedulingDayService,
    public datePipe: DatePipe) {
  }

  ngOnInit(): void {
    this.listar();
  }

  listar() {
    this.schedulingDayService.getSchedulingDay().subscribe((schedulingDay: SchedulingDay[]) => {
      console.log(schedulingDay)
      this.schedulingDay = schedulingDay;      
    });
  }

  delete(schedulingDay: SchedulingDay) {
    if (schedulingDay.id != null && schedulingDay.id != undefined) {
      if (confirm(`Deseja remover o agendamento do dia ${this.datePipe.transform(schedulingDay.date, 'dd/MM/yyyy')}?`)) {
        this.schedulingDayService.deleteSchedulingDay(schedulingDay).subscribe(() => {
          return this.listar();
        });
      }
    }
  }
}
