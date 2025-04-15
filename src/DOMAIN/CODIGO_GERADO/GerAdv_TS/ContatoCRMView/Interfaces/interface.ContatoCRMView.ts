"use client";
export interface IContatoCRMView {
// 202501251
    id: number;
 
		data: string,
		ip: string,
}

export interface IContatoCRMViewFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IContatoCRMViewIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}