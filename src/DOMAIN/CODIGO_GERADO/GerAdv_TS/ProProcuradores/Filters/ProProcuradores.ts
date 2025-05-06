export interface FilterProProcuradores
{
    operator?: string;
    advogado?: number;
 nome?: string;
    processo?: number;
 data?: string;
 guid?: string;
}

export class FilterProProcuradoresDefaults implements FilterProProcuradores {
    operator?: string = " AND ";
    advogado?: number = -2147483648;
    nome?: string = '';
    processo?: number = -2147483648;
    data?: string = '';
    guid?: string = '';
}
    