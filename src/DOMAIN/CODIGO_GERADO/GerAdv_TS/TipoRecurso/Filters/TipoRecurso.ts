export interface FilterTipoRecurso
{
    operator?: string;
    justica?: number;
    area?: number;
 descricao?: string;
}

export class FilterTipoRecursoDefaults implements FilterTipoRecurso {
    operator?: string = " AND ";
    justica?: number = -2147483648;
    area?: number = -2147483648;
    descricao?: string = '';
}
    