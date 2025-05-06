export interface FilterGUTTipo
{
    operator?: string;
 nome?: string;
    ordem?: number;
 guid?: string;
}

export class FilterGUTTipoDefaults implements FilterGUTTipo {
    operator?: string = " AND ";
    nome?: string = '';
    ordem?: number = -2147483648;
    guid?: string = '';
}
    