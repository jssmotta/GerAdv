"use client";
export interface IApenso2 {
// 202501251
    id: number;
 
		processo: number,
		apensado: number,
		auditor: undefined | null
}

export interface IApenso2FormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IApenso2IncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}