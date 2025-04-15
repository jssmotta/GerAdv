export interface FilterEMPClassRiscos
{
    operator?: string;
 nome?: string;
}

export class FilterEMPClassRiscosDefaults implements FilterEMPClassRiscos {
    operator?: string = " AND ";
    nome?: string = '';
}
    