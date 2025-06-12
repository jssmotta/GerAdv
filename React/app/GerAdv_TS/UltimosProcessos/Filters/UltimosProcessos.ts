export interface FilterUltimosProcessos
{
    operator?: string;
    processo?: number;
 quando?: string;
    quem?: number;
}

export class FilterUltimosProcessosDefaults implements FilterUltimosProcessos {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    quando?: string = '';
    quem?: number = -2147483648;
}
    