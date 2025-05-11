"use client";
export interface IOperadores {
// 202501251
    id: number;
 
		cliente: number,
		enviado: boolean,
		casa: boolean,
		casaid: number,
		casacodigo: number,
		isnovo: boolean,
		grupo: number,
		nome: string,
		email: string,
		senha: string,
		ativado: boolean,
		atualizarsenha: boolean,
		senha256: string,
		suportesenha256: string,
		suportemaxage: string,
		auditor: undefined | null
}

export interface IOperadoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IOperadoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}