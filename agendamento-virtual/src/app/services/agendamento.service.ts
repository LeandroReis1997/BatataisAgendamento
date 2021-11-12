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

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getAgendamento(): Observable<Agendamento[]> {
    return this.http.get<Agendamento[]>(`${this._baseUrl}`);
  }

  getAgendamentoId(agendamento: Agendamento): Observable<Agendamento> {
    return this.http.get<Agendamento>(`${this._baseUrl}/getbyschedulingid/${agendamento.id}`);
  }

  postAgendamento(agendamento: Agendamento): Observable<Agendamento> {
    return this.http.post<Agendamento>(this._baseUrl + "/create", JSON.stringify(agendamento), this.httpOptions);
  }

  putAgendamento(agendamento: Agendamento): Observable<Agendamento> {
    return this.http.put<Agendamento>(this._baseUrl + `/update/${agendamento.id}`, JSON.stringify(agendamento), this.httpOptions);
  }

  deleteAgendamento(agendamento: Agendamento): Observable<Agendamento> {
    return this.http.delete<Agendamento>(this._baseUrl + `/${agendamento.id}`, this.httpOptions);
  }

}
