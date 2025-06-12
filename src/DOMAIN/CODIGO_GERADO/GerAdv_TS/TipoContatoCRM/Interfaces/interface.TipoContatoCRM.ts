'use client';

export interface ITipoContatoCRM {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface ITipoContatoCRMFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoContatoCRMIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}