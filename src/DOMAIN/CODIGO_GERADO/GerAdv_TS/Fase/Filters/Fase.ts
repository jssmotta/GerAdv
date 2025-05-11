export interface FilterFase
{
    operator?: string;
 descricao?: string;
    justica?: number;
    area?: number;
 guid?: string;
}

export class FilterFaseDefaults implements FilterFase {
    operator?: string = " AND ";
    descricao?: string = '';
    justica?: number = -2147483648;
    area?: number = -2147483648;
    guid?: string = '';
}
    