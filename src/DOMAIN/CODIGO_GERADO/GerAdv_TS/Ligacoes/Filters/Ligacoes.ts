export interface FilterLigacoes
{
    operator?: string;
 assunto?: string;
    ageclienteavisado?: number;
    cliente?: number;
 contato?: string;
 datarealizada?: string;
    quemid?: number;
    telefonista?: number;
 ultimoaviso?: string;
 horafinal?: string;
 nome?: string;
    quemcodigo?: number;
    solicitante?: number;
 para?: string;
 fone?: string;
    ramal?: number;
 status?: string;
 data?: string;
 hora?: string;
 ligarpara?: string;
    processo?: number;
    emotion?: number;
 guid?: string;
}

export class FilterLigacoesDefaults implements FilterLigacoes {
    operator?: string = " AND ";
    assunto?: string = '';
    ageclienteavisado?: number = -2147483648;
    cliente?: number = -2147483648;
    contato?: string = '';
    datarealizada?: string = '';
    quemid?: number = -2147483648;
    telefonista?: number = -2147483648;
    ultimoaviso?: string = '';
    horafinal?: string = '';
    nome?: string = '';
    quemcodigo?: number = -2147483648;
    solicitante?: number = -2147483648;
    para?: string = '';
    fone?: string = '';
    ramal?: number = -2147483648;
    status?: string = '';
    data?: string = '';
    hora?: string = '';
    ligarpara?: string = '';
    processo?: number = -2147483648;
    emotion?: number = -2147483648;
    guid?: string = '';
}
    