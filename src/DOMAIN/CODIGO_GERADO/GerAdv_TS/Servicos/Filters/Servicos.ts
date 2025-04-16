export interface FilterServicos
{
    operator?: string;
 descricao?: string;
}

export class FilterServicosDefaults implements FilterServicos {
    operator?: string = " AND ";
    descricao?: string = '';
}
    