export interface FilterProObservacoes
{
    operator?: string;
    processo?: number;
 nome?: string;
 observacoes?: string;
 data?: string;
}

export class FilterProObservacoesDefaults implements FilterProObservacoes {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    nome?: string = '';
    observacoes?: string = '';
    data?: string = '';
}
    