export interface FilterTipoStatusBiu
{
    operator?: string;
 nome?: string;
}

export class FilterTipoStatusBiuDefaults implements FilterTipoStatusBiu {
    operator?: string = ' AND ';
    nome?: string = '';
}
    