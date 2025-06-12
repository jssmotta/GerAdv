'use client';

export interface IProcessos {
// 202501251
    id: number;
 
	advopo: number,
	justica: number,
	advogado: number,
	preposto: number,
	cliente: number,
	oponente: number,
	area: number,
	cidade: number,
	situacao: number,
	rito: number,
	atividade: number,
	advparc: number,
	ajgpedidonegado: boolean,
	ajgcliente: boolean,
	ajgpedidonegadoopo: boolean,
	notificarpoe: boolean,
	valorprovisionado: number,
	ajgoponente: boolean,
	valorcachecalculo: number,
	ajgpedidoopo: boolean,
	valorcachecalculoprov: number,
	considerarparado: boolean,
	valorcalculado: boolean,
	ajgconcedidoopo: boolean,
	cobranca: boolean,
	dataentrada: string,
	penhora: boolean,
	ajgpedido: boolean,
	tipobaixa: number,
	classrisco: number,
	isapenso: boolean,
	valorcausainicial: number,
	ajgconcedido: boolean,
	obsbcx: string,
	valorcausadefinitivo: number,
	percprobexito: number,
	mna: boolean,
	percexito: number,
	nroextra: string,
	extra: boolean,
	nrocaixa: string,
	idsituacao: boolean,
	valor: number,
	fato: string,
	nropasta: string,
	caixamorto: string,
	baixado: boolean,
	dtbaixa: string,
	motivobaixa: string,
	obs: string,
	printed: boolean,
	zkey: string,
	zkeyquem: number,
	zkeyquando: string,
	resumo: string,
	naoimprimir: boolean,
	eletronico: boolean,
	nrocontrato: string,
	percprobexitojustificativa: string,
	honorariovalor: number,
	honorariopercentual: number,
	honorariosucumbencia: number,
	faseauditoria: number,
	valorcondenacao: number,
	valorcondenacaocalculado: number,
	valorcondenacaoprovisorio: number,
}

export interface IProcessosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProcessosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}