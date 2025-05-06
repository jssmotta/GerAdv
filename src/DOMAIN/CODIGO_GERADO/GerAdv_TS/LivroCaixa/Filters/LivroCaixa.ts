export interface FilterLivroCaixa
{
    operator?: string;
    iddes?: number;
    pessoal?: number;
    idhon?: number;
    idhonparc?: number;
 data?: string;
    processo?: number;
    valor?: number;
 historico?: string;
    grupo?: number;
}

export class FilterLivroCaixaDefaults implements FilterLivroCaixa {
    operator?: string = " AND ";
    iddes?: number = -2147483648;
    pessoal?: number = -2147483648;
    idhon?: number = -2147483648;
    idhonparc?: number = -2147483648;
    data?: string = '';
    processo?: number = -2147483648;
    valor?: number = -2147483648;
    historico?: string = '';
    grupo?: number = -2147483648;
}
    