export interface FilterTipoValorProcesso
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterTipoValorProcessoDefaults implements FilterTipoValorProcesso {
    operator?: string = ' AND ';
    descricao?: string = '';
    guid?: string = '';
}
    