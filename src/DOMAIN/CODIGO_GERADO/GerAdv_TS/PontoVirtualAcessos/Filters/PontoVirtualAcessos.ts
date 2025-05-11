export interface FilterPontoVirtualAcessos
{
    operator?: string;
    operador?: number;
 datahora?: string;
 origem?: string;
}

export class FilterPontoVirtualAcessosDefaults implements FilterPontoVirtualAcessos {
    operator?: string = " AND ";
    operador?: number = -2147483648;
    datahora?: string = '';
    origem?: string = '';
}
    