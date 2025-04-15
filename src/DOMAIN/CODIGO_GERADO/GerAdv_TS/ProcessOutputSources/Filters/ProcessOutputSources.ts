export interface FilterProcessOutputSources
{
    operator?: string;
 nome?: string;
}

export class FilterProcessOutputSourcesDefaults implements FilterProcessOutputSources {
    operator?: string = " AND ";
    nome?: string = '';
}
    