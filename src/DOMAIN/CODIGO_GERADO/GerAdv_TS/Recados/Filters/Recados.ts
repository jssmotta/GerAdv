export interface FilterRecados
{
    operator?: string;
 clientenome?: string;
 de?: string;
 para?: string;
 assunto?: string;
    processo?: number;
    cliente?: number;
 recado?: string;
 hora?: string;
 data?: string;
 retornodata?: string;
    emotion?: number;
    internetid?: number;
    natureza?: number;
 aguardarretornopara?: string;
    paraid?: number;
    masterid?: number;
 listapara?: string;
    assuntorecado?: number;
    historico?: number;
    contatocrm?: number;
    ligacoes?: number;
    agenda?: number;
}

export class FilterRecadosDefaults implements FilterRecados {
    operator?: string = " AND ";
    clientenome?: string = '';
    de?: string = '';
    para?: string = '';
    assunto?: string = '';
    processo?: number = -2147483648;
    cliente?: number = -2147483648;
    recado?: string = '';
    hora?: string = '';
    data?: string = '';
    retornodata?: string = '';
    emotion?: number = -2147483648;
    internetid?: number = -2147483648;
    natureza?: number = -2147483648;
    aguardarretornopara?: string = '';
    paraid?: number = -2147483648;
    masterid?: number = -2147483648;
    listapara?: string = '';
    assuntorecado?: number = -2147483648;
    historico?: number = -2147483648;
    contatocrm?: number = -2147483648;
    ligacoes?: number = -2147483648;
    agenda?: number = -2147483648;
}
    