export interface FilterTipoOrigemSucumbencia
{
    operator?: string;
 nome?: string;
}

export class FilterTipoOrigemSucumbenciaDefaults implements FilterTipoOrigemSucumbencia {
    operator?: string = ' AND ';
    nome?: string = '';
}
    