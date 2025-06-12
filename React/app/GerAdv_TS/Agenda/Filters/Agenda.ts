export interface FilterAgenda
{
    operator?: string;
    idcob?: number;
    idne?: number;
    cidade?: number;
    oculto?: number;
    cartaprecatoria?: number;
 hrfinal?: string;
    advogado?: number;
    eventogerador?: number;
 eventodata?: string;
    funcionario?: number;
 data?: string;
    eventoprazo?: number;
 hora?: string;
 compromisso?: string;
    tipocompromisso?: number;
    cliente?: number;
    area?: number;
    justica?: number;
    processo?: number;
    idhistorico?: number;
    idinsprocesso?: number;
    usuario?: number;
    preposto?: number;
    quemid?: number;
    quemcodigo?: number;
 status?: string;
    valor?: number;
 decisao?: string;
    sempre?: number;
    prazodias?: number;
    protocolointegrado?: number;
 datainicioprazo?: string;
 guid?: string;
}

export class FilterAgendaDefaults implements FilterAgenda {
    operator?: string = ' AND ';
    idcob?: number = -2147483648;
    idne?: number = -2147483648;
    cidade?: number = -2147483648;
    oculto?: number = -2147483648;
    cartaprecatoria?: number = -2147483648;
    hrfinal?: string = '';
    advogado?: number = -2147483648;
    eventogerador?: number = -2147483648;
    eventodata?: string = '';
    funcionario?: number = -2147483648;
    data?: string = '';
    eventoprazo?: number = -2147483648;
    hora?: string = '';
    compromisso?: string = '';
    tipocompromisso?: number = -2147483648;
    cliente?: number = -2147483648;
    area?: number = -2147483648;
    justica?: number = -2147483648;
    processo?: number = -2147483648;
    idhistorico?: number = -2147483648;
    idinsprocesso?: number = -2147483648;
    usuario?: number = -2147483648;
    preposto?: number = -2147483648;
    quemid?: number = -2147483648;
    quemcodigo?: number = -2147483648;
    status?: string = '';
    valor?: number = -2147483648;
    decisao?: string = '';
    sempre?: number = -2147483648;
    prazodias?: number = -2147483648;
    protocolointegrado?: number = -2147483648;
    datainicioprazo?: string = '';
    guid?: string = '';
}
    