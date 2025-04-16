export interface FilterRegimeTributacao
{
    operator?: string;
 nome?: string;
}

export class FilterRegimeTributacaoDefaults implements FilterRegimeTributacao {
    operator?: string = " AND ";
    nome?: string = '';
}
    