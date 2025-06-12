export interface FilterAgendaSemana
{
    operator?: string;
 paranome?: string;
 data?: string;
    funcionario?: number;
    advogado?: number;
 hora?: string;
    tipocompromisso?: number;
 compromisso?: string;
 horafinal?: string;
 nome?: string;
    cliente?: number;
 nomecliente?: string;
 tipo?: string;
}

export class FilterAgendaSemanaDefaults implements FilterAgendaSemana {
    operator?: string = ' AND ';
    paranome?: string = '';
    data?: string = '';
    funcionario?: number = -2147483648;
    advogado?: number = -2147483648;
    hora?: string = '';
    tipocompromisso?: number = -2147483648;
    compromisso?: string = '';
    horafinal?: string = '';
    nome?: string = '';
    cliente?: number = -2147483648;
    nomecliente?: string = '';
    tipo?: string = '';
}
    