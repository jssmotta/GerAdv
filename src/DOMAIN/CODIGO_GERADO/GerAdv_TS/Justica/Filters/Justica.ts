export interface FilterJustica
{
    operator?: string;
 nome?: string;
}

export class FilterJusticaDefaults implements FilterJustica {
    operator?: string = " AND ";
    nome?: string = '';
}
    