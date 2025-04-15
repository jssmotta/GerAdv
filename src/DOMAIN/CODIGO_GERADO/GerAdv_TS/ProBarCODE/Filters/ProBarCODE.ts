export interface FilterProBarCODE
{
    operator?: string;
 barcode?: string;
    processo?: number;
}

export class FilterProBarCODEDefaults implements FilterProBarCODE {
    operator?: string = " AND ";
    barcode?: string = '';
    processo?: number = -2147483648;
}
    