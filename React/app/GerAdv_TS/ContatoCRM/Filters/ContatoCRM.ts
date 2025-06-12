export interface FilterContatoCRM
{
    operator?: string;
    ageclienteavisado?: number;
    docsviarecebimento?: number;
 assunto?: string;
    quemnotificou?: number;
 datanotificou?: string;
    operador?: number;
    cliente?: number;
 horanotificou?: string;
    objetonotificou?: number;
 pessoacontato?: string;
 data?: string;
    tempo?: number;
 horainicial?: string;
 horafinal?: string;
    processo?: number;
    tipocontatocrm?: number;
 contato?: string;
    emocao?: number;
 guid?: string;
}

export class FilterContatoCRMDefaults implements FilterContatoCRM {
    operator?: string = ' AND ';
    ageclienteavisado?: number = -2147483648;
    docsviarecebimento?: number = -2147483648;
    assunto?: string = '';
    quemnotificou?: number = -2147483648;
    datanotificou?: string = '';
    operador?: number = -2147483648;
    cliente?: number = -2147483648;
    horanotificou?: string = '';
    objetonotificou?: number = -2147483648;
    pessoacontato?: string = '';
    data?: string = '';
    tempo?: number = -2147483648;
    horainicial?: string = '';
    horafinal?: string = '';
    processo?: number = -2147483648;
    tipocontatocrm?: number = -2147483648;
    contato?: string = '';
    emocao?: number = -2147483648;
    guid?: string = '';
}
    