"use client";
export interface IProSucumbencia {
// 202501251
    id: number;
 
		processo: number,
		instancia: number,
		tipoorigemsucumbencia: number,
		data: string,
		nome: string,
		valor: number,
		percentual: string,
		auditor: undefined | null
}

export interface IProSucumbenciaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProSucumbenciaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}