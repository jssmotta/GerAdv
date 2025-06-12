export interface FilterAndComp
{
    operator?: string;
    andamento?: number;
    compromisso?: number;
}

export class FilterAndCompDefaults implements FilterAndComp {
    operator?: string = ' AND ';
    andamento?: number = -2147483648;
    compromisso?: number = -2147483648;
}
    