export interface FilterPenhoraStatus
{
    operator?: string;
 nome?: string;
}

export class FilterPenhoraStatusDefaults implements FilterPenhoraStatus {
    operator?: string = " AND ";
    nome?: string = '';
}
    