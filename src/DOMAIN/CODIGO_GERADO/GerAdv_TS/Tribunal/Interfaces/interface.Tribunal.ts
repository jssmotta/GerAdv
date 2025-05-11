"use client";
export interface ITribunal {
// 202501251
    id: number;
 
		area: number,
		justica: number,
		instancia: number,
		nome: string,
		descricao: string,
		sigla: string,
		web: string,
		etiqueta: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface ITribunalFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITribunalIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}