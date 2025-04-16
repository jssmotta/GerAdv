export interface FilterAgendaRecords
{
    operator?: string;
    agenda?: number;
    julgador?: number;
    clientessocios?: number;
    perito?: number;
    colaborador?: number;
    foro?: number;
    crmaviso1?: number;
    crmaviso2?: number;
    crmaviso3?: number;
 dataaviso1?: string;
 dataaviso2?: string;
 dataaviso3?: string;
}

export class FilterAgendaRecordsDefaults implements FilterAgendaRecords {
    operator?: string = " AND ";
    agenda?: number = -2147483648;
    julgador?: number = -2147483648;
    clientessocios?: number = -2147483648;
    perito?: number = -2147483648;
    colaborador?: number = -2147483648;
    foro?: number = -2147483648;
    crmaviso1?: number = -2147483648;
    crmaviso2?: number = -2147483648;
    crmaviso3?: number = -2147483648;
    dataaviso1?: string = '';
    dataaviso2?: string = '';
    dataaviso3?: string = '';
}
    