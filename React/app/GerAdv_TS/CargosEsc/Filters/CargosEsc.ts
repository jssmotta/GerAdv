export interface FilterCargosEsc
{
    operator?: string;
    percentual?: number;
 nome?: string;
    classificacao?: number;
 guid?: string;
}

export class FilterCargosEscDefaults implements FilterCargosEsc {
    operator?: string = ' AND ';
    percentual?: number = -2147483648;
    nome?: string = '';
    classificacao?: number = -2147483648;
    guid?: string = '';
}
    