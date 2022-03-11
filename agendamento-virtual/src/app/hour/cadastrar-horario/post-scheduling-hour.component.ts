import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'post-scheduling-hour',
  templateUrl: './post-scheduling-hour.component.html',
  styleUrls: ['./post-scheduling-hour.component.css']
})
export class PostSchedulingHourComponent implements OnInit {

  titleHour = 'Horários disponíveis';

  constructor() { }

  ngOnInit(): void {
  }

}
