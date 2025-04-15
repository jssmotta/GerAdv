export interface FilterColaboradores
{
    operator?: string;
    cargo?: number;
    cliente?: number;
 nome?: string;
 cpf?: string;
 rg?: string;
 dtnasc?: string;
    idade?: number;
 endereco?: string;
 bairro?: string;
 cep?: string;
    cidade?: number;
 fone?: string;
 observacao?: string;
 email?: string;
 cnh?: string;
 class?: string;
}

export class FilterColaboradoresDefaults implements FilterColaboradores {
    operator?: string = " AND ";
    cargo?: number = -2147483648;
    cliente?: number = -2147483648;
    nome?: string = '';
    cpf?: string = '';
    rg?: string = '';
    dtnasc?: string = '';
    idade?: number = -2147483648;
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    cidade?: number = -2147483648;
    fone?: string = '';
    observacao?: string = '';
    email?: string = '';
    cnh?: string = '';
    class?: string = '';
}
    