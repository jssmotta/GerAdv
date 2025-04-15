export interface FilterNECompromissos
{
    operator?: string;
    palavrachave?: number;
    tipocompromisso?: number;
 textocompromisso?: string;
}

export class FilterNECompromissosDefaults implements FilterNECompromissos {
    operator?: string = " AND ";
    palavrachave?: number = -2147483648;
    tipocompromisso?: number = -2147483648;
    textocompromisso?: string = '';
}
    