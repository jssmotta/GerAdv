export interface FilterNEPalavrasChaves
{
    operator?: string;
 nome?: string;
}

export class FilterNEPalavrasChavesDefaults implements FilterNEPalavrasChaves {
    operator?: string = " AND ";
    nome?: string = '';
}
    