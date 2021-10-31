import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Agendamento } from '../models/Agendamento';

@Injectable({
  providedIn: 'root'
})
export class AgendamentoService {

  private _baseUrl: string = "webapi/agendamento"

  constructor(private http: HttpClient) { }

  get headers(): HttpHeaders {
    return new HttpHeaders().set("content-type", "application/json");
  }
  getAgendamento(): Observable<Agendamento[]> {
    return this.http.get<Agendamento[]>(`${this._baseUrl}`);
  }

  postAgendamento(agendamento: Agendamento): Observable<Agendamento> {
    return this.http.post<Agendamento>(this._baseUrl + "/create", JSON.stringify(agendamento), { headers: this.headers });
  }
}
