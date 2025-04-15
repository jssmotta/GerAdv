"use client";
export interface IDivisaoTribunal {
// 202501251
    id: number;
 
		justica: number,
		area: number,
		cidade: number,
		foro: number,
		tribunal: number,
		numcodigo: number,
		nomeespecial: string,
		codigodiv: string,
		endereco: string,
		fone: string,
		fax: string,
		cep: string,
		obs: string,
		email: string,
		andar: string,
		etiqueta: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IDivisaoTribunalFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IDivisaoTribunalIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}