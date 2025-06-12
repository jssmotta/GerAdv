export interface FilterRamal
{
    operator?: string;
 nome?: string;
 obs?: string;
}

export class FilterRamalDefaults implements FilterRamal {
    operator?: string = ' AND ';
    nome?: string = '';
    obs?: string = '';
}
    