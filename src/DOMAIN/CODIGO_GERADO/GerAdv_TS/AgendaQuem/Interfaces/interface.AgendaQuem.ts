"use client";
export interface IAgendaQuem {
// 202501251
    id: number;
 
		advogado: number,
		funcionario: number,
		preposto: number,
		idagenda: number,
}

export interface IAgendaQuemFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAgendaQuemIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}