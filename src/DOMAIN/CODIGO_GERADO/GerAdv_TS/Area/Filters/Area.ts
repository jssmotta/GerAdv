export interface FilterArea
{
    operator?: string;
 descricao?: string;
}

export class FilterAreaDefaults implements FilterArea {
    operator?: string = " AND ";
    descricao?: string = '';
}
    