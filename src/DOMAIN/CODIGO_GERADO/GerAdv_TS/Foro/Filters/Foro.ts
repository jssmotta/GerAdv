export interface FilterForo
{
    operator?: string;
 email?: string;
 nome?: string;
    cidade?: number;
 site?: string;
 endereco?: string;
 bairro?: string;
 fone?: string;
 fax?: string;
 cep?: string;
 obs?: string;
 web?: string;
}

export class FilterForoDefaults implements FilterForo {
    operator?: string = " AND ";
    email?: string = '';
    nome?: string = '';
    cidade?: number = -2147483648;
    site?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    fone?: string = '';
    fax?: string = '';
    cep?: string = '';
    obs?: string = '';
    web?: string = '';
}
    