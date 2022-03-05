import { Routes } from "@angular/router";
import { PostSchedulingDayComponent } from "./cadastrar-agendamento/post-schedulingDay.component";
import { ListSchedulingHourComponent } from "./hour/listar-horario/list-scheduling-hour.component";
import { ListSchedulingDayComponent } from "./listar-agendamento/list-schedulingDay.component";


export const SchedulingRoutes: Routes = [
    {
        path: 'schedulingDay',
        redirectTo: 'schedulingDay/listar'
    },
    {
        path: 'schedulingDay/listar',
        component: ListSchedulingDayComponent
    },
    {
        path: 'schedulingDay/cadastrar',
        component: PostSchedulingDayComponent
    },
    {
        path: 'schedulingDay/cadastrar/:id',
        component: PostSchedulingDayComponent
    },
    {
        path: 'schedulingHour',
        component: ListSchedulingHourComponent
    },
];