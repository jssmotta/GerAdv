export interface FilterAgendaQuem
{
    operator?: string;
    idagenda?: number;
    advogado?: number;
    funcionario?: number;
    preposto?: number;
}

export class FilterAgendaQuemDefaults implements FilterAgendaQuem {
    operator?: string = ' AND ';
    idagenda?: number = -2147483648;
    advogado?: number = -2147483648;
    funcionario?: number = -2147483648;
    preposto?: number = -2147483648;
}
    