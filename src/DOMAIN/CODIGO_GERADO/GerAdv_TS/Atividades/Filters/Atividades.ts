export interface FilterAtividades
{
    operator?: string;
 descricao?: string;
 guid?: string;
}

export class FilterAtividadesDefaults implements FilterAtividades {
    operator?: string = " AND ";
    descricao?: string = '';
    guid?: string = '';
}
    