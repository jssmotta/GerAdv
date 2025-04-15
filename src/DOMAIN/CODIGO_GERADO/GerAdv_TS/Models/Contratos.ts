import { Auditor } from "./Auditor";

import { IContratos } from "../Contratos/Interfaces/interface.Contratos";
export interface Contratos
{
    id: number;
	processo : number;
	cliente : number;
	advogado : number;
	dia : number;
	valor : number;
	datainicio : string;
	datatermino : string;
	ocultarrelatorio : boolean;
	percescritorio : number;
	valorconsultoria : number;
	tipocobranca : number;
	protestar : string;
	juros : string;
	valorrealizavel : number;
	documento : string;
	email1 : string;
	email2 : string;
	email3 : string;
	pessoa1 : string;
	pessoa2 : string;
	pessoa3 : string;
	obs : string;
	clientecontrato : number;
	idextrangeiro : number;
	chavecontrato : string;
	avulso : boolean;
	suspenso : boolean;
	multa : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ContratosEmpty(): IContratos {
// 20250125
    return {
        id: 0,
		processo: 0,
		cliente: 0,
		advogado: 0,
		dia: 0,
		valor: 0,
		datainicio: '',
		datatermino: '',
		ocultarrelatorio: false,
		percescritorio: 0,
		valorconsultoria: 0,
		tipocobranca: 0,
		protestar: '',
		juros: '',
		valorrealizavel: 0,
		documento: '',
		email1: '',
		email2: '',
		email3: '',
		pessoa1: '',
		pessoa2: '',
		pessoa3: '',
		obs: '',
		clientecontrato: 0,
		idextrangeiro: 0,
		chavecontrato: '',
		avulso: false,
		suspenso: false,
		multa: '',
		bold: false,
		auditor: null
    };
}
