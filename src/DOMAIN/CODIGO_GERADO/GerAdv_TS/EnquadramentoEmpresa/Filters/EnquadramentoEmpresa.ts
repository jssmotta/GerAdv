export interface FilterEnquadramentoEmpresa
{
    operator?: string;
 nome?: string;
}

export class FilterEnquadramentoEmpresaDefaults implements FilterEnquadramentoEmpresa {
    operator?: string = " AND ";
    nome?: string = '';
}
    