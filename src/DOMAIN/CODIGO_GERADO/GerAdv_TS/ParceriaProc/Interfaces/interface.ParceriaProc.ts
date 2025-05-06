"use client";
export interface IParceriaProc {
// 202501251
    id: number;
 
		advogado: number,
		processo: number,
		auditor: undefined | null
}

export interface IParceriaProcFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IParceriaProcIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}