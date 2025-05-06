export interface FilterEnderecoSistema
{
    operator?: string;
    cadastro?: number;
    cadastroexcod?: number;
    tipoenderecosistema?: number;
    processo?: number;
 motivo?: string;
 contatonolocal?: string;
    cidade?: number;
 endereco?: string;
 bairro?: string;
 cep?: string;
 fone?: string;
 fax?: string;
 observacao?: string;
 guid?: string;
}

export class FilterEnderecoSistemaDefaults implements FilterEnderecoSistema {
    operator?: string = " AND ";
    cadastro?: number = -2147483648;
    cadastroexcod?: number = -2147483648;
    tipoenderecosistema?: number = -2147483648;
    processo?: number = -2147483648;
    motivo?: string = '';
    contatonolocal?: string = '';
    cidade?: number = -2147483648;
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    fone?: string = '';
    fax?: string = '';
    observacao?: string = '';
    guid?: string = '';
}
    