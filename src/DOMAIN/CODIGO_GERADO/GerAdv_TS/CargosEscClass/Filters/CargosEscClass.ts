export interface FilterCargosEscClass
{
    operator?: string;
 nome?: string;
}

export class FilterCargosEscClassDefaults implements FilterCargosEscClass {
    operator?: string = " AND ";
    nome?: string = '';
}
    