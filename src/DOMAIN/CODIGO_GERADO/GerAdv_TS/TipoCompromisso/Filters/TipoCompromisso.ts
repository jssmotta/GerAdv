﻿export interface FilterTipoCompromisso
{
    operator?: string;
    icone?: number;
 descricao?: string;
}

export class FilterTipoCompromissoDefaults implements FilterTipoCompromisso {
    operator?: string = " AND ";
    icone?: number = -2147483648;
    descricao?: string = '';
}
    