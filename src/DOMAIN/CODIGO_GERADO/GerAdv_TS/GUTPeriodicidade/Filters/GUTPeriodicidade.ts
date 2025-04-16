export interface FilterGUTPeriodicidade
{
    operator?: string;
 nome?: string;
    intervalodias?: number;
}

export class FilterGUTPeriodicidadeDefaults implements FilterGUTPeriodicidade {
    operator?: string = " AND ";
    nome?: string = '';
    intervalodias?: number = -2147483648;
}
    