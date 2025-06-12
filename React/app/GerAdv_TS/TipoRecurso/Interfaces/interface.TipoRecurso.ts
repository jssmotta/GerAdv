'use client';

export interface ITipoRecurso {
// 202501251
    id: number;
 
	justica: number,
	area: number,
	descricao: string,
}

export interface ITipoRecursoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoRecursoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}