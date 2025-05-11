export interface FilterStatusAndamento
{
    operator?: string;
 nome?: string;
    icone?: number;
 guid?: string;
}

export class FilterStatusAndamentoDefaults implements FilterStatusAndamento {
    operator?: string = " AND ";
    nome?: string = '';
    icone?: number = -2147483648;
    guid?: string = '';
}
    