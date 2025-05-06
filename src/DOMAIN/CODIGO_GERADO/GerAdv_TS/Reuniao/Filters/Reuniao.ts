export interface FilterReuniao
{
    operator?: string;
    cliente?: number;
    idagenda?: number;
 data?: string;
 pauta?: string;
 ata?: string;
 horainicial?: string;
 horafinal?: string;
 horasaida?: string;
 horaretorno?: string;
 principaisdecisoes?: string;
 guid?: string;
}

export class FilterReuniaoDefaults implements FilterReuniao {
    operator?: string = " AND ";
    cliente?: number = -2147483648;
    idagenda?: number = -2147483648;
    data?: string = '';
    pauta?: string = '';
    ata?: string = '';
    horainicial?: string = '';
    horafinal?: string = '';
    horasaida?: string = '';
    horaretorno?: string = '';
    principaisdecisoes?: string = '';
    guid?: string = '';
}
    