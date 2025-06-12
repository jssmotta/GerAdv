'use client';

export interface IReuniao {
// 202501251
    id: number;
 
	cliente: number,
	idagenda: number,
	data: string,
	pauta: string,
	ata: string,
	horainicial: string,
	horafinal: string,
	externa: boolean,
	horasaida: string,
	horaretorno: string,
	principaisdecisoes: string,
	bold: boolean,
}

export interface IReuniaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IReuniaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}