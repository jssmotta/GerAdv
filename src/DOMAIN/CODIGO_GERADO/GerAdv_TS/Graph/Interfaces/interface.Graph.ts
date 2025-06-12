'use client';

export interface IGraph {
// 202501251
    id: number;
 
	tabela: string,
	tabelaid: number,
	imagem: Uint8Array,
}

export interface IGraphFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGraphIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}