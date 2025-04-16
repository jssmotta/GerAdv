export interface FilterAlertasEnviados
{
    operator?: string;
    operador?: number;
    alerta?: number;
 dataalertado?: string;
}

export class FilterAlertasEnviadosDefaults implements FilterAlertasEnviados {
    operator?: string = " AND ";
    operador?: number = -2147483648;
    alerta?: number = -2147483648;
    dataalertado?: string = '';
}
    