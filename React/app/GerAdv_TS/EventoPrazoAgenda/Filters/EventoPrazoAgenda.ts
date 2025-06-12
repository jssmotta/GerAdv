export interface FilterEventoPrazoAgenda
{
    operator?: string;
 nome?: string;
}

export class FilterEventoPrazoAgendaDefaults implements FilterEventoPrazoAgenda {
    operator?: string = ' AND ';
    nome?: string = '';
}
    