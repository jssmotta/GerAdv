'use client';

export interface IAgendaRelatorio {
// 202501251
    id: number;
 
	processo: number,
	data: string,
	paranome: string,
	parapessoas: string,
	boxaudiencia: string,
	boxaudienciamobile: string,
	nomeadvogado: string,
	nomeforo: string,
	nomejustica: string,
	nomearea: string,
}

export interface IAgendaRelatorioFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAgendaRelatorioIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}