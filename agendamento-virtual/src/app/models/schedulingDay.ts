import { SchedulingHour } from "./schedulingHour";

export interface SchedulingDay {
     id: number;
     date: Date;
     schedulingHour: SchedulingHour[];
}