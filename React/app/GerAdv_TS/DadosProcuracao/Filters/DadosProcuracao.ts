export interface FilterDadosProcuracao
{
    operator?: string;
    cliente?: number;
 estadocivil?: string;
 nacionalidade?: string;
 profissao?: string;
 ctps?: string;
 pispasep?: string;
 remuneracao?: string;
 objeto?: string;
 guid?: string;
}

export class FilterDadosProcuracaoDefaults implements FilterDadosProcuracao {
    operator?: string = ' AND ';
    cliente?: number = -2147483648;
    estadocivil?: string = '';
    nacionalidade?: string = '';
    profissao?: string = '';
    ctps?: string = '';
    pispasep?: string = '';
    remuneracao?: string = '';
    objeto?: string = '';
    guid?: string = '';
}
    