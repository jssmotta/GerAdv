export interface FilterInstancia
{
    operator?: string;
 liminarpedida?: string;
 objeto?: string;
    statusresultado?: number;
    processo?: number;
 data?: string;
 liminarresultado?: string;
 nroprocesso?: string;
    divisao?: number;
    comarca?: number;
    subdivisao?: number;
    acao?: number;
    foro?: number;
    tiporecurso?: number;
 zkey?: string;
    zkeyquem?: number;
 zkeyquando?: string;
 nroantigo?: string;
 accesscode?: string;
    julgador?: number;
 zkeyia?: string;
 guid?: string;
}

export class FilterInstanciaDefaults implements FilterInstancia {
    operator?: string = " AND ";
    liminarpedida?: string = '';
    objeto?: string = '';
    statusresultado?: number = -2147483648;
    processo?: number = -2147483648;
    data?: string = '';
    liminarresultado?: string = '';
    nroprocesso?: string = '';
    divisao?: number = -2147483648;
    comarca?: number = -2147483648;
    subdivisao?: number = -2147483648;
    acao?: number = -2147483648;
    foro?: number = -2147483648;
    tiporecurso?: number = -2147483648;
    zkey?: string = '';
    zkeyquem?: number = -2147483648;
    zkeyquando?: string = '';
    nroantigo?: string = '';
    accesscode?: string = '';
    julgador?: number = -2147483648;
    zkeyia?: string = '';
    guid?: string = '';
}
    