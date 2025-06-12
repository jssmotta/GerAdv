export interface FilterViaRecebimento
{
    operator?: string;
 nome?: string;
}

export class FilterViaRecebimentoDefaults implements FilterViaRecebimento {
    operator?: string = ' AND ';
    nome?: string = '';
}
    