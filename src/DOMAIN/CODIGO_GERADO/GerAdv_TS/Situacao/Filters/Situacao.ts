﻿export interface FilterSituacao
{
    operator?: string;
 parte_int?: string;
 parte_opo?: string;
}

export class FilterSituacaoDefaults implements FilterSituacao {
    operator?: string = " AND ";
    parte_int?: string = '';
    parte_opo?: string = '';
}
    