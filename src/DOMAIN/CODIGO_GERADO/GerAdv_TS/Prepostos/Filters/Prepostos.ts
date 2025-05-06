export interface FilterPrepostos
{
    operator?: string;
 nome?: string;
    funcao?: number;
    setor?: number;
 dtnasc?: string;
 qualificacao?: string;
    idade?: number;
 cpf?: string;
 rg?: string;
 periodo_ini?: string;
 periodo_fim?: string;
 registro?: string;
 ctpsnumero?: string;
 ctpsserie?: string;
 ctpsdtemissao?: string;
 pis?: string;
    salario?: number;
 observacao?: string;
 endereco?: string;
 bairro?: string;
    cidade?: number;
 cep?: string;
 fone?: string;
 fax?: string;
 email?: string;
 pai?: string;
 mae?: string;
 class?: string;
 guid?: string;
}

export class FilterPrepostosDefaults implements FilterPrepostos {
    operator?: string = " AND ";
    nome?: string = '';
    funcao?: number = -2147483648;
    setor?: number = -2147483648;
    dtnasc?: string = '';
    qualificacao?: string = '';
    idade?: number = -2147483648;
    cpf?: string = '';
    rg?: string = '';
    periodo_ini?: string = '';
    periodo_fim?: string = '';
    registro?: string = '';
    ctpsnumero?: string = '';
    ctpsserie?: string = '';
    ctpsdtemissao?: string = '';
    pis?: string = '';
    salario?: number = -2147483648;
    observacao?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cidade?: number = -2147483648;
    cep?: string = '';
    fone?: string = '';
    fax?: string = '';
    email?: string = '';
    pai?: string = '';
    mae?: string = '';
    class?: string = '';
    guid?: string = '';
}
    