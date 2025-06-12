export interface FilterApenso2
{
    operator?: string;
    processo?: number;
    apensado?: number;
}

export class FilterApenso2Defaults implements FilterApenso2 {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    apensado?: number = -2147483648;
}
    