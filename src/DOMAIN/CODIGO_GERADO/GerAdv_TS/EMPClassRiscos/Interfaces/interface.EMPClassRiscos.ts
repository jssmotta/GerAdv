'use client';

export interface IEMPClassRiscos {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface IEMPClassRiscosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IEMPClassRiscosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}