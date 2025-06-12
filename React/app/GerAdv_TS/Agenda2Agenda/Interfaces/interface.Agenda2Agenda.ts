'use client';

export interface IAgenda2Agenda {
// 202501251
    id: number;
 
	agenda: number,
	master: number,
}

export interface IAgenda2AgendaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAgenda2AgendaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}