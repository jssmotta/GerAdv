export interface FilterTipoContatoCRM
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterTipoContatoCRMDefaults implements FilterTipoContatoCRM {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    