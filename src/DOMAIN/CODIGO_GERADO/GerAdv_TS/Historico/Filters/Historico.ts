export interface FilterHistorico
{
    operator?: string;
    extraid?: number;
    idne?: number;
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
}

export class FilterHistoricoDefaults implements FilterHistorico {
    operator?: string = " AND ";
    extraid?: number = -2147483648;
    idne?: number = -2147483648;
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
}
    