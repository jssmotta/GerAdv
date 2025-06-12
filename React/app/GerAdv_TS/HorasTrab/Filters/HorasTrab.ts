export interface FilterHorasTrab
{
    operator?: string;
    idcontatocrm?: number;
    idagenda?: number;
 data?: string;
    cliente?: number;
    status?: number;
    processo?: number;
    advogado?: number;
    funcionario?: number;
 hrini?: string;
 hrfim?: string;
    tempo?: number;
    valor?: number;
 obs?: string;
 anexo?: string;
 anexocomp?: string;
 anexounc?: string;
    servico?: number;
 guid?: string;
}

export class FilterHorasTrabDefaults implements FilterHorasTrab {
    operator?: string = ' AND ';
    idcontatocrm?: number = -2147483648;
    idagenda?: number = -2147483648;
    data?: string = '';
    cliente?: number = -2147483648;
    status?: number = -2147483648;
    processo?: number = -2147483648;
    advogado?: number = -2147483648;
    funcionario?: number = -2147483648;
    hrini?: string = '';
    hrfim?: string = '';
    tempo?: number = -2147483648;
    valor?: number = -2147483648;
    obs?: string = '';
    anexo?: string = '';
    anexocomp?: string = '';
    anexounc?: string = '';
    servico?: number = -2147483648;
    guid?: string = '';
}
    