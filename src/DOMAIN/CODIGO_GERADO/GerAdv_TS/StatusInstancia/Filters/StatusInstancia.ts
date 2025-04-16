export interface FilterStatusInstancia
{
    operator?: string;
 nome?: string;
}

export class FilterStatusInstanciaDefaults implements FilterStatusInstancia {
    operator?: string = " AND ";
    nome?: string = '';
}
    