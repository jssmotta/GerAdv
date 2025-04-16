export interface FilterClientes
{
    operator?: string;
    empresa?: number;
 icone?: string;
 nomemae?: string;
 rgdataexp?: string;
 quemindicou?: string;
 nome?: string;
    adv?: number;
    idrep?: number;
 nomefantasia?: string;
 class?: string;
 dtnasc?: string;
 inscest?: string;
 qualificacao?: string;
    idade?: number;
 cnpj?: string;
 cpf?: string;
 rg?: string;
 observacao?: string;
 endereco?: string;
 bairro?: string;
    cidade?: number;
 cep?: string;
 fax?: string;
 fone?: string;
 data?: string;
 homepage?: string;
 email?: string;
 nomepai?: string;
 rgoexpeditor?: string;
    regimetributacao?: number;
    enquadramentoempresa?: number;
 cnh?: string;
 pessoacontato?: string;
}

export class FilterClientesDefaults implements FilterClientes {
    operator?: string = " AND ";
    empresa?: number = -2147483648;
    icone?: string = '';
    nomemae?: string = '';
    rgdataexp?: string = '';
    quemindicou?: string = '';
    nome?: string = '';
    adv?: number = -2147483648;
    idrep?: number = -2147483648;
    nomefantasia?: string = '';
    class?: string = '';
    dtnasc?: string = '';
    inscest?: string = '';
    qualificacao?: string = '';
    idade?: number = -2147483648;
    cnpj?: string = '';
    cpf?: string = '';
    rg?: string = '';
    observacao?: string = '';
    endereco?: string = '';
    bairro?: string = '';
    cidade?: number = -2147483648;
    cep?: string = '';
    fax?: string = '';
    fone?: string = '';
    data?: string = '';
    homepage?: string = '';
    email?: string = '';
    nomepai?: string = '';
    rgoexpeditor?: string = '';
    regimetributacao?: number = -2147483648;
    enquadramentoempresa?: number = -2147483648;
    cnh?: string = '';
    pessoacontato?: string = '';
}
    