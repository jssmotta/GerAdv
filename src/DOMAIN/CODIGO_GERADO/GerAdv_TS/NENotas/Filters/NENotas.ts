export interface FilterNENotas
{
    operator?: string;
    apenso?: number;
    precatoria?: number;
    instancia?: number;
 nome?: string;
    processo?: number;
    palavrachave?: number;
 data?: string;
 notapublicada?: string;
}

export class FilterNENotasDefaults implements FilterNENotas {
    operator?: string = " AND ";
    apenso?: number = -2147483648;
    precatoria?: number = -2147483648;
    instancia?: number = -2147483648;
    nome?: string = '';
    processo?: number = -2147483648;
    palavrachave?: number = -2147483648;
    data?: string = '';
    notapublicada?: string = '';
}
    