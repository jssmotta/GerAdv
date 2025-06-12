'use client';

export interface ISituacao {
// 202501251
    id: number;
 
	parte_int: string,
	parte_opo: string,
	top: boolean,
	bold: boolean,
}

export interface ISituacaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ISituacaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}