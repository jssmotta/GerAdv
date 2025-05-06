export interface FilterTribunal
{
    operator?: string;
 nome?: string;
    area?: number;
    justica?: number;
 descricao?: string;
    instancia?: number;
 sigla?: string;
 web?: string;
 guid?: string;
}

export class FilterTribunalDefaults implements FilterTribunal {
    operator?: string = " AND ";
    nome?: string = '';
    area?: number = -2147483648;
    justica?: number = -2147483648;
    descricao?: string = '';
    instancia?: number = -2147483648;
    sigla?: string = '';
    web?: string = '';
    guid?: string = '';
}
    