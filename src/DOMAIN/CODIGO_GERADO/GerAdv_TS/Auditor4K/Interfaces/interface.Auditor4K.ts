"use client";
export interface IAuditor4K {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IAuditor4KFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAuditor4KIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}