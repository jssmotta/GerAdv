export interface FilterOperadorGruposAgenda
{
    operator?: string;
 sqlwhere?: string;
 nome?: string;
    operador?: number;
 guid?: string;
}

export class FilterOperadorGruposAgendaDefaults implements FilterOperadorGruposAgenda {
    operator?: string = ' AND ';
    sqlwhere?: string = '';
    nome?: string = '';
    operador?: number = -2147483648;
    guid?: string = '';
}
    