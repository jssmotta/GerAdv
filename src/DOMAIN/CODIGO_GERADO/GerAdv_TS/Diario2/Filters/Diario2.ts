export interface FilterDiario2
{
    operator?: string;
 data?: string;
 hora?: string;
    operador?: number;
 nome?: string;
 ocorrencia?: string;
    cliente?: number;
}

export class FilterDiario2Defaults implements FilterDiario2 {
    operator?: string = " AND ";
    data?: string = '';
    hora?: string = '';
    operador?: number = -2147483648;
    nome?: string = '';
    ocorrencia?: string = '';
    cliente?: number = -2147483648;
}
    