export interface FilterStatusInstancia
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterStatusInstanciaDefaults implements FilterStatusInstancia {
    operator?: string = ' AND ';
    nome?: string = '';
    guid?: string = '';
}
    