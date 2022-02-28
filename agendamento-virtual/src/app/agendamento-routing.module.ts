import { Routes } from "@angular/router";
import { CadastrarSchedulingDayComponent } from "./cadastrar-agendamento/cadastrar-schedulingDay.component";
import { ListSchedulingDayComponent } from "./list-agendamento/list-schedulingDay.component";


export const AgendamentoRoutes: Routes = [
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
        component: CadastrarSchedulingDayComponent
    },
    {
        path: 'schedulingDay/cadastrar/:id',
        component: CadastrarSchedulingDayComponent
    }
];