export interface FilterProcessOutputSources
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterProcessOutputSourcesDefaults implements FilterProcessOutputSources {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    