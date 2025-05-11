"use client";
export interface IHistorico {
// 202501251
    id: number;
 
		processo: number,
		precatoria: number,
		apenso: number,
		fase: number,
		statusandamento: number,
		extraid: number,
		idne: number,
		extraguid: string,
		liminarorigem: number,
		naopublicavel: boolean,
		idinstprocesso: number,
		data: string,
		observacao: string,
		agendado: boolean,
		concluido: boolean,
		mesmaagenda: boolean,
		sad: number,
		resumido: boolean,
		top: boolean,
		auditor: undefined | null
}

export interface IHistoricoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IHistoricoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}