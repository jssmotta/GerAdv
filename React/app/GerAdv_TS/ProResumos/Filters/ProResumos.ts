export interface FilterProResumos
{
    operator?: string;
    processo?: number;
 data?: string;
 resumo?: string;
    tiporesumo?: number;
 guid?: string;
}

export class FilterProResumosDefaults implements FilterProResumos {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    data?: string = '';
    resumo?: string = '';
    tiporesumo?: number = -2147483648;
    guid?: string = '';
}
    