export interface FilterTipoModeloDocumento
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterTipoModeloDocumentoDefaults implements FilterTipoModeloDocumento {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    