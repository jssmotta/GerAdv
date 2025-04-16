export interface FilterAuditor4K
{
    operator?: string;
 nome?: string;
}

export class FilterAuditor4KDefaults implements FilterAuditor4K {
    operator?: string = " AND ";
    nome?: string = '';
}
    