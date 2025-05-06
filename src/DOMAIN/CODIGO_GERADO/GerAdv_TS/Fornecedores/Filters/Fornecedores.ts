export interface FilterFornecedores
{
    operator?: string;
    grupo?: number;
 nome?: string;
    subgrupo?: number;
 cnpj?: string;
 inscest?: string;
 cpf?: string;
 rg?: string;
 endereco?: string;
 bairro?: string;
 cep?: string;
    cidade?: number;
 fone?: string;
 fax?: string;
 email?: string;
 site?: string;
 obs?: string;
 produtos?: string;
 contatos?: string;
 guid?: string;
}

export class FilterFornecedoresDefaults implements FilterFornecedores {
    operator?: string = " AND ";
    grupo?: number = -2147483648;
    nome?: string = '';
    subgrupo?: number = -2147483648;
    cnpj?: string = '';
    inscest?: string = '';
    cpf?: string = '';
    rg?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    cidade?: number = -2147483648;
    fone?: string = '';
    fax?: string = '';
    email?: string = '';
    site?: string = '';
    obs?: string = '';
    produtos?: string = '';
    contatos?: string = '';
    guid?: string = '';
}
    