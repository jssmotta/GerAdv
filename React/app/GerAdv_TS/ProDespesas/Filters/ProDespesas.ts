export interface FilterProDespesas
{
    operator?: string;
    ligacaoid?: number;
    cliente?: number;
 data?: string;
    valororiginal?: number;
    processo?: number;
    quitado?: number;
 datacorrecao?: string;
    valor?: number;
 historico?: string;
 guid?: string;
}

export class FilterProDespesasDefaults implements FilterProDespesas {
    operator?: string = ' AND ';
    ligacaoid?: number = -2147483648;
    cliente?: number = -2147483648;
    data?: string = '';
    valororiginal?: number = -2147483648;
    processo?: number = -2147483648;
    quitado?: number = -2147483648;
    datacorrecao?: string = '';
    valor?: number = -2147483648;
    historico?: string = '';
    guid?: string = '';
}
    