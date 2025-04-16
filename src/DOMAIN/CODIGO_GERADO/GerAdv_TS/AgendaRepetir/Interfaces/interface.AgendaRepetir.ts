"use client";
export interface IAgendaRepetir {
// 202501251
    id: number;
 
		advogado: number,
		cliente: number,
		funcionario: number,
		processo: number,
		datafinal: string,
		horafinal: string,
		pessoal: boolean,
		frequencia: number,
		dia: number,
		mes: number,
		hora: string,
		idquem: number,
		idquem2: number,
		mensagem: string,
		idtipo: number,
		id1: number,
		id2: number,
		id3: number,
		id4: number,
		segunda: boolean,
		quarta: boolean,
		quinta: boolean,
		sexta: boolean,
		sabado: boolean,
		domingo: boolean,
		terca: boolean,
		auditor: undefined | null
}

export interface IAgendaRepetirFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAgendaRepetirIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}