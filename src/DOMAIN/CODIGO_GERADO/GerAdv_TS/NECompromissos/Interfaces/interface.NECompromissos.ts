'use client';

export interface INECompromissos {
// 202501251
    id: number;
 
	tipocompromisso: number,
	palavrachave: number,
	provisionar: boolean,
	textocompromisso: string,
	bold: boolean,
}

export interface INECompromissosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface INECompromissosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}