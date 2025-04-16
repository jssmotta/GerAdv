export interface FilterTipoEnderecoSistema
{
    operator?: string;
 nome?: string;
}

export class FilterTipoEnderecoSistemaDefaults implements FilterTipoEnderecoSistema {
    operator?: string = " AND ";
    nome?: string = '';
}
    