import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SchedulingHour } from '../models/schedulingHour';

@Injectable({
  providedIn: 'root'
})
export class SchedulingHourService {

  private _baseUrl: string = "webapi/schedulinghour"

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getSchedulingHour(): Observable<SchedulingHour[]> {
    return this.http.get<SchedulingHour[]>(`${this._baseUrl}`);
  }

  getSchedulingHourId(schedulingHour: SchedulingHour): Observable<SchedulingHour> {
    return this.http.get<SchedulingHour>(`${this._baseUrl}/getbyschedulinghourid/${schedulingHour.id}`);
  }

  postSchedulingHour(schedulingHour: SchedulingHour): Observable<SchedulingHour> {
    return this.http.post<SchedulingHour>(this._baseUrl + "/create", JSON.stringify(schedulingHour), this.httpOptions);
  }

  putSchedulingHour(schedulingHour: SchedulingHour): Observable<SchedulingHour> {
    return this.http.put<SchedulingHour>(this._baseUrl + `/update/${schedulingHour.id}`, JSON.stringify(schedulingHour), this.httpOptions);
  }

  deleteSchedulingHour(schedulingHour: SchedulingHour): Observable<SchedulingHour> {
    return this.http.delete<SchedulingHour>(this._baseUrl + `/${schedulingHour.id}`, this.httpOptions);
  }

  
}
