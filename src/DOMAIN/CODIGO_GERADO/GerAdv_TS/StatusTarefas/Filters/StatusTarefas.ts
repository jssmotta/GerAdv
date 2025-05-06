export interface FilterStatusTarefas
{
    operator?: string;
 nome?: string;
 guid?: string;
}

export class FilterStatusTarefasDefaults implements FilterStatusTarefas {
    operator?: string = " AND ";
    nome?: string = '';
    guid?: string = '';
}
    