export interface FilterGruposEmpresas
{
    operator?: string;
 email?: string;
    oponente?: number;
 descricao?: string;
 observacoes?: string;
    cliente?: number;
 icone?: string;
 guid?: string;
}

export class FilterGruposEmpresasDefaults implements FilterGruposEmpresas {
    operator?: string = ' AND ';
    email?: string = '';
    oponente?: number = -2147483648;
    descricao?: string = '';
    observacoes?: string = '';
    cliente?: number = -2147483648;
    icone?: string = '';
    guid?: string = '';
}
    