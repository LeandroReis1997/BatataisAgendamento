import { HttpClientModule } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListSchedulingDayComponent } from './listar-agendamento/list-schedulingDay.component';
import { FormsModule } from '@angular/forms';
import { DatePipe, registerLocaleData } from '@angular/common';
import localePT from '@angular/common/locales/pt';
import { PostSchedulingDayComponent } from './cadastrar-agendamento/post-schedulingDay.component';
import { ListSchedulingHourComponent } from './hour/listar-horario/list-scheduling-hour.component';
import { PostSchedulingHourComponent } from './hour/cadastrar-horario/post-scheduling-hour.component';
import { SidebarComponent } from './sidebar/sidebar.component';
registerLocaleData(localePT);

@NgModule({
  declarations: [
    AppComponent,
    ListSchedulingDayComponent,
    PostSchedulingDayComponent,
    ListSchedulingHourComponent,
    PostSchedulingHourComponent,
    SidebarComponent
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
