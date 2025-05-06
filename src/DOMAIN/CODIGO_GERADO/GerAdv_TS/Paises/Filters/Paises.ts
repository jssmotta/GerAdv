export interface FilterPaises
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterPaisesDefaults implements FilterPaises {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    