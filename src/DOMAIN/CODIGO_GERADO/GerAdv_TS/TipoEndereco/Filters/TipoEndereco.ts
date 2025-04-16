export interface FilterTipoEndereco
{
    operator?: string;
 descricao?: string;
}

export class FilterTipoEnderecoDefaults implements FilterTipoEndereco {
    operator?: string = " AND ";
    descricao?: string = '';
}
    