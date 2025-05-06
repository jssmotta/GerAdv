export interface FilterObjetos
{
    operator?: string;
    justica?: number;
    area?: number;
 nome?: string;
 guid?: string;
}

export class FilterObjetosDefaults implements FilterObjetos {
    operator?: string = " AND ";
    justica?: number = -2147483648;
    area?: number = -2147483648;
    nome?: string = '';
    guid?: string = '';
}
    