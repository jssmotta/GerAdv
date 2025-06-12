export interface FilterParteClienteOutras
{
    operator?: string;
    cliente?: number;
    processo?: number;
}

export class FilterParteClienteOutrasDefaults implements FilterParteClienteOutras {
    operator?: string = ' AND ';
    cliente?: number = -2147483648;
    processo?: number = -2147483648;
}
    