'use client';

export interface IPrecatoria {
// 202501251
    id: number;
 
	processo: number,
	dtdist: string,
	precatoriax: string,
	deprecante: string,
	deprecado: string,
	obs: string,
	bold: boolean,
}

export interface IPrecatoriaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IPrecatoriaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}