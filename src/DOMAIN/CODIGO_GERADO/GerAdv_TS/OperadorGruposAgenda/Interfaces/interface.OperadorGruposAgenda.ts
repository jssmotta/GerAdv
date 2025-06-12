'use client';

export interface IOperadorGruposAgenda {
// 202501251
    id: number;
 
	operador: number,
	sqlwhere: string,
	nome: string,
}

export interface IOperadorGruposAgendaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IOperadorGruposAgendaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}