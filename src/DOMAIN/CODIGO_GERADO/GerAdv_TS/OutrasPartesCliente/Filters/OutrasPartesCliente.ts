export interface FilterOutrasPartesCliente
{
    operator?: string;
 nome?: string;
    clienteprincipal?: number;
 dtnasc?: string;
 cpf?: string;
 rg?: string;
 cnpj?: string;
 inscest?: string;
 nomefantasia?: string;
 endereco?: string;
    cidade?: number;
 cep?: string;
 bairro?: string;
 fone?: string;
 fax?: string;
 email?: string;
 site?: string;
 class?: string;
 guid?: string;
}

export class FilterOutrasPartesClienteDefaults implements FilterOutrasPartesCliente {
    operator?: string = " AND ";
    nome?: string = '';
    clienteprincipal?: number = -2147483648;
    dtnasc?: string = '';
    cpf?: string = '';
    rg?: string = '';
    cnpj?: string = '';
    inscest?: string = '';
    nomefantasia?: string = '';
    endereco?: string = '';
    cidade?: number = -2147483648;
    cep?: string = '';
    bairro?: string = '';
    fone?: string = '';
    fax?: string = '';
    email?: string = '';
    site?: string = '';
    class?: string = '';
    guid?: string = '';
}
    