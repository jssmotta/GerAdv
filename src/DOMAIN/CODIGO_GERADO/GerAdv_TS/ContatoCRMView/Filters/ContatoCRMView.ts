export interface FilterContatoCRMView
{
    operator?: string;
 guid?: string;
 data?: string;
 ip?: string;
}

export class FilterContatoCRMViewDefaults implements FilterContatoCRMView {
    operator?: string = " AND ";
    guid?: string = '';
    data?: string = '';
    ip?: string = '';
}
    