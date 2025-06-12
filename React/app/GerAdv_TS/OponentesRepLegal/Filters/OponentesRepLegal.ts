export interface FilterOponentesRepLegal
{
    operator?: string;
 nome?: string;
 fone?: string;
    oponente?: number;
 cpf?: string;
 rg?: string;
 endereco?: string;
 bairro?: string;
 cep?: string;
    cidade?: number;
 fax?: string;
 email?: string;
 site?: string;
 observacao?: string;
}

export class FilterOponentesRepLegalDefaults implements FilterOponentesRepLegal {
    operator?: string = ' AND ';
    nome?: string = '';
    fone?: string = '';
    oponente?: number = -2147483648;
    cpf?: string = '';
    rg?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    cidade?: number = -2147483648;
    fax?: string = '';
    email?: string = '';
    site?: string = '';
    observacao?: string = '';
}
    