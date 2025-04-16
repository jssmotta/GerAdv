export interface FilterStatusAndamento
{
    operator?: string;
 nome?: string;
    icone?: number;
}

export class FilterStatusAndamentoDefaults implements FilterStatusAndamento {
    operator?: string = " AND ";
    nome?: string = '';
    icone?: number = -2147483648;
}
    