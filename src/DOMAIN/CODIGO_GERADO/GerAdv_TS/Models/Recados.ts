﻿import { Auditor } from "./Auditor";

import { IRecados } from "../Recados/Interfaces/interface.Recados";
export interface Recados
{
    id: number;
	processo : number;
	cliente : number;
	historico : number;
	contatocrm : number;
	ligacoes : number;
	agenda : number;
	clientenome : string;
	de : string;
	para : string;
	assunto : string;
	concluido : boolean;
	recado : string;
	urgente : boolean;
	importante : boolean;
	hora : string;
	data : string;
	voltara : boolean;
	pessoal : boolean;
	retornar : boolean;
	retornodata : string;
	emotion : number;
	internetid : number;
	uploaded : boolean;
	natureza : number;
	biu : boolean;
	aguardarretorno : boolean;
	aguardarretornopara : string;
	aguardarretornook : boolean;
	paraid : number;
	naopublicavel : boolean;
	iscontatocrm : boolean;
	masterid : number;
	listapara : string;
	typed : boolean;
	assuntorecado : number;
	auditor?: Auditor | null;
}

export function RecadosEmpty(): IRecados {
// 20250125
    return {
        id: 0,
		processo: 0,
		cliente: 0,
		historico: 0,
		contatocrm: 0,
		ligacoes: 0,
		agenda: 0,
		clientenome: '',
		de: '',
		para: '',
		assunto: '',
		concluido: false,
		recado: '',
		urgente: false,
		importante: false,
		hora: '',
		data: '',
		voltara: false,
		pessoal: false,
		retornar: false,
		retornodata: '',
		emotion: 0,
		internetid: 0,
		uploaded: false,
		natureza: 0,
		biu: false,
		aguardarretorno: false,
		aguardarretornopara: '',
		aguardarretornook: false,
		paraid: 0,
		naopublicavel: false,
		iscontatocrm: false,
		masterid: 0,
		listapara: '',
		typed: false,
		assuntorecado: 0,
		auditor: null
    };
}
