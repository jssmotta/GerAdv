export interface FilterHistorico
{
    operator?: string;
    extraid?: number;
    idne?: number;
 guid?: string;
    liminarorigem?: number;
    processo?: number;
    precatoria?: number;
    apenso?: number;
    idinstprocesso?: number;
    fase?: number;
 data?: string;
 observacao?: string;
    sad?: number;
    statusandamento?: number;
 guid?: string;
}

export class FilterHistoricoDefaults implements FilterHistorico {
    operator?: string = " AND ";
    extraid?: number = -2147483648;
    idne?: number = -2147483648;
    guid?: string = '';
    liminarorigem?: number = -2147483648;
    processo?: number = -2147483648;
    precatoria?: number = -2147483648;
    apenso?: number = -2147483648;
    idinstprocesso?: number = -2147483648;
    fase?: number = -2147483648;
    data?: string = '';
    observacao?: string = '';
    sad?: number = -2147483648;
    statusandamento?: number = -2147483648;
    guid?: string = '';
}
    