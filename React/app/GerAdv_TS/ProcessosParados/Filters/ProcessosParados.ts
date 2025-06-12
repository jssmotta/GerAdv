export interface FilterProcessosParados
{
    operator?: string;
    processo?: number;
    semana?: number;
    ano?: number;
 datahora?: string;
    operador?: number;
 datahistorico?: string;
 datanenotas?: string;
}

export class FilterProcessosParadosDefaults implements FilterProcessosParados {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    semana?: number = -2147483648;
    ano?: number = -2147483648;
    datahora?: string = '';
    operador?: number = -2147483648;
    datahistorico?: string = '';
    datanenotas?: string = '';
}
    