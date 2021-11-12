import { Routes } from "@angular/router";
import { CadastrarAgendamentoComponent } from "./cadastrar-agendamento/cadastrar-agendamento.component";
import { EditarAgendamentoComponent } from "./editar-agendamento/editar-agendamento.component";
import { ListAgendamentoComponent } from "./list-agendamento/list-agendamento.component";


export const AgendamentoRoutes: Routes = [
    {
        path: 'agendamento',
        redirectTo: 'agendamento/listar'
    },
    {
        path: 'agendamento/listar',
        component: ListAgendamentoComponent
    },
    {
        path: 'agendamento/cadastrar',
        component: CadastrarAgendamentoComponent
    },
    {
        path: 'agendamento/cadastrar/:id',
        component: CadastrarAgendamentoComponent
    },
    {
        path: 'agendamento/editar/:id',
        component: EditarAgendamentoComponent
    }
];