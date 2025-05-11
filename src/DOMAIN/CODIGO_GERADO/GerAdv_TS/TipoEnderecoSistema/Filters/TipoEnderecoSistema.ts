export interface FilterTipoEnderecoSistema
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterTipoEnderecoSistemaDefaults implements FilterTipoEnderecoSistema {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    