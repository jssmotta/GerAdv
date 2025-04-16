"use client";
export interface IBensMateriais {
// 202501251
    id: number;
 
		bensclassificacao: number,
		fornecedor: number,
		cidade: number,
		nome: string,
		datacompra: string,
		datafimdagarantia: string,
		nfnro: string,
		valorbem: number,
		nroserieproduto: string,
		comprador: string,
		garantialoja: boolean,
		dataterminodagarantiadaloja: string,
		observacoes: string,
		nomevendedor: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IBensMateriaisFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IBensMateriaisIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}