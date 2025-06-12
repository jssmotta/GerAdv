'use client';

export interface IOperadorGruposAgendaOperadores {
// 202501251
    id: number;
 
	operadorgruposagenda: number,
	operador: number,
}

export interface IOperadorGruposAgendaOperadoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IOperadorGruposAgendaOperadoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}