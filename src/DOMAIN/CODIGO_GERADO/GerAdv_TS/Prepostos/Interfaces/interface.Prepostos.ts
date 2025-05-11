"use client";
export interface IPrepostos {
// 202501251
    id: number;
 
		funcao: number,
		setor: number,
		cidade: number,
		nome: string,
		dtnasc: string,
		qualificacao: string,
		sexo: boolean,
		idade: number,
		cpf: string,
		rg: string,
		periodo_ini: string,
		periodo_fim: string,
		registro: string,
		ctpsnumero: string,
		ctpsserie: string,
		ctpsdtemissao: string,
		pis: string,
		salario: number,
		liberaagenda: boolean,
		observacao: string,
		endereco: string,
		bairro: string,
		cep: string,
		fone: string,
		fax: string,
		email: string,
		pai: string,
		mae: string,
		class: string,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IPrepostosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IPrepostosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}