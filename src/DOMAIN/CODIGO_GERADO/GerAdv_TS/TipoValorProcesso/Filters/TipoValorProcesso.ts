export interface FilterTipoValorProcesso
{
    operator?: string;
 descricao?: string;
}

export class FilterTipoValorProcessoDefaults implements FilterTipoValorProcesso {
    operator?: string = " AND ";
    descricao?: string = '';
}
    