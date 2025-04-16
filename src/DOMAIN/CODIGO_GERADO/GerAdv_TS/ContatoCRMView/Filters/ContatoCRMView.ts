export interface FilterContatoCRMView
{
    operator?: string;
 data?: string;
 ip?: string;
}

export class FilterContatoCRMViewDefaults implements FilterContatoCRMView {
    operator?: string = " AND ";
    data?: string = '';
    ip?: string = '';
}
    