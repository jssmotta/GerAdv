export interface FilterProTipoBaixa
{
    operator?: string;
 nome?: string;
}

export class FilterProTipoBaixaDefaults implements FilterProTipoBaixa {
    operator?: string = " AND ";
    nome?: string = '';
}
    