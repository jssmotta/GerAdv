export interface FilterOperador
{
    operator?: string;
 email?: string;
 pasta?: string;
 nome?: string;
 nick?: string;
 ramal?: string;
    cadid?: number;
    cadcod?: number;
    computador?: number;
 minhadescricao?: string;
 ultimologoff?: string;
 emailnet?: string;
 onlineip?: string;
    statusid?: number;
 statusmessage?: string;
 senha256?: string;
 datalimitereset?: string;
 suportesenha256?: string;
 suportemaxage?: string;
 suportenomesolicitante?: string;
 suporteultimoacesso?: string;
 suporteipultimoacesso?: string;
 guid?: string;
}

export class FilterOperadorDefaults implements FilterOperador {
    operator?: string = " AND ";
    email?: string = '';
    pasta?: string = '';
    nome?: string = '';
    nick?: string = '';
    ramal?: string = '';
    cadid?: number = -2147483648;
    cadcod?: number = -2147483648;
    computador?: number = -2147483648;
    minhadescricao?: string = '';
    ultimologoff?: string = '';
    emailnet?: string = '';
    onlineip?: string = '';
    statusid?: number = -2147483648;
    statusmessage?: string = '';
    senha256?: string = '';
    datalimitereset?: string = '';
    suportesenha256?: string = '';
    suportemaxage?: string = '';
    suportenomesolicitante?: string = '';
    suporteultimoacesso?: string = '';
    suporteipultimoacesso?: string = '';
    guid?: string = '';
}
    