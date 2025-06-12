export interface FilterProcessOutPutIDs
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterProcessOutPutIDsDefaults implements FilterProcessOutPutIDs {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    