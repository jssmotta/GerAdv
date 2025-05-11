"use client";
export interface IAndComp {
// 202501251
    id: number;
 
		andamento: number,
		compromisso: number,
}

export interface IAndCompFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAndCompIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}