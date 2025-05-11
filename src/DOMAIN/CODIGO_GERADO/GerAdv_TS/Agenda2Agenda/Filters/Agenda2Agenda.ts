export interface FilterAgenda2Agenda
{
    operator?: string;
    master?: number;
    agenda?: number;
}

export class FilterAgenda2AgendaDefaults implements FilterAgenda2Agenda {
    operator?: string = " AND ";
    master?: number = -2147483648;
    agenda?: number = -2147483648;
}
    