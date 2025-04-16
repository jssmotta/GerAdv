export interface FilterGruposEmpresasCli
{
    operator?: string;
    grupo?: number;
    cliente?: number;
}

export class FilterGruposEmpresasCliDefaults implements FilterGruposEmpresasCli {
    operator?: string = " AND ";
    grupo?: number = -2147483648;
    cliente?: number = -2147483648;
}
    