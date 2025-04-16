export interface FilterPosicaoOutrasPartes
{
    operator?: string;
 descricao?: string;
}

export class FilterPosicaoOutrasPartesDefaults implements FilterPosicaoOutrasPartes {
    operator?: string = " AND ";
    descricao?: string = '';
}
    