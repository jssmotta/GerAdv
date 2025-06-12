'use client';

export interface IProProcuradores {
// 202501251
    id: number;
 
	advogado: number,
	processo: number,
	nome: string,
	data: string,
	substabelecimento: boolean,
	procuracao: boolean,
	bold: boolean,
}

export interface IProProcuradoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProProcuradoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}