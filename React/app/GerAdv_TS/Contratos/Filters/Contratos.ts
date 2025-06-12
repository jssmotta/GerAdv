export interface FilterContratos
{
    operator?: string;
    processo?: number;
    cliente?: number;
    advogado?: number;
    dia?: number;
    valor?: number;
 datainicio?: string;
 datatermino?: string;
    percescritorio?: number;
    valorconsultoria?: number;
    tipocobranca?: number;
 protestar?: string;
 juros?: string;
    valorrealizavel?: number;
 documento?: string;
 email1?: string;
 email2?: string;
 email3?: string;
 pessoa1?: string;
 pessoa2?: string;
 pessoa3?: string;
 obs?: string;
    clientecontrato?: number;
    idextrangeiro?: number;
 chavecontrato?: string;
 multa?: string;
 guid?: string;
}

export class FilterContratosDefaults implements FilterContratos {
    operator?: string = ' AND ';
    processo?: number = -2147483648;
    cliente?: number = -2147483648;
    advogado?: number = -2147483648;
    dia?: number = -2147483648;
    valor?: number = -2147483648;
    datainicio?: string = '';
    datatermino?: string = '';
    percescritorio?: number = -2147483648;
    valorconsultoria?: number = -2147483648;
    tipocobranca?: number = -2147483648;
    protestar?: string = '';
    juros?: string = '';
    valorrealizavel?: number = -2147483648;
    documento?: string = '';
    email1?: string = '';
    email2?: string = '';
    email3?: string = '';
    pessoa1?: string = '';
    pessoa2?: string = '';
    pessoa3?: string = '';
    obs?: string = '';
    clientecontrato?: number = -2147483648;
    idextrangeiro?: number = -2147483648;
    chavecontrato?: string = '';
    multa?: string = '';
    guid?: string = '';
}
    