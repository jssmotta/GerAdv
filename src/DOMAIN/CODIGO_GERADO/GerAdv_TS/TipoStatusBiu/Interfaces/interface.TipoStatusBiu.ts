"use client";
export interface ITipoStatusBiu {
// 202501251
    id: number;
 
		nome: string,
}

export interface ITipoStatusBiuFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoStatusBiuIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}