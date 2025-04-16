export interface FilterHonorariosDadosContrato
{
    operator?: string;
    cliente?: number;
    percsucesso?: number;
    processo?: number;
 arquivocontrato?: string;
 textocontrato?: string;
    valorfixo?: number;
 observacao?: string;
 datacontrato?: string;
}

export class FilterHonorariosDadosContratoDefaults implements FilterHonorariosDadosContrato {
    operator?: string = " AND ";
    cliente?: number = -2147483648;
    percsucesso?: number = -2147483648;
    processo?: number = -2147483648;
    arquivocontrato?: string = '';
    textocontrato?: string = '';
    valorfixo?: number = -2147483648;
    observacao?: string = '';
    datacontrato?: string = '';
}
    