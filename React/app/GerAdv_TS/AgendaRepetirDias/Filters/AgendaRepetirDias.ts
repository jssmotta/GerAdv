export interface FilterAgendaRepetirDias
{
    operator?: string;
 horafinal?: string;
    master?: number;
    dia?: number;
 hora?: string;
}

export class FilterAgendaRepetirDiasDefaults implements FilterAgendaRepetirDias {
    operator?: string = ' AND ';
    horafinal?: string = '';
    master?: number = -2147483648;
    dia?: number = -2147483648;
    hora?: string = '';
}
    