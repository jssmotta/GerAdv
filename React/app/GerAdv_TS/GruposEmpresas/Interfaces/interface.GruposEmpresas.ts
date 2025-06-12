'use client';

export interface IGruposEmpresas {
// 202501251
    id: number;
 
	oponente: number,
	cliente: number,
	email: string,
	inativo: boolean,
	descricao: string,
	observacoes: string,
	icone: string,
	despesaunificada: boolean,
}

export interface IGruposEmpresasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGruposEmpresasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}