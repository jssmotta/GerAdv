export interface FilterPenhoraStatus
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterPenhoraStatusDefaults implements FilterPenhoraStatus {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    