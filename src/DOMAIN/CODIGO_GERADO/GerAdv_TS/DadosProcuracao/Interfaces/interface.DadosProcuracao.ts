"use client";
export interface IDadosProcuracao {
// 202501251
    id: number;
 
		cliente: number,
		estadocivil: string,
		nacionalidade: string,
		profissao: string,
		ctps: string,
		pispasep: string,
		remuneracao: string,
		objeto: string,
		auditor: undefined | null
}

export interface IDadosProcuracaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IDadosProcuracaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}