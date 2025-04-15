export interface FilterParteOponente
{
    operator?: string;
    oponente?: number;
    processo?: number;
}

export class FilterParteOponenteDefaults implements FilterParteOponente {
    operator?: string = " AND ";
    oponente?: number = -2147483648;
    processo?: number = -2147483648;
}
    