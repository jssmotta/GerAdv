export interface FilterAlertas
{
    operator?: string;
 nome?: string;
 data?: string;
    operador?: number;
 dataate?: string;
}

export class FilterAlertasDefaults implements FilterAlertas {
    operator?: string = ' AND ';
    nome?: string = '';
    data?: string = '';
    operador?: number = -2147483648;
    dataate?: string = '';
}
    