"use client";
export interface ITribEnderecos {
// 202501251
    id: number;
 
		tribunal: number,
		cidade: number,
		endereco: string,
		cep: string,
		fone: string,
		fax: string,
		obs: string,
}

export interface ITribEnderecosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITribEnderecosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}