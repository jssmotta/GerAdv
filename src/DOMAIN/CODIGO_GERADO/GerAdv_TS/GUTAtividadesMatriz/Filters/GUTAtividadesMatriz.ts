export interface FilterGUTAtividadesMatriz
{
    operator?: string;
    gutmatriz?: number;
    gutatividade?: number;
 guid?: string;
}

export class FilterGUTAtividadesMatrizDefaults implements FilterGUTAtividadesMatriz {
    operator?: string = " AND ";
    gutmatriz?: number = -2147483648;
    gutatividade?: number = -2147483648;
    guid?: string = '';
}
    