export interface FilterOperadorEMailPopup
{
    operator?: string;
    operador?: number;
 nome?: string;
 senha?: string;
 smtp?: string;
 pop3?: string;
 descricao?: string;
 usuario?: string;
    portasmtp?: number;
    portapop3?: number;
 assinatura?: string;
 senha256?: string;
}

export class FilterOperadorEMailPopupDefaults implements FilterOperadorEMailPopup {
    operator?: string = " AND ";
    operador?: number = -2147483648;
    nome?: string = '';
    senha?: string = '';
    smtp?: string = '';
    pop3?: string = '';
    descricao?: string = '';
    usuario?: string = '';
    portasmtp?: number = -2147483648;
    portapop3?: number = -2147483648;
    assinatura?: string = '';
    senha256?: string = '';
}
    