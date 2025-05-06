import { Auditor } from "./Auditor";

import { IContaCorrente } from "../ContaCorrente/Interfaces/interface.ContaCorrente";
export interface ContaCorrente
{
    id: number;
	processo : number;
	cliente : number;
	ciacordo : number;
	quitado : boolean;
	idcontrato : number;
	quitadoid : number;
	debitoid : number;
	livrocaixaid : number;
	sucumbencia : boolean;
	distregra : boolean;
	dtoriginal : string;
	parcelax : number;
	valor : number;
	data : string;
	historico : string;
	contrato : boolean;
	pago : boolean;
	distribuir : boolean;
	lc : boolean;
	idhtrab : number;
	nroparcelas : number;
	valorprincipal : number;
	parcelaprincipalid : number;
	hide : boolean;
	datapgto : string;
	auditor?: Auditor | null;
}

export function ContaCorrenteEmpty(): IContaCorrente {
// 20250125
    return {
        id: 0,
		processo: 0,
		cliente: 0,
		ciacordo: 0,
		quitado: false,
		idcontrato: 0,
		quitadoid: 0,
		debitoid: 0,
		livrocaixaid: 0,
		sucumbencia: false,
		distregra: false,
		dtoriginal: '',
		parcelax: 0,
		valor: 0,
		data: '',
		historico: '',
		contrato: false,
		pago: false,
		distribuir: false,
		lc: false,
		idhtrab: 0,
		nroparcelas: 0,
		valorprincipal: 0,
		parcelaprincipalid: 0,
		hide: false,
		datapgto: '',
		auditor: null
    };
}
