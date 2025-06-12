export interface FilterDivisaoTribunal
{
    operator?: string;
    numcodigo?: number;
    justica?: number;
 nomeespecial?: string;
    area?: number;
    cidade?: number;
    foro?: number;
    tribunal?: number;
 codigodiv?: string;
 endereco?: string;
 fone?: string;
 fax?: string;
 cep?: string;
 obs?: string;
 email?: string;
 andar?: string;
 guid?: string;
}

export class FilterDivisaoTribunalDefaults implements FilterDivisaoTribunal {
    operator?: string = ' AND ';
    numcodigo?: number = -2147483648;
    justica?: number = -2147483648;
    nomeespecial?: string = '';
    area?: number = -2147483648;
    cidade?: number = -2147483648;
    foro?: number = -2147483648;
    tribunal?: number = -2147483648;
    codigodiv?: string = '';
    endereco?: string = '';
    fone?: string = '';
    fax?: string = '';
    cep?: string = '';
    obs?: string = '';
    email?: string = '';
    andar?: string = '';
    guid?: string = '';
}
    