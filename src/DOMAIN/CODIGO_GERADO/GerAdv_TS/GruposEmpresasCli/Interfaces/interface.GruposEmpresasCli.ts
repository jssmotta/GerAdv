'use client';

export interface IGruposEmpresasCli {
// 202501251
    id: number;
 
	grupo: number,
	cliente: number,
	oculto: boolean,
}

export interface IGruposEmpresasCliFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGruposEmpresasCliIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}