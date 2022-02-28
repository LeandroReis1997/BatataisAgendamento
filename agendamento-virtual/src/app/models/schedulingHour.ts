import { SchedulingDay } from "./schedulingDay";

export interface SchedulingHour {
    id: number;
    horario: string;
    idDay: number;
    schedulingDay : SchedulingDay[];
}