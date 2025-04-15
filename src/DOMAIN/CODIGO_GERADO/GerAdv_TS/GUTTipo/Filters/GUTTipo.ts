export interface FilterGUTTipo
{
    operator?: string;
 nome?: string;
    ordem?: number;
}

export class FilterGUTTipoDefaults implements FilterGUTTipo {
    operator?: string = " AND ";
    nome?: string = '';
    ordem?: number = -2147483648;
}
    