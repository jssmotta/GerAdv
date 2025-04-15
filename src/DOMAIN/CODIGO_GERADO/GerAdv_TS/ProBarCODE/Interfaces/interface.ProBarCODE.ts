"use client";
export interface IProBarCODE {
// 202501251
    id: number;
 
		processo: number,
		barcode: string,
		auditor: undefined | null
}

export interface IProBarCODEFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProBarCODEIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}