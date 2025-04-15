export interface FilterProcessOutputEngine
{
    operator?: string;
 nome?: string;
 database?: string;
 tabela?: string;
 campo?: string;
 valor?: string;
 output?: string;
    outputsource?: number;
    idmodulo?: number;
    myid?: number;
}

export class FilterProcessOutputEngineDefaults implements FilterProcessOutputEngine {
    operator?: string = " AND ";
    nome?: string = '';
    database?: string = '';
    tabela?: string = '';
    campo?: string = '';
    valor?: string = '';
    output?: string = '';
    outputsource?: number = -2147483648;
    idmodulo?: number = -2147483648;
    myid?: number = -2147483648;
}
    