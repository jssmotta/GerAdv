export interface FilterEndTit
{
    operator?: string;
    endereco?: number;
    titulo?: number;
}

export class FilterEndTitDefaults implements FilterEndTit {
    operator?: string = ' AND ';
    endereco?: number = -2147483648;
    titulo?: number = -2147483648;
}
    