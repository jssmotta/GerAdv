export interface FilterLivroCaixaClientes
{
    operator?: string;
    livrocaixa?: number;
    cliente?: number;
}

export class FilterLivroCaixaClientesDefaults implements FilterLivroCaixaClientes {
    operator?: string = " AND ";
    livrocaixa?: number = -2147483648;
    cliente?: number = -2147483648;
}
    