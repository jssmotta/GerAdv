export interface FilterPosicaoOutrasPartes
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterPosicaoOutrasPartesDefaults implements FilterPosicaoOutrasPartes {
    operator?: string = " AND ";
    descricao?: string = '';
    guid?: string = '';
}
    