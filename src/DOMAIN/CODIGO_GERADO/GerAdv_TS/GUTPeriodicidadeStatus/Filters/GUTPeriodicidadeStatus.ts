export interface FilterGUTPeriodicidadeStatus
{
    operator?: string;
    gutatividade?: number;
 datarealizado?: string;
}

export class FilterGUTPeriodicidadeStatusDefaults implements FilterGUTPeriodicidadeStatus {
    operator?: string = " AND ";
    gutatividade?: number = -2147483648;
    datarealizado?: string = '';
}
    