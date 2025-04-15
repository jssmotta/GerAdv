"use client";
export interface IParteOponente {
// 202501251
    id: number;
 
		oponente: number,
		processo: number,
}

export interface IParteOponenteFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IParteOponenteIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}