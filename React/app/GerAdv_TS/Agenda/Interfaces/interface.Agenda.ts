'use client';

export interface IAgenda {
// 202501251
    id: number;
 
	cidade: number,
	advogado: number,
	funcionario: number,
	tipocompromisso: number,
	cliente: number,
	area: number,
	justica: number,
	processo: number,
	usuario: number,
	preposto: number,
	idcob: number,
	clienteavisado: boolean,
	revisarp2: boolean,
	idne: number,
	oculto: number,
	cartaprecatoria: number,
	revisar: boolean,
	hrfinal: string,
	eventogerador: number,
	eventodata: string,
	data: string,
	eventoprazo: number,
	hora: string,
	compromisso: string,
	liberado: boolean,
	importante: boolean,
	concluido: boolean,
	idhistorico: number,
	idinsprocesso: number,
	quemid: number,
	quemcodigo: number,
	status: string,
	valor: number,
	decisao: string,
	sempre: number,
	prazodias: number,
	protocolointegrado: number,
	datainicioprazo: string,
	usuariociente: boolean,
}

export interface IAgendaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAgendaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}