"use client";
export interface IProPartes {
// 202501251
    id: number;
 
		processo: number,
		parte: number,
}

export interface IProPartesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProPartesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}