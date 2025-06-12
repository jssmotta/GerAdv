'use client';

export interface ISMSAlice {
// 202501251
    id: number;
 
	operador: number,
	tipoemail: number,
	nome: string,
}

export interface ISMSAliceFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ISMSAliceIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}