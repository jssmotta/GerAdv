export interface FilterEnquadramentoEmpresa
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterEnquadramentoEmpresaDefaults implements FilterEnquadramentoEmpresa {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    