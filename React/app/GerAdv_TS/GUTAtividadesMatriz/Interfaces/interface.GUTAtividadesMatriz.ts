'use client';

export interface IGUTAtividadesMatriz {
// 202501251
    id: number;
 
	gutmatriz: number,
	gutatividade: number,
}

export interface IGUTAtividadesMatrizFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGUTAtividadesMatrizIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}