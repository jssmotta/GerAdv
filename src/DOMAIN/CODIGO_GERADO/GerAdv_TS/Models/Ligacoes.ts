import { Auditor } from "./Auditor";

import { ILigacoes } from "../Ligacoes/Interfaces/interface.Ligacoes";
export interface Ligacoes
{
    id: number;
	cliente : number;
	ramal : number;
	processo : number;
	assunto : string;
	ageclienteavisado : number;
	celular : boolean;
	contato : string;
	datarealizada : string;
	quemid : number;
	telefonista : number;
	ultimoaviso : string;
	horafinal : string;
	nome : string;
	quemcodigo : number;
	solicitante : number;
	para : string;
	fone : string;
	particular : boolean;
	realizada : boolean;
	status : string;
	data : string;
	hora : string;
	urgente : boolean;
	ligarpara : string;
	startscreen : boolean;
	emotion : number;
	bold : boolean;
	auditor?: Auditor | null;
}

export function LigacoesEmpty(): ILigacoes {
// 20250125
    return {
        id: 0,
		cliente: 0,
		ramal: 0,
		processo: 0,
		assunto: '',
		ageclienteavisado: 0,
		celular: false,
		contato: '',
		datarealizada: '',
		quemid: 0,
		telefonista: 0,
		ultimoaviso: '',
		horafinal: '',
		nome: '',
		quemcodigo: 0,
		solicitante: 0,
		para: '',
		fone: '',
		particular: false,
		realizada: false,
		status: '',
		data: '',
		hora: '',
		urgente: false,
		ligarpara: '',
		startscreen: false,
		emotion: 0,
		bold: false,
		auditor: null
    };
}
