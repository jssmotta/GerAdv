export interface FilterSMSAlice
{
    operator?: string;
    operador?: number;
 nome?: string;
    tipoemail?: number;
 guid?: string;
}

export class FilterSMSAliceDefaults implements FilterSMSAlice {
    operator?: string = ' AND ';
    operador?: number = -2147483648;
    nome?: string = '';
    tipoemail?: number = -2147483648;
    guid?: string = '';
}
    