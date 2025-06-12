export interface FilterCidade
{
    operator?: string;
 ddd?: string;
 nome?: string;
    uf?: number;
 sigla?: string;
 guid?: string;
}

export class FilterCidadeDefaults implements FilterCidade {
    operator?: string = ' AND ';
    ddd?: string = '';
    nome?: string = '';
    uf?: number = -2147483648;
    sigla?: string = '';
    guid?: string = '';
}
    