export interface FilterParceriaProc
{
    operator?: string;
    advogado?: number;
    processo?: number;
}

export class FilterParceriaProcDefaults implements FilterParceriaProc {
    operator?: string = " AND ";
    advogado?: number = -2147483648;
    processo?: number = -2147483648;
}
    