"use client";
export interface IProcessOutPutIDs {
// 202501251
    id: number;
 
		nome: string,
}

export interface IProcessOutPutIDsFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProcessOutPutIDsIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}