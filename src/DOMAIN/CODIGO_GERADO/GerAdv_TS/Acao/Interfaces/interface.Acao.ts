"use client";
export interface IAcao {
// 202501251
    id: number;
 
		justica: number,
		area: number,
		descricao: string,
		auditor: undefined | null
}

export interface IAcaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAcaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}