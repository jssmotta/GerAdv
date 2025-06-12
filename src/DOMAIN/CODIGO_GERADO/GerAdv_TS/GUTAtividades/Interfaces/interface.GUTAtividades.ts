'use client';

export interface IGUTAtividades {
// 202501251
    id: number;
 
	gutperiodicidade: number,
	operador: number,
	nome: string,
	observacao: string,
	gutgrupo: number,
	concluido: boolean,
	dataconcluido: string,
	diasparainiciar: number,
	minutospararealizar: number,
}

export interface IGUTAtividadesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGUTAtividadesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}