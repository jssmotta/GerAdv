export interface FilterProDepositos
{
    operator?: string;
    processo?: number;
    fase?: number;
 data?: string;
    valor?: number;
    tipoprodesposito?: number;
}

export class FilterProDepositosDefaults implements FilterProDepositos {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    fase?: number = -2147483648;
    data?: string = '';
    valor?: number = -2147483648;
    tipoprodesposito?: number = -2147483648;
}
    