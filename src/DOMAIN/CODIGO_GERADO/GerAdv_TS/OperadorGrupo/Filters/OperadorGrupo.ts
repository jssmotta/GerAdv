export interface FilterOperadorGrupo
{
    operator?: string;
    operador?: number;
    grupo?: number;
}

export class FilterOperadorGrupoDefaults implements FilterOperadorGrupo {
    operator?: string = " AND ";
    operador?: number = -2147483648;
    grupo?: number = -2147483648;
}
    