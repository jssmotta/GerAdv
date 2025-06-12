'use client';

export interface IAgendaRepetirDias {
// 202501251
    id: number;
 
	horafinal: string,
	master: number,
	dia: number,
	hora: string,
}

export interface IAgendaRepetirDiasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAgendaRepetirDiasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}