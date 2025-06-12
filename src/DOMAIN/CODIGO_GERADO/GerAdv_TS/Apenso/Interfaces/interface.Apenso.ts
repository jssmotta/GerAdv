'use client';

export interface IApenso {
// 202501251
    id: number;
 
	processo: number,
	apensox: string,
	acao: string,
	dtdist: string,
	obs: string,
	valorcausa: number,
}

export interface IApensoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IApensoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}