"use client";
export interface IAgenda2Agenda {
// 202501251
    id: number;
 
		agenda: number,
		master: number,
		auditor: undefined | null
}

export interface IAgenda2AgendaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAgenda2AgendaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}