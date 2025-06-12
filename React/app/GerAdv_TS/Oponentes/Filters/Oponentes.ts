export interface FilterOponentes
{
    operator?: string;
    empfuncao?: number;
 ctpsnumero?: string;
 site?: string;
 ctpsserie?: string;
 nome?: string;
    adv?: number;
    empcliente?: number;
    idrep?: number;
 pis?: string;
 contato?: string;
 cnpj?: string;
 rg?: string;
 cpf?: string;
 endereco?: string;
 fone?: string;
 fax?: string;
    cidade?: number;
 bairro?: string;
 cep?: string;
 inscest?: string;
 observacao?: string;
 email?: string;
 class?: string;
 guid?: string;
}

export class FilterOponentesDefaults implements FilterOponentes {
    operator?: string = ' AND ';
    empfuncao?: number = -2147483648;
    ctpsnumero?: string = '';
    site?: string = '';
    ctpsserie?: string = '';
    nome?: string = '';
    adv?: number = -2147483648;
    empcliente?: number = -2147483648;
    idrep?: number = -2147483648;
    pis?: string = '';
    contato?: string = '';
    cnpj?: string = '';
    rg?: string = '';
    cpf?: string = '';
    endereco?: string = '';
    fone?: string = '';
    fax?: string = '';
    cidade?: number = -2147483648;
    bairro?: string = '';
    cep?: string = '';
    inscest?: string = '';
    observacao?: string = '';
    email?: string = '';
    class?: string = '';
    guid?: string = '';
}
    