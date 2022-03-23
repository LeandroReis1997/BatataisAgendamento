import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SchedulingDay } from '../models/schedulingDay';
import { SchedulingHour } from '../models/schedulingHour';
import { SchedulingDayService } from '../services/schedulingDay.service';
import { SchedulingHourService } from '../services/schedulingHour.service';


@Component({
  selector: 'app-post-schedulingDay',
  templateUrl: './post-schedulingDay.component.html',
  styleUrls: ['./post-schedulingDay.component.css']
})
export class PostSchedulingDayComponent implements OnInit {

  schedulingDay: SchedulingDay;

  constructor(private schedulingDayServices: SchedulingDayService,
    private schedulingHourServices: SchedulingHourService,
    private route: ActivatedRoute,
    private router: Router,
    public datePipe: DatePipe) {
    this.schedulingDay = {} as SchedulingDay;

    this.schedulingDay.schedulingHour = [
      {
        id: 0,
        hour: '',
        idDay: 0
      }
    ];
  }


  ngOnInit(): void {
    const idAgendamento = this.route.snapshot.params['id'];
    // console.log(this.schedulingDay)
    if (idAgendamento != null && idAgendamento != undefined) {
      this.schedulingDay.id = idAgendamento;
      this.schedulingDayServices.getSchedulingDayId(this.schedulingDay).subscribe((agenda: any) => {
        var dateFormat = this.datePipe.transform(agenda.date, 'yyyy-MM-dd'); // yyyy-MM-ddTHH:mm
        agenda.date = dateFormat;
        this.schedulingDay = agenda;
        console.log(this.schedulingDay)
      });
    }
  }

  enviar(id: number): void {
    debugger
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
    console.log(this.schedulingDay)
  }
teste(){
  this.schedulingDay.schedulingHour.push({id: 0, hour:'', idDay:0});
}

teste1(){
 let a = this.schedulingDay.schedulingHour;

}


}
