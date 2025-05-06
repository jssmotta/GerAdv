export interface FilterTerceiros
{
    operator?: string;
    processo?: number;
 nome?: string;
    situacao?: number;
    cidade?: number;
 endereco?: string;
 bairro?: string;
 cep?: string;
 fone?: string;
 fax?: string;
 obs?: string;
 email?: string;
 class?: string;
 varaforocomarca?: string;
 guid?: string;
}

export class FilterTerceirosDefaults implements FilterTerceiros {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    nome?: string = '';
    situacao?: number = -2147483648;
    cidade?: number = -2147483648;
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    fone?: string = '';
    fax?: string = '';
    obs?: string = '';
    email?: string = '';
    class?: string = '';
    varaforocomarca?: string = '';
    guid?: string = '';
}
    