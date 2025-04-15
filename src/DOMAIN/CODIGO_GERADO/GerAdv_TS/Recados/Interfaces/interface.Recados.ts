"use client";
export interface IRecados {
// 202501251
    id: number;
 
		processo: number,
		cliente: number,
		historico: number,
		contatocrm: number,
		ligacoes: number,
		agenda: number,
		clientenome: string,
		de: string,
		para: string,
		assunto: string,
		concluido: boolean,
		recado: string,
		urgente: boolean,
		importante: boolean,
		hora: string,
		data: string,
		voltara: boolean,
		pessoal: boolean,
		retornar: boolean,
		retornodata: string,
		emotion: number,
		internetid: number,
		uploaded: boolean,
		natureza: number,
		biu: boolean,
		aguardarretorno: boolean,
		aguardarretornopara: string,
		aguardarretornook: boolean,
		paraid: number,
		naopublicavel: boolean,
		iscontatocrm: boolean,
		masterid: number,
		listapara: string,
		typed: boolean,
		assuntorecado: number,
		auditor: undefined | null
}

export interface IRecadosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IRecadosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}