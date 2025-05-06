"use client";
export interface IAgendaSemana {
// 202501251
    id: number;
 
		funcionario: number,
		advogado: number,
		tipocompromisso: number,
		cliente: number,
		paranome: string,
		data: string,
		hora: string,
		compromisso: string,
		concluido: boolean,
		liberado: boolean,
		importante: boolean,
		horafinal: string,
		nome: string,
		nomecliente: string,
		tipo: string,
}

export interface IAgendaSemanaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAgendaSemanaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}