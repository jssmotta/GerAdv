export interface FilterOperadorGruposAgendaOperadores
{
    operator?: string;
    operadorgruposagenda?: number;
    operador?: number;
}

export class FilterOperadorGruposAgendaOperadoresDefaults implements FilterOperadorGruposAgendaOperadores {
    operator?: string = " AND ";
    operadorgruposagenda?: number = -2147483648;
    operador?: number = -2147483648;
}
    