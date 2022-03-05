import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SchedulingRoutes } from './schedulingDay-routing.module';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/schedulingDay/listar',
    pathMatch: 'full'
  },
  ...SchedulingRoutes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
