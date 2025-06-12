export interface FilterBensMateriais
{
    operator?: string;
 nome?: string;
    bensclassificacao?: number;
 datacompra?: string;
 datafimdagarantia?: string;
 nfnro?: string;
    fornecedor?: number;
    valorbem?: number;
 nroserieproduto?: string;
 comprador?: string;
    cidade?: number;
 dataterminodagarantiadaloja?: string;
 observacoes?: string;
 nomevendedor?: string;
 guid?: string;
}

export class FilterBensMateriaisDefaults implements FilterBensMateriais {
    operator?: string = ' AND ';
    nome?: string = '';
    bensclassificacao?: number = -2147483648;
    datacompra?: string = '';
    datafimdagarantia?: string = '';
    nfnro?: string = '';
    fornecedor?: number = -2147483648;
    valorbem?: number = -2147483648;
    nroserieproduto?: string = '';
    comprador?: string = '';
    cidade?: number = -2147483648;
    dataterminodagarantiadaloja?: string = '';
    observacoes?: string = '';
    nomevendedor?: string = '';
    guid?: string = '';
}
    