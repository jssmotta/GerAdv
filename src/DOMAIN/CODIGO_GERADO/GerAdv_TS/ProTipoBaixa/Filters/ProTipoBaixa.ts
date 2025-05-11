export interface FilterProTipoBaixa
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterProTipoBaixaDefaults implements FilterProTipoBaixa {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    