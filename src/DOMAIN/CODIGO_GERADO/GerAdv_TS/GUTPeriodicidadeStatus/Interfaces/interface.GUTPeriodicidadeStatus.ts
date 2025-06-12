'use client';

export interface IGUTPeriodicidadeStatus {
// 202501251
    id: number;
 
	gutatividade: number,
	datarealizado: string,
}

export interface IGUTPeriodicidadeStatusFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGUTPeriodicidadeStatusIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}