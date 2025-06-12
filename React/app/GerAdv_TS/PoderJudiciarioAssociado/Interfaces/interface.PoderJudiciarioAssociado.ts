'use client';

export interface IPoderJudiciarioAssociado {
// 202501251
    id: number;
 
	justica: number,
	area: number,
	tribunal: number,
	foro: number,
	cidade: number,
	justicanome: string,
	areanome: string,
	tribunalnome: string,
	foronome: string,
	subdivisaonome: string,
	cidadenome: string,
	subdivisao: number,
	tipo: number,
}

export interface IPoderJudiciarioAssociadoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IPoderJudiciarioAssociadoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}