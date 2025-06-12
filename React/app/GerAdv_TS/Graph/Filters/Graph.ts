export interface FilterGraph
{
    operator?: string;
 tabela?: string;
    tabelaid?: number;
 guid?: string;
}

export class FilterGraphDefaults implements FilterGraph {
    operator?: string = ' AND ';
    tabela?: string = '';
    tabelaid?: number = -2147483648;
    guid?: string = '';
}
    