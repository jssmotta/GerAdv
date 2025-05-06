export interface FilterRito
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterRitoDefaults implements FilterRito {
    operator?: string = " AND ";
    descricao?: string = '';
    guid?: string = '';
}
    