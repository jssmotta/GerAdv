"use client";
export interface IPenhoraStatus {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IPenhoraStatusFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IPenhoraStatusIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}