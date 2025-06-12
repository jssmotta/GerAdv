'use client';

export interface IRito {
// 202501251
    id: number;
 
	descricao: string,
	top: boolean,
	bold: boolean,
}

export interface IRitoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IRitoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}