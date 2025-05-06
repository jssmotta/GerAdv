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
 guidexo?: string;
    agenda?: number;
    recado?: number;
    emocao?: number;
 guid?: string;
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
    guidexo?: string = '';
    agenda?: number = -2147483648;
    recado?: number = -2147483648;
    emocao?: number = -2147483648;
    guid?: string = '';
}
    