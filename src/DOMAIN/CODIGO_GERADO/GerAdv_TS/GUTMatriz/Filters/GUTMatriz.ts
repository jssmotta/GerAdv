export interface FilterGUTMatriz
{
    operator?: string;
 descricao?: string;
    guttipo?: number;
    valor?: number;
}

export class FilterGUTMatrizDefaults implements FilterGUTMatriz {
    operator?: string = " AND ";
    descricao?: string = '';
    guttipo?: number = -2147483648;
    valor?: number = -2147483648;
}
    