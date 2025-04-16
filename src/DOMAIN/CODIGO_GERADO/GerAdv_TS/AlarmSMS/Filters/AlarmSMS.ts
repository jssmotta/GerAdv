export interface FilterAlarmSMS
{
    operator?: string;
 descricao?: string;
    hora?: number;
    minuto?: number;
 email?: string;
 today?: string;
 alertardatahora?: string;
    operador?: number;
    agenda?: number;
    recado?: number;
    emocao?: number;
}

export class FilterAlarmSMSDefaults implements FilterAlarmSMS {
    operator?: string = " AND ";
    descricao?: string = '';
    hora?: number = -2147483648;
    minuto?: number = -2147483648;
    email?: string = '';
    today?: string = '';
    alertardatahora?: string = '';
    operador?: number = -2147483648;
    agenda?: number = -2147483648;
    recado?: number = -2147483648;
    emocao?: number = -2147483648;
}
    