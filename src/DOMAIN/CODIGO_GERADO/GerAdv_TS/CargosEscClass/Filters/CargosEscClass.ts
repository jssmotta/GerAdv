export interface FilterCargosEscClass
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterCargosEscClassDefaults implements FilterCargosEscClass {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    