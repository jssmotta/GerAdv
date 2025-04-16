"use client";
export interface IEnderecoSistema {
// 202501251
    id: number;
 
		tipoenderecosistema: number,
		processo: number,
		cidade: number,
		cadastro: number,
		cadastroexcod: number,
		motivo: string,
		contatonolocal: string,
		endereco: string,
		bairro: string,
		cep: string,
		fone: string,
		fax: string,
		observacao: string,
		auditor: undefined | null
}

export interface IEnderecoSistemaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IEnderecoSistemaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}