export interface FilterPoderJudiciarioAssociado
{
    operator?: string;
    justica?: number;
 justicanome?: string;
    area?: number;
 areanome?: string;
    tribunal?: number;
 tribunalnome?: string;
    foro?: number;
 foronome?: string;
    cidade?: number;
 subdivisaonome?: string;
 cidadenome?: string;
    subdivisao?: number;
    tipo?: number;
 guid?: string;
}

export class FilterPoderJudiciarioAssociadoDefaults implements FilterPoderJudiciarioAssociado {
    operator?: string = " AND ";
    justica?: number = -2147483648;
    justicanome?: string = '';
    area?: number = -2147483648;
    areanome?: string = '';
    tribunal?: number = -2147483648;
    tribunalnome?: string = '';
    foro?: number = -2147483648;
    foronome?: string = '';
    cidade?: number = -2147483648;
    subdivisaonome?: string = '';
    cidadenome?: string = '';
    subdivisao?: number = -2147483648;
    tipo?: number = -2147483648;
    guid?: string = '';
}
    