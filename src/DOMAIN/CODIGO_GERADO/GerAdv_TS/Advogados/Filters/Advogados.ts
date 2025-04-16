export interface FilterAdvogados
{
    operator?: string;
    cargo?: number;
 emailpro?: string;
 cpf?: string;
 nome?: string;
 rg?: string;
 nomemae?: string;
    escritorio?: number;
 oab?: string;
 nomecompleto?: string;
 endereco?: string;
    cidade?: number;
 cep?: string;
 bairro?: string;
 ctpsserie?: string;
 ctps?: string;
 fone?: string;
 fax?: string;
    comissao?: number;
 dtinicio?: string;
 dtfim?: string;
 dtnasc?: string;
    salario?: number;
 secretaria?: string;
 textoprocuracao?: string;
 email?: string;
 especializacao?: string;
 pasta?: string;
 observacao?: string;
 contabancaria?: string;
 class?: string;
}

export class FilterAdvogadosDefaults implements FilterAdvogados {
    operator?: string = " AND ";
    cargo?: number = -2147483648;
    emailpro?: string = '';
    cpf?: string = '';
    nome?: string = '';
    rg?: string = '';
    nomemae?: string = '';
    escritorio?: number = -2147483648;
    oab?: string = '';
    nomecompleto?: string = '';
    endereco?: string = '';
    cidade?: number = -2147483648;
    cep?: string = '';
    bairro?: string = '';
    ctpsserie?: string = '';
    ctps?: string = '';
    fone?: string = '';
    fax?: string = '';
    comissao?: number = -2147483648;
    dtinicio?: string = '';
    dtfim?: string = '';
    dtnasc?: string = '';
    salario?: number = -2147483648;
    secretaria?: string = '';
    textoprocuracao?: string = '';
    email?: string = '';
    especializacao?: string = '';
    pasta?: string = '';
    observacao?: string = '';
    contabancaria?: string = '';
    class?: string = '';
}
    