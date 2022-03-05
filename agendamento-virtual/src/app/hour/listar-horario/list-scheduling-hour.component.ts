import { Component, OnInit } from '@angular/core';
import { SchedulingHour } from 'src/app/models/schedulingHour';
import { SchedulingHourService } from 'src/app/services/schedulingHour.service';

@Component({
  selector: 'app-list-scheduling-hour',
  templateUrl: './list-scheduling-hour.component.html',
  styleUrls: ['./list-scheduling-hour.component.css']
})
export class ListSchedulingHourComponent implements OnInit {

  schedulingHour: SchedulingHour[] = [];

  constructor(private schedulingHourService: SchedulingHourService) { }

  ngOnInit(): void {

    this.schedulingHourService.getSchedulingHour().subscribe(hour => {
      this.schedulingHour = hour
      console.log(this.schedulingHour)
    });

  }

}
