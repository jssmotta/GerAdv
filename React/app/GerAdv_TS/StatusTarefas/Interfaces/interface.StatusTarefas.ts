'use client';

export interface IStatusTarefas {
// 202501251
    id: number;
 
	nome: string,
}

export interface IStatusTarefasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IStatusTarefasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}