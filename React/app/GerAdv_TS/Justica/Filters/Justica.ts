export interface FilterJustica
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterJusticaDefaults implements FilterJustica {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    