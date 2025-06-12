export interface FilterFuncao
{
    operator?: string;
 descricao?: string;
}

export class FilterFuncaoDefaults implements FilterFuncao {
    operator?: string = ' AND ';
    descricao?: string = '';
}
    