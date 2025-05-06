export interface FilterUF
{
    operator?: string;
 ddd?: string;
 iduf?: string;
    pais?: number;
 descricao?: string;
 guid?: string;
}

export class FilterUFDefaults implements FilterUF {
    operator?: string = " AND ";
    ddd?: string = '';
    iduf?: string = '';
    pais?: number = -2147483648;
    descricao?: string = '';
    guid?: string = '';
}
    