export interface FilterAgendaRelatorio
{
    operator?: string;
 data?: string;
    processo?: number;
 paranome?: string;
 parapessoas?: string;
 boxaudiencia?: string;
 boxaudienciamobile?: string;
 nomeadvogado?: string;
 nomeforo?: string;
 nomejustica?: string;
 nomearea?: string;
}

export class FilterAgendaRelatorioDefaults implements FilterAgendaRelatorio {
    operator?: string = " AND ";
    data?: string = '';
    processo?: number = -2147483648;
    paranome?: string = '';
    parapessoas?: string = '';
    boxaudiencia?: string = '';
    boxaudienciamobile?: string = '';
    nomeadvogado?: string = '';
    nomeforo?: string = '';
    nomejustica?: string = '';
    nomearea?: string = '';
}
    