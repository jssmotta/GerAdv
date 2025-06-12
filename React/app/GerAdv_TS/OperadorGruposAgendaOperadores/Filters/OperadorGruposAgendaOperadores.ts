export interface FilterOperadorGruposAgendaOperadores
{
    operator?: string;
    operadorgruposagenda?: number;
    operador?: number;
 guid?: string;
}

export class FilterOperadorGruposAgendaOperadoresDefaults implements FilterOperadorGruposAgendaOperadores {
    operator?: string = ' AND ';
    operadorgruposagenda?: number = -2147483648;
    operador?: number = -2147483648;
    guid?: string = '';
}
    