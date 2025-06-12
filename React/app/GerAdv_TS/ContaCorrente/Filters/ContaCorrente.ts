export interface FilterContaCorrente
{
    operator?: string;
    ciacordo?: number;
    idcontrato?: number;
    quitadoid?: number;
    debitoid?: number;
    livrocaixaid?: number;
 dtoriginal?: string;
    processo?: number;
    parcelax?: number;
    valor?: number;
 data?: string;
    cliente?: number;
 historico?: string;
    idhtrab?: number;
    nroparcelas?: number;
    valorprincipal?: number;
    parcelaprincipalid?: number;
 datapgto?: string;
 guid?: string;
}

export class FilterContaCorrenteDefaults implements FilterContaCorrente {
    operator?: string = ' AND ';
    ciacordo?: number = -2147483648;
    idcontrato?: number = -2147483648;
    quitadoid?: number = -2147483648;
    debitoid?: number = -2147483648;
    livrocaixaid?: number = -2147483648;
    dtoriginal?: string = '';
    processo?: number = -2147483648;
    parcelax?: number = -2147483648;
    valor?: number = -2147483648;
    data?: string = '';
    cliente?: number = -2147483648;
    historico?: string = '';
    idhtrab?: number = -2147483648;
    nroparcelas?: number = -2147483648;
    valorprincipal?: number = -2147483648;
    parcelaprincipalid?: number = -2147483648;
    datapgto?: string = '';
    guid?: string = '';
}
    