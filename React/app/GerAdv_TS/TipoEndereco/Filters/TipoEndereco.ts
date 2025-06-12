export interface FilterTipoEndereco
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterTipoEnderecoDefaults implements FilterTipoEndereco {
    operator?: string = ' AND ';
    descricao?: string = '';
    guid?: string = '';
}
    