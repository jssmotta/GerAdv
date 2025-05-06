export interface FilterModelosDocumentos
{
    operator?: string;
 nome?: string;
 remuneracao?: string;
 assinatura?: string;
 header?: string;
 footer?: string;
 extra1?: string;
 extra2?: string;
 extra3?: string;
 outorgante?: string;
 outorgados?: string;
 poderes?: string;
 objeto?: string;
 titulo?: string;
 testemunhas?: string;
    tipomodelodocumento?: number;
 css?: string;
 guid?: string;
}

export class FilterModelosDocumentosDefaults implements FilterModelosDocumentos {
    operator?: string = " AND ";
    nome?: string = '';
    remuneracao?: string = '';
    assinatura?: string = '';
    header?: string = '';
    footer?: string = '';
    extra1?: string = '';
    extra2?: string = '';
    extra3?: string = '';
    outorgante?: string = '';
    outorgados?: string = '';
    poderes?: string = '';
    objeto?: string = '';
    titulo?: string = '';
    testemunhas?: string = '';
    tipomodelodocumento?: number = -2147483648;
    css?: string = '';
    guid?: string = '';
}
    