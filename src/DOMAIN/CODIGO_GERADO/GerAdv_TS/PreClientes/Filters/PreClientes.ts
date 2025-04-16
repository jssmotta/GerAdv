export interface FilterPreClientes
{
    operator?: string;
 quemindicou?: string;
 nome?: string;
    adv?: number;
    idrep?: number;
 nomefantasia?: string;
 class?: string;
 dtnasc?: string;
 inscest?: string;
 qualificacao?: string;
    idade?: number;
 cnpj?: string;
 cpf?: string;
 rg?: string;
 observacao?: string;
 endereco?: string;
 bairro?: string;
    cidade?: number;
 cep?: string;
 fax?: string;
 fone?: string;
 data?: string;
 homepage?: string;
 email?: string;
 assistido?: string;
 assrg?: string;
 asscpf?: string;
 assendereco?: string;
 cnh?: string;
}

export class FilterPreClientesDefaults implements FilterPreClientes {
    operator?: string = " AND ";
    quemindicou?: string = '';
    nome?: string = '';
    adv?: number = -2147483648;
    idrep?: number = -2147483648;
    nomefantasia?: string = '';
    class?: string = '';
    dtnasc?: string = '';
    inscest?: string = '';
    qualificacao?: string = '';
    idade?: number = -2147483648;
    cnpj?: string = '';
    cpf?: string = '';
    rg?: string = '';
    observacao?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cidade?: number = -2147483648;
    cep?: string = '';
    fax?: string = '';
    fone?: string = '';
    data?: string = '';
    homepage?: string = '';
    email?: string = '';
    assistido?: string = '';
    assrg?: string = '';
    asscpf?: string = '';
    assendereco?: string = '';
    cnh?: string = '';
}
    