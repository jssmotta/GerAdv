export interface FilterContatoCRMView
{
    operator?: string;
 cguid?: string;
 data?: string;
 ip?: string;
}

export class FilterContatoCRMViewDefaults implements FilterContatoCRMView {
    operator?: string = " AND ";
    cguid?: string = '';
    data?: string = '';
    ip?: string = '';
}
    