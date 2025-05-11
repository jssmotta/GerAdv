export interface FilterProPartes
{
    operator?: string;
    parte?: number;
    processo?: number;
}

export class FilterProPartesDefaults implements FilterProPartes {
    operator?: string = " AND ";
    parte?: number = -2147483648;
    processo?: number = -2147483648;
}
    