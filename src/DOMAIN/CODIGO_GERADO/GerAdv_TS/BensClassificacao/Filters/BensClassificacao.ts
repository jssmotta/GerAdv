export interface FilterBensClassificacao
{
    operator?: string;
 nome?: string;
}

export class FilterBensClassificacaoDefaults implements FilterBensClassificacao {
    operator?: string = " AND ";
    nome?: string = '';
}
    