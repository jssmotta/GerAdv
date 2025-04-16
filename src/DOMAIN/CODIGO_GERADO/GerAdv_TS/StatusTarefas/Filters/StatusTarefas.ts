export interface FilterStatusTarefas
{
    operator?: string;
 nome?: string;
}

export class FilterStatusTarefasDefaults implements FilterStatusTarefas {
    operator?: string = " AND ";
    nome?: string = '';
}
    