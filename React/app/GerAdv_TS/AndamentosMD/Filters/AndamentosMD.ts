export interface FilterAndamentosMD
{
    operator?: string;
 nome?: string;
    processo?: number;
    andamento?: number;
 pathfull?: string;
 unc?: string;
 guid?: string;
}

export class FilterAndamentosMDDefaults implements FilterAndamentosMD {
    operator?: string = ' AND ';
    nome?: string = '';
    processo?: number = -2147483648;
    andamento?: number = -2147483648;
    pathfull?: string = '';
    unc?: string = '';
    guid?: string = '';
}
    