export interface FilterGUTAtividades
{
    operator?: string;
 nome?: string;
 observacao?: string;
    gutgrupo?: number;
    gutperiodicidade?: number;
    operador?: number;
 dataconcluido?: string;
    diasparainiciar?: number;
    minutospararealizar?: number;
}

export class FilterGUTAtividadesDefaults implements FilterGUTAtividades {
    operator?: string = " AND ";
    nome?: string = '';
    observacao?: string = '';
    gutgrupo?: number = -2147483648;
    gutperiodicidade?: number = -2147483648;
    operador?: number = -2147483648;
    dataconcluido?: string = '';
    diasparainiciar?: number = -2147483648;
    minutospararealizar?: number = -2147483648;
}
    