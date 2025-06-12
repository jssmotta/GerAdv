export interface FilterProcessosObsReport
{
    operator?: string;
 data?: string;
    processo?: number;
 observacao?: string;
    historico?: number;
}

export class FilterProcessosObsReportDefaults implements FilterProcessosObsReport {
    operator?: string = ' AND ';
    data?: string = '';
    processo?: number = -2147483648;
    observacao?: string = '';
    historico?: number = -2147483648;
}
    