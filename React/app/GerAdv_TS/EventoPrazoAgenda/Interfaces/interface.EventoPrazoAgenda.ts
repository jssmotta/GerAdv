'use client';

export interface IEventoPrazoAgenda {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface IEventoPrazoAgendaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IEventoPrazoAgendaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}