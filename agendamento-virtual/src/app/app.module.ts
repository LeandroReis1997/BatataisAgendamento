import { HttpClientModule } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListAgendamentoComponent } from './list-agendamento/list-schedulingDay.component';
import { CadastrarAgendamentoComponent } from './cadastrar-agendamento/cadastrar-schedulingDay.component';
import { FormsModule } from '@angular/forms';
import { DatePipe, registerLocaleData } from '@angular/common';
import localePT from '@angular/common/locales/pt';
registerLocaleData(localePT);

@NgModule({
  declarations: [
    AppComponent,
    ListAgendamentoComponent,
    CadastrarAgendamentoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'pt-br' }, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
