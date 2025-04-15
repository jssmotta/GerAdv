export interface FilterAtividades
{
    operator?: string;
 descricao?: string;
}

export class FilterAtividadesDefaults implements FilterAtividades {
    operator?: string = " AND ";
    descricao?: string = '';
}
    