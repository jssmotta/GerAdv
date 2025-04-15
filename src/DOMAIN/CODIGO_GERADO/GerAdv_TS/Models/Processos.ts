import { Auditor } from "./Auditor";

import { IProcessos } from "../Processos/Interfaces/interface.Processos";
export interface Processos
{
    id: number;
	advopo : number;
	justica : number;
	advogado : number;
	preposto : number;
	cliente : number;
	oponente : number;
	area : number;
	cidade : number;
	situacao : number;
	rito : number;
	atividade : number;
	advparc : number;
	ajgpedidonegado : boolean;
	ajgcliente : boolean;
	ajgpedidonegadoopo : boolean;
	notificarpoe : boolean;
	valorprovisionado : number;
	ajgoponente : boolean;
	valorcachecalculo : number;
	ajgpedidoopo : boolean;
	valorcachecalculoprov : number;
	considerarparado : boolean;
	valorcalculado : boolean;
	ajgconcedidoopo : boolean;
	cobranca : boolean;
	dataentrada : string;
	penhora : boolean;
	ajgpedido : boolean;
	tipobaixa : number;
	classrisco : number;
	isapenso : boolean;
	valorcausainicial : number;
	ajgconcedido : boolean;
	obsbcx : string;
	valorcausadefinitivo : number;
	percprobexito : number;
	mna : boolean;
	percexito : number;
	nroextra : string;
	extra : boolean;
	nrocaixa : string;
	idsituacao : boolean;
	valor : number;
	fato : string;
	nropasta : string;
	caixamorto : string;
	baixado : boolean;
	dtbaixa : string;
	motivobaixa : string;
	obs : string;
	printed : boolean;
	zkey : string;
	zkeyquem : number;
	zkeyquando : string;
	resumo : string;
	naoimprimir : boolean;
	eletronico : boolean;
	nrocontrato : string;
	percprobexitojustificativa : string;
	honorariovalor : number;
	honorariopercentual : number;
	honorariosucumbencia : number;
	faseauditoria : number;
	valorcondenacao : number;
	valorcondenacaocalculado : number;
	valorcondenacaoprovisorio : number;
	auditor?: Auditor | null;
}

export function ProcessosEmpty(): IProcessos {
// 20250125
    return {
        id: 0,
		advopo: 0,
		justica: 0,
		advogado: 0,
		preposto: 0,
		cliente: 0,
		oponente: 0,
		area: 0,
		cidade: 0,
		situacao: 0,
		rito: 0,
		atividade: 0,
		advparc: 0,
		ajgpedidonegado: false,
		ajgcliente: false,
		ajgpedidonegadoopo: false,
		notificarpoe: false,
		valorprovisionado: 0,
		ajgoponente: false,
		valorcachecalculo: 0,
		ajgpedidoopo: false,
		valorcachecalculoprov: 0,
		considerarparado: false,
		valorcalculado: false,
		ajgconcedidoopo: false,
		cobranca: false,
		dataentrada: '',
		penhora: false,
		ajgpedido: false,
		tipobaixa: 0,
		classrisco: 0,
		isapenso: false,
		valorcausainicial: 0,
		ajgconcedido: false,
		obsbcx: '',
		valorcausadefinitivo: 0,
		percprobexito: 0,
		mna: false,
		percexito: 0,
		nroextra: '',
		extra: false,
		nrocaixa: '',
		idsituacao: false,
		valor: 0,
		fato: '',
		nropasta: '',
		caixamorto: '',
		baixado: false,
		dtbaixa: '',
		motivobaixa: '',
		obs: '',
		printed: false,
		zkey: '',
		zkeyquem: 0,
		zkeyquando: '',
		resumo: '',
		naoimprimir: false,
		eletronico: false,
		nrocontrato: '',
		percprobexitojustificativa: '',
		honorariovalor: 0,
		honorariopercentual: 0,
		honorariosucumbencia: 0,
		faseauditoria: 0,
		valorcondenacao: 0,
		valorcondenacaocalculado: 0,
		valorcondenacaoprovisorio: 0,
		auditor: null
    };
}
