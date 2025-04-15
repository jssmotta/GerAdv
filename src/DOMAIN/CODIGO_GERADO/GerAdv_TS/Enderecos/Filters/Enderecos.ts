export interface FilterEnderecos
{
    operator?: string;
 descricao?: string;
 contato?: string;
 dtnasc?: string;
 endereco?: string;
 bairro?: string;
 cep?: string;
 oab?: string;
 obs?: string;
 fone?: string;
 fax?: string;
 tratamento?: string;
    cidade?: number;
 site?: string;
 email?: string;
    quem?: number;
 quemindicou?: string;
}

export class FilterEnderecosDefaults implements FilterEnderecos {
    operator?: string = " AND ";
    descricao?: string = '';
    contato?: string = '';
    dtnasc?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    oab?: string = '';
    obs?: string = '';
    fone?: string = '';
    fax?: string = '';
    tratamento?: string = '';
    cidade?: number = -2147483648;
    site?: string = '';
    email?: string = '';
    quem?: number = -2147483648;
    quemindicou?: string = '';
}
    