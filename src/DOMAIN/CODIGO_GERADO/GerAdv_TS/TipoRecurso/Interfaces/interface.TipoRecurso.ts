"use client";
export interface ITipoRecurso {
// 202501251
    id: number;
 
		justica: number,
		area: number,
		descricao: string,
		auditor: undefined | null
}

export interface ITipoRecursoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoRecursoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}