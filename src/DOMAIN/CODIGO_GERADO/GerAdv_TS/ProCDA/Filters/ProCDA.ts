export interface FilterProCDA
{
    operator?: string;
    processo?: number;
 nome?: string;
 nrointerno?: string;
}

export class FilterProCDADefaults implements FilterProCDA {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    nome?: string = '';
    nrointerno?: string = '';
}
    