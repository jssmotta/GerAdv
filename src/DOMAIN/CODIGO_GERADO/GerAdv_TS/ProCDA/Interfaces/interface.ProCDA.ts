"use client";
export interface IProCDA {
// 202501251
    id: number;
 
		processo: number,
		nome: string,
		nrointerno: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IProCDAFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProCDAIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}