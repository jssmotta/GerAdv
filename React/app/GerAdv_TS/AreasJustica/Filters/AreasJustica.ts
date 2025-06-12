export interface FilterAreasJustica
{
    operator?: string;
    area?: number;
    justica?: number;
}

export class FilterAreasJusticaDefaults implements FilterAreasJustica {
    operator?: string = ' AND ';
    area?: number = -2147483648;
    justica?: number = -2147483648;
}
    