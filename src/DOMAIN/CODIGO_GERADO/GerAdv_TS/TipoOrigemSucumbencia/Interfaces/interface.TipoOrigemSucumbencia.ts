'use client';

export interface ITipoOrigemSucumbencia {
// 202501251
    id: number;
 
	nome: string,
}

export interface ITipoOrigemSucumbenciaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoOrigemSucumbenciaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}