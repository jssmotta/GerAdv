'use client';

export interface IAgendaRecords {
// 202501251
    id: number;
 
	agenda: number,
	clientessocios: number,
	colaborador: number,
	foro: number,
	julgador: number,
	perito: number,
	aviso1: boolean,
	aviso2: boolean,
	aviso3: boolean,
	crmaviso1: number,
	crmaviso2: number,
	crmaviso3: number,
	dataaviso1: string,
	dataaviso2: string,
	dataaviso3: string,
}

export interface IAgendaRecordsFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAgendaRecordsIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}