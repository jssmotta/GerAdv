'use client';

export interface ITipoProDesposito {
// 202501251
    id: number;
 
	nome: string,
}

export interface ITipoProDespositoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoProDespositoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}