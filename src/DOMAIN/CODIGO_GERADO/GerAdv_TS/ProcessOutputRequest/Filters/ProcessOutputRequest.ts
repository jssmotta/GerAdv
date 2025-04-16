export interface FilterProcessOutputRequest
{
    operator?: string;
    processoutputengine?: number;
    operador?: number;
    processo?: number;
    ultimoidtabelaexo?: number;
}

export class FilterProcessOutputRequestDefaults implements FilterProcessOutputRequest {
    operator?: string = " AND ";
    processoutputengine?: number = -2147483648;
    operador?: number = -2147483648;
    processo?: number = -2147483648;
    ultimoidtabelaexo?: number = -2147483648;
}
    