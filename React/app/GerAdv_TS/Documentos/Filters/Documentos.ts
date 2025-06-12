export interface FilterDocumentos
{
    operator?: string;
    processo?: number;
 data?: string;
 observacao?: string;
 guid?: string;
}

export class FilterDocumentosDefaults implements FilterDocumentos {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    data?: string = '';
    observacao?: string = '';
    guid?: string = '';
}
    