'use client';

export interface IApenso2 {
// 202501251
    id: number;
 
	processo: number,
	apensado: number,
}

export interface IApenso2FormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IApenso2IncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}