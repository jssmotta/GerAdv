export interface FilterReuniaoPessoas
{
    operator?: string;
    reuniao?: number;
    operador?: number;
}

export class FilterReuniaoPessoasDefaults implements FilterReuniaoPessoas {
    operator?: string = " AND ";
    reuniao?: number = -2147483648;
    operador?: number = -2147483648;
}
    