export interface FilterDocsRecebidosItens
{
    operator?: string;
    contatocrm?: number;
 nome?: string;
 observacoes?: string;
 guid?: string;
}

export class FilterDocsRecebidosItensDefaults implements FilterDocsRecebidosItens {
    operator?: string = ' AND ';
    contatocrm?: number = -2147483648;
    nome?: string = '';
    observacoes?: string = '';
    guid?: string = '';
}
    