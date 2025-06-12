export interface FilterStatusBiu
{
    operator?: string;
 nome?: string;
    tipostatusbiu?: number;
    operador?: number;
    icone?: number;
}

export class FilterStatusBiuDefaults implements FilterStatusBiu {
    operator?: string = ' AND ';
    nome?: string = '';
    tipostatusbiu?: number = -2147483648;
    operador?: number = -2147483648;
    icone?: number = -2147483648;
}
    