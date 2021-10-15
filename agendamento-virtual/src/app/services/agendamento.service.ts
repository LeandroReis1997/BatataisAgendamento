import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Agendamento } from '../models/Agendamento';

@Injectable({
  providedIn: 'root'
})
export class AgendamentoService {

  private _baseUrl: string = "webapi"

  constructor(private http: HttpClient) { }

  getAgendamento(): Observable<Agendamento[]> {
    return this.http.get<Agendamento[]>(`${this._baseUrl}/agendamento`);
  }
}
