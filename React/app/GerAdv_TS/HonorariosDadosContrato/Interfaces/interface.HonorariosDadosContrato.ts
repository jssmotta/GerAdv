'use client';

export interface IHonorariosDadosContrato {
// 202501251
    id: number;
 
	cliente: number,
	processo: number,
	fixo: boolean,
	variavel: boolean,
	percsucesso: number,
	arquivocontrato: string,
	textocontrato: string,
	valorfixo: number,
	observacao: string,
	datacontrato: string,
}

export interface IHonorariosDadosContratoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IHonorariosDadosContratoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}