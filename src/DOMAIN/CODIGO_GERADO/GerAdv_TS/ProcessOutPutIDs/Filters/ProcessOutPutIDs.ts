﻿export interface FilterProcessOutPutIDs
{
    operator?: string;
 nome?: string;
}

export class FilterProcessOutPutIDsDefaults implements FilterProcessOutPutIDs {
    operator?: string = " AND ";
    nome?: string = '';
}
    