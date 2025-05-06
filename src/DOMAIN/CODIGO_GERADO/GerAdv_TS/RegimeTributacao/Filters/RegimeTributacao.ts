export interface FilterRegimeTributacao
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterRegimeTributacaoDefaults implements FilterRegimeTributacao {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    