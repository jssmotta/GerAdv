export interface FilterProSucumbencia
{
    operator?: string;
    processo?: number;
    instancia?: number;
 data?: string;
 nome?: string;
    tipoorigemsucumbencia?: number;
    valor?: number;
 percentual?: string;
 guid?: string;
}

export class FilterProSucumbenciaDefaults implements FilterProSucumbencia {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    instancia?: number = -2147483648;
    data?: string = '';
    nome?: string = '';
    tipoorigemsucumbencia?: number = -2147483648;
    valor?: number = -2147483648;
    percentual?: string = '';
    guid?: string = '';
}
    