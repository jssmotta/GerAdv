export interface FilterTipoContatoCRM
{
    operator?: string;
 nome?: string;
}

export class FilterTipoContatoCRMDefaults implements FilterTipoContatoCRM {
    operator?: string = " AND ";
    nome?: string = '';
}
    