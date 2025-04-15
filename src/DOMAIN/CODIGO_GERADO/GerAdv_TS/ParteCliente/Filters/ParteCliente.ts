export interface FilterParteCliente
{
    operator?: string;
    cliente?: number;
    processo?: number;
}

export class FilterParteClienteDefaults implements FilterParteCliente {
    operator?: string = " AND ";
    cliente?: number = -2147483648;
    processo?: number = -2147483648;
}
    