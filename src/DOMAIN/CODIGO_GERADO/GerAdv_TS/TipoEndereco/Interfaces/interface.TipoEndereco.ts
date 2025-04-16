"use client";
export interface ITipoEndereco {
// 202501251
    id: number;
 
		descricao: string,
		auditor: undefined | null
}

export interface ITipoEnderecoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoEnderecoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}