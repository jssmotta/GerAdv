export interface FilterAnexamentoRegistros
{
    operator?: string;
    cliente?: number;
    codigoreg?: number;
    idreg?: number;
 data?: string;
}

export class FilterAnexamentoRegistrosDefaults implements FilterAnexamentoRegistros {
    operator?: string = " AND ";
    cliente?: number = -2147483648;
    codigoreg?: number = -2147483648;
    idreg?: number = -2147483648;
    data?: string = '';
}
    