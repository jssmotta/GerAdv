"use client";
export interface IGUTMatriz {
// 202501251
    id: number;
 
		guttipo: number,
		descricao: string,
		valor: number,
}

export interface IGUTMatrizFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IGUTMatrizIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}