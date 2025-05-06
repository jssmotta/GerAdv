"use client";
export interface ISetor {
// 202501251
    id: number;
 
		descricao: string,
		auditor: undefined | null
}

export interface ISetorFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ISetorIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}