export interface FilterPontoVirtual
{
    operator?: string;
 horaentrada?: string;
 horasaida?: string;
    operador?: number;
 key?: string;
}

export class FilterPontoVirtualDefaults implements FilterPontoVirtual {
    operator?: string = " AND ";
    horaentrada?: string = '';
    horasaida?: string = '';
    operador?: number = -2147483648;
    key?: string = '';
}
    