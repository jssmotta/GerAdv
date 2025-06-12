export interface FilterEscritorios
{
    operator?: string;
 cnpj?: string;
 nome?: string;
 oab?: string;
 endereco?: string;
    cidade?: number;
 bairro?: string;
 cep?: string;
 fone?: string;
 fax?: string;
 site?: string;
 email?: string;
 obs?: string;
 advresponsavel?: string;
 secretaria?: string;
 inscest?: string;
 guid?: string;
}

export class FilterEscritoriosDefaults implements FilterEscritorios {
    operator?: string = ' AND ';
    cnpj?: string = '';
    nome?: string = '';
    oab?: string = '';
    endereco?: string = '';
    cidade?: number = -2147483648;
    bairro?: string = '';
    cep?: string = '';
    fone?: string = '';
    fax?: string = '';
    site?: string = '';
    email?: string = '';
    obs?: string = '';
    advresponsavel?: string = '';
    secretaria?: string = '';
    inscest?: string = '';
    guid?: string = '';
}
    