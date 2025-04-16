export interface FilterRito
{
    operator?: string;
 descricao?: string;
}

export class FilterRitoDefaults implements FilterRito {
    operator?: string = " AND ";
    descricao?: string = '';
}
    