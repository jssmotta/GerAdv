export interface FilterProValores
{
    operator?: string;
    processo?: number;
    tipovalorprocesso?: number;
 indice?: string;
 data?: string;
    valororiginal?: number;
    percmulta?: number;
    valormulta?: number;
    percjuros?: number;
    valororiginalcorrigidoindice?: number;
    valormultacorrigido?: number;
    valorjuroscorrigido?: number;
    valorfinal?: number;
 dataultimacorrecao?: string;
 guid?: string;
}

export class FilterProValoresDefaults implements FilterProValores {
    operator?: string = " AND ";
    processo?: number = -2147483648;
    tipovalorprocesso?: number = -2147483648;
    indice?: string = '';
    data?: string = '';
    valororiginal?: number = -2147483648;
    percmulta?: number = -2147483648;
    valormulta?: number = -2147483648;
    percjuros?: number = -2147483648;
    valororiginalcorrigidoindice?: number = -2147483648;
    valormultacorrigido?: number = -2147483648;
    valorjuroscorrigido?: number = -2147483648;
    valorfinal?: number = -2147483648;
    dataultimacorrecao?: string = '';
    guid?: string = '';
}
    