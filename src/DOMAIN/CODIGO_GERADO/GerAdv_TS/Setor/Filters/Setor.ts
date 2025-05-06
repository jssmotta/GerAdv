export interface FilterSetor
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterSetorDefaults implements FilterSetor {
    operator?: string = " AND ";
    descricao?: string = '';
    guid?: string = '';
}
    