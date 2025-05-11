export interface FilterAgendaStatus
{
    operator?: string;
    agenda?: number;
    completed?: number;
}

export class FilterAgendaStatusDefaults implements FilterAgendaStatus {
    operator?: string = " AND ";
    agenda?: number = -2147483648;
    completed?: number = -2147483648;
}
    