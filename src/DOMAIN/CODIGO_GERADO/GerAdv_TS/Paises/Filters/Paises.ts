export interface FilterPaises
{
    operator?: string;
 nome?: string;
}

export class FilterPaisesDefaults implements FilterPaises {
    operator?: string = " AND ";
    nome?: string = '';
}
    