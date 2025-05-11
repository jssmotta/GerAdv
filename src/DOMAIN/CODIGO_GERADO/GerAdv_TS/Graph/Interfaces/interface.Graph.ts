"use client";
export interface IGraph {
// 202501251
    id: number;
 
		tabela: string,
		tabelaid: number,
		imagem: Uint8Array,
		auditor: undefined | null
}

export interface IGraphFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IGraphIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}