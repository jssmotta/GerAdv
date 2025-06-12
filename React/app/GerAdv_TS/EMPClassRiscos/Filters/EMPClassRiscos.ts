export interface FilterEMPClassRiscos
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterEMPClassRiscosDefaults implements FilterEMPClassRiscos {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    