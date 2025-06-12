export interface FilterTribEnderecos
{
    operator?: string;
    tribunal?: number;
    cidade?: number;
 endereco?: string;
 cep?: string;
 fone?: string;
 fax?: string;
 obs?: string;
}

export class FilterTribEnderecosDefaults implements FilterTribEnderecos {
    operator?: string = ' AND ';
    tribunal?: number = -2147483648;
    cidade?: number = -2147483648;
    endereco?: string = '';
    cep?: string = '';
    fone?: string = '';
    fax?: string = '';
    obs?: string = '';
}
    