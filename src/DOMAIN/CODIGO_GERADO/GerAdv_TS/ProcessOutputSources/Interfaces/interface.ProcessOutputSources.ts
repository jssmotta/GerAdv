"use client";
export interface IProcessOutputSources {
// 202501251
    id: number;
 
		nome: string,
}

export interface IProcessOutputSourcesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProcessOutputSourcesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}