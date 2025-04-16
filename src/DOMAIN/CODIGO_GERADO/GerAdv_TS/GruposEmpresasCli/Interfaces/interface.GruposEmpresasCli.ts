"use client";
export interface IGruposEmpresasCli {
// 202501251
    id: number;
 
		grupo: number,
		cliente: number,
		oculto: boolean,
		auditor: undefined | null
}

export interface IGruposEmpresasCliFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IGruposEmpresasCliIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}