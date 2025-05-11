"use client";
export interface IProcessOutputRequest {
// 202501251
    id: number;
 
		processoutputengine: number,
		operador: number,
		processo: number,
		ultimoidtabelaexo: number,
		auditor: undefined | null
}

export interface IProcessOutputRequestFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProcessOutputRequestIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}