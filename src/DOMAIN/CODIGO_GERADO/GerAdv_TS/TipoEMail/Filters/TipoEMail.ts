export interface FilterTipoEMail
{
    operator?: string;
 nome?: string;
}

export class FilterTipoEMailDefaults implements FilterTipoEMail {
    operator?: string = " AND ";
    nome?: string = '';
}
    