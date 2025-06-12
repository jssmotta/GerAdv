export interface FilterApenso
{
    operator?: string;
    processo?: number;
 apensox?: string;
 acao?: string;
 dtdist?: string;
 obs?: string;
    valorcausa?: number;
}

export class FilterApensoDefaults implements FilterApenso {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    apensox?: string = '';
    acao?: string = '';
    dtdist?: string = '';
    obs?: string = '';
    valorcausa?: number = -2147483648;
}
    