export interface FilterBensClassificacao
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterBensClassificacaoDefaults implements FilterBensClassificacao {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    