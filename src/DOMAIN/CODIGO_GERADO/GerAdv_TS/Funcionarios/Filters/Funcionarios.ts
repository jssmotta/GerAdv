export interface FilterFuncionarios
{
    operator?: string;
 emailpro?: string;
    cargo?: number;
 nome?: string;
    funcao?: number;
 registro?: string;
 cpf?: string;
 rg?: string;
 observacao?: string;
 endereco?: string;
 bairro?: string;
    cidade?: number;
 cep?: string;
 contato?: string;
 fax?: string;
 fone?: string;
 email?: string;
 periodo_ini?: string;
 periodo_fim?: string;
 ctpsnumero?: string;
 ctpsserie?: string;
 pis?: string;
    salario?: number;
 ctpsdtemissao?: string;
 dtnasc?: string;
 data?: string;
 pasta?: string;
 class?: string;
 guid?: string;
}

export class FilterFuncionariosDefaults implements FilterFuncionarios {
    operator?: string = " AND ";
    emailpro?: string = '';
    cargo?: number = -2147483648;
    nome?: string = '';
    funcao?: number = -2147483648;
    registro?: string = '';
    cpf?: string = '';
    rg?: string = '';
    observacao?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cidade?: number = -2147483648;
    cep?: string = '';
    contato?: string = '';
    fax?: string = '';
    fone?: string = '';
    email?: string = '';
    periodo_ini?: string = '';
    periodo_fim?: string = '';
    ctpsnumero?: string = '';
    ctpsserie?: string = '';
    pis?: string = '';
    salario?: number = -2147483648;
    ctpsdtemissao?: string = '';
    dtnasc?: string = '';
    data?: string = '';
    pasta?: string = '';
    class?: string = '';
    guid?: string = '';
}
    