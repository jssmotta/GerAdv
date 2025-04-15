export interface FilterPrecatoria
{
    operator?: string;
 dtdist?: string;
    processo?: number;
 precatoriax?: string;
 deprecante?: string;
 deprecado?: string;
 obs?: string;
}

export class FilterPrecatoriaDefaults implements FilterPrecatoria {
    operator?: string = " AND ";
    dtdist?: string = '';
    processo?: number = -2147483648;
    precatoriax?: string = '';
    deprecante?: string = '';
    deprecado?: string = '';
    obs?: string = '';
}
    