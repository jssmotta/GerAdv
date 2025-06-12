export interface FilterServicos
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterServicosDefaults implements FilterServicos {
    operator?: string = ' AND ';
    descricao?: string = '';
    guid?: string = '';
}
    