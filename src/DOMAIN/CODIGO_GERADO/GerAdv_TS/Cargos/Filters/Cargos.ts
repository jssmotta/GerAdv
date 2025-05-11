export interface FilterCargos
{
    operator?: string;
 nome?: string;
}

export class FilterCargosDefaults implements FilterCargos {
    operator?: string = " AND ";
    nome?: string = '';
}
    