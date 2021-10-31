import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgendamentoRoutes } from './agendamento-routing.module';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/agendamento/listar',
    pathMatch: 'full'
  },
  ...AgendamentoRoutes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
