import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SchedulingDay } from '../models/schedulingDay';

@Injectable({
  providedIn: 'root'
})
export class SchedulingDayService {

  private _baseUrl: string = "webapi/schedulingday"

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getSchedulingDay(): Observable<SchedulingDay[]> {
    return this.http.get<SchedulingDay[]>(`${this._baseUrl}`);
  }

  getSchedulingDayId(schedulingDay: SchedulingDay): Observable<SchedulingDay> {
    return this.http.get<SchedulingDay>(`${this._baseUrl}/getbyschedulingid/${schedulingDay.id}`);
  }

  postSchedulingDay(schedulingDay: SchedulingDay): Observable<SchedulingDay> {
    return this.http.post<SchedulingDay>(this._baseUrl + "/create", JSON.stringify(schedulingDay), this.httpOptions);
  }

  putSchedulingDay(schedulingDay: SchedulingDay): Observable<SchedulingDay> {
    return this.http.put<SchedulingDay>(this._baseUrl + `/update/${schedulingDay.id}`, JSON.stringify(schedulingDay), this.httpOptions);
  }

  deleteSchedulingDay(schedulingDay: SchedulingDay): Observable<SchedulingDay> {
    return this.http.delete<SchedulingDay>(this._baseUrl + `/${schedulingDay.id}`, this.httpOptions);
  }

}
