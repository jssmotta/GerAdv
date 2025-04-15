export interface FilterPenhora
{
    operator?: string;
    processo?: number;
 nome?: string;
 descricao?: string;
 datapenhora?: string;
    penhorastatus?: number;
    master?: number;
}

export class FilterPenhoraDefaults implements FilterPenhora {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    nome?: string = '';
    descricao?: string = '';
    datapenhora?: string = '';
    penhorastatus?: number = -2147483648;
    master?: number = -2147483648;
}
    