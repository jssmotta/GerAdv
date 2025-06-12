export interface FilterTiposAcao
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterTiposAcaoDefaults implements FilterTiposAcao {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    