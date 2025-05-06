export interface FilterClientesSocios
{
    operator?: string;
    idade?: number;
 qualificacao?: string;
 dtnasc?: string;
 nome?: string;
 site?: string;
 representantelegal?: string;
    cliente?: number;
 endereco?: string;
 bairro?: string;
 cep?: string;
    cidade?: number;
 rg?: string;
 cpf?: string;
 fone?: string;
 participacao?: string;
 cargo?: string;
 email?: string;
 obs?: string;
 cnh?: string;
 datacontrato?: string;
 cnpj?: string;
 inscest?: string;
 socioempresaadminnome?: string;
 enderecosocio?: string;
 bairrosocio?: string;
 cepsocio?: string;
    cidadesocio?: number;
 rgdataexp?: string;
 fax?: string;
 class?: string;
 guid?: string;
}

export class FilterClientesSociosDefaults implements FilterClientesSocios {
    operator?: string = " AND ";
    idade?: number = -2147483648;
    qualificacao?: string = '';
    dtnasc?: string = '';
    nome?: string = '';
    site?: string = '';
    representantelegal?: string = '';
    cliente?: number = -2147483648;
    endereco?: string = '';
    bairro?: string = '';
    cep?: string = '';
    cidade?: number = -2147483648;
    rg?: string = '';
    cpf?: string = '';
    fone?: string = '';
    participacao?: string = '';
    cargo?: string = '';
    email?: string = '';
    obs?: string = '';
    cnh?: string = '';
    datacontrato?: string = '';
    cnpj?: string = '';
    inscest?: string = '';
    socioempresaadminnome?: string = '';
    enderecosocio?: string = '';
    bairrosocio?: string = '';
    cepsocio?: string = '';
    cidadesocio?: number = -2147483648;
    rgdataexp?: string = '';
    fax?: string = '';
    class?: string = '';
    guid?: string = '';
}
    