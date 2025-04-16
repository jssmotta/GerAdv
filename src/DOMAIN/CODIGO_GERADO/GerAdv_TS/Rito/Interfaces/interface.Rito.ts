"use client";
export interface IRito {
// 202501251
    id: number;
 
		descricao: string,
		top: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IRitoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IRitoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}