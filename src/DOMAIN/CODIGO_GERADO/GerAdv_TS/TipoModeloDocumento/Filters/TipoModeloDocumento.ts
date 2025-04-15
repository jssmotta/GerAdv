export interface FilterTipoModeloDocumento
{
    operator?: string;
 nome?: string;
}

export class FilterTipoModeloDocumentoDefaults implements FilterTipoModeloDocumento {
    operator?: string = " AND ";
    nome?: string = '';
}
    