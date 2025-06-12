export interface FilterAgendaRepetir
{
    operator?: string;
    advogado?: number;
    cliente?: number;
 datafinal?: string;
    funcionario?: number;
 horafinal?: string;
    processo?: number;
    frequencia?: number;
    dia?: number;
    mes?: number;
 hora?: string;
    idquem?: number;
    idquem2?: number;
 mensagem?: string;
    idtipo?: number;
    id1?: number;
    id2?: number;
    id3?: number;
    id4?: number;
}

export class FilterAgendaRepetirDefaults implements FilterAgendaRepetir {
    operator?: string = ' AND ';
    advogado?: number = -2147483648;
    cliente?: number = -2147483648;
    datafinal?: string = '';
    funcionario?: number = -2147483648;
    horafinal?: string = '';
    processo?: number = -2147483648;
    frequencia?: number = -2147483648;
    dia?: number = -2147483648;
    mes?: number = -2147483648;
    hora?: string = '';
    idquem?: number = -2147483648;
    idquem2?: number = -2147483648;
    mensagem?: string = '';
    idtipo?: number = -2147483648;
    id1?: number = -2147483648;
    id2?: number = -2147483648;
    id3?: number = -2147483648;
    id4?: number = -2147483648;
}
    