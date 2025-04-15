export interface FilterOperadorGrupos
{
    operator?: string;
 nome?: string;
}

export class FilterOperadorGruposDefaults implements FilterOperadorGrupos {
    operator?: string = " AND ";
    nome?: string = '';
}
    