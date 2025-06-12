export interface FilterGUTPeriodicidade
{
    operator?: string;
 nome?: string;
    intervalodias?: number;
 guid?: string;
}

export class FilterGUTPeriodicidadeDefaults implements FilterGUTPeriodicidade {
    operator?: string = ' AND ';
    nome?: string = '';
    intervalodias?: number = -2147483648;
    guid?: string = '';
}
    