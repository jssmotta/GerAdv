export interface FilterStatusHTrab
{
    operator?: string;
 descricao?: string;
    resid?: number;
}

export class FilterStatusHTrabDefaults implements FilterStatusHTrab {
    operator?: string = " AND ";
    descricao?: string = '';
    resid?: number = -2147483648;
}
    