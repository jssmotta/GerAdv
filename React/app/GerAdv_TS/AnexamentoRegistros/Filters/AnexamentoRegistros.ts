export interface FilterAnexamentoRegistros
{
    operator?: string;
    cliente?: number;
 guidreg?: string;
    codigoreg?: number;
    idreg?: number;
 data?: string;
 guid?: string;
}

export class FilterAnexamentoRegistrosDefaults implements FilterAnexamentoRegistros {
    operator?: string = ' AND ';
    cliente?: number = -2147483648;
    guidreg?: string = '';
    codigoreg?: number = -2147483648;
    idreg?: number = -2147483648;
    data?: string = '';
    guid?: string = '';
}
    