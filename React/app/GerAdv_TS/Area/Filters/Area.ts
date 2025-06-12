export interface FilterArea
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterAreaDefaults implements FilterArea {
    operator?: string = ' AND ';
    descricao?: string = '';
    guid?: string = '';
}
    