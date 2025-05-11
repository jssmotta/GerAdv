export interface FilterOperadores
{
    operator?: string;
    casaid?: number;
    casacodigo?: number;
    cliente?: number;
    grupo?: number;
 nome?: string;
 email?: string;
 senha?: string;
 senha256?: string;
 suportesenha256?: string;
 suportemaxage?: string;
}

export class FilterOperadoresDefaults implements FilterOperadores {
    operator?: string = " AND ";
    casaid?: number = -2147483648;
    casacodigo?: number = -2147483648;
    cliente?: number = -2147483648;
    grupo?: number = -2147483648;
    nome?: string = '';
    email?: string = '';
    senha?: string = '';
    senha256?: string = '';
    suportesenha256?: string = '';
    suportemaxage?: string = '';
}
    