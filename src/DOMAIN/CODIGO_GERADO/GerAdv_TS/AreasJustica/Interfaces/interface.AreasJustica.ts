'use client';

export interface IAreasJustica {
// 202501251
    id: number;
 
	area: number,
	justica: number,
}

export interface IAreasJusticaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAreasJusticaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}