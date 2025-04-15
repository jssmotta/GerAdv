export interface FilterTipoProDesposito
{
    operator?: string;
 nome?: string;
}

export class FilterTipoProDespositoDefaults implements FilterTipoProDesposito {
    operator?: string = " AND ";
    nome?: string = '';
}
    