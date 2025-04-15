export interface FilterSetor
{
    operator?: string;
 descricao?: string;
}

export class FilterSetorDefaults implements FilterSetor {
    operator?: string = " AND ";
    descricao?: string = '';
}
    