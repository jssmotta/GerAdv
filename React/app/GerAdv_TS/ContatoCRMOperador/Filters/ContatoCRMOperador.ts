export interface FilterContatoCRMOperador
{
    operator?: string;
    contatocrm?: number;
    cargoesc?: number;
    operador?: number;
}

export class FilterContatoCRMOperadorDefaults implements FilterContatoCRMOperador {
    operator?: string = ' AND ';
    contatocrm?: number = -2147483648;
    cargoesc?: number = -2147483648;
    operador?: number = -2147483648;
}
    