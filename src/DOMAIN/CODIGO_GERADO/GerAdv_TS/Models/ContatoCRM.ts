import { Auditor } from "./Auditor";

import { IContatoCRM } from "../ContatoCRM/Interfaces/interface.ContatoCRM";
export interface ContatoCRM
{
    id: number;
	operador : number;
	cliente : number;
	processo : number;
	tipocontatocrm : number;
	ageclienteavisado : number;
	docsviarecebimento : number;
	naopublicavel : boolean;
	notificar : boolean;
	ocultar : boolean;
	assunto : string;
	isdocsrecebidos : boolean;
	quemnotificou : number;
	datanotificou : string;
	horanotificou : string;
	objetonotificou : number;
	pessoacontato : string;
	data : string;
	tempo : number;
	horainicial : string;
	horafinal : string;
	importante : boolean;
	urgente : boolean;
	gerarhoratrabalhada : boolean;
	exibirnotopo : boolean;
	contato : string;
	emocao : number;
	continuar : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ContatoCRMEmpty(): IContatoCRM {
// 20250125
    return {
        id: 0,
		operador: 0,
		cliente: 0,
		processo: 0,
		tipocontatocrm: 0,
		ageclienteavisado: 0,
		docsviarecebimento: 0,
		naopublicavel: false,
		notificar: false,
		ocultar: false,
		assunto: '',
		isdocsrecebidos: false,
		quemnotificou: 0,
		datanotificou: '',
		horanotificou: '',
		objetonotificou: 0,
		pessoacontato: '',
		data: '',
		tempo: 0,
		horainicial: '',
		horafinal: '',
		importante: false,
		urgente: false,
		gerarhoratrabalhada: false,
		exibirnotopo: false,
		contato: '',
		emocao: 0,
		continuar: false,
		bold: false,
		auditor: null
    };
}
