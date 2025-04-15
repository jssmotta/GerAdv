export interface FilterTiposAcao
{
    operator?: string;
 nome?: string;
}

export class FilterTiposAcaoDefaults implements FilterTiposAcao {
    operator?: string = " AND ";
    nome?: string = '';
}
    