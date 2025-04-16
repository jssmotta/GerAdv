"use client";
export interface ISMSAlice {
// 202501251
    id: number;
 
		operador: number,
		tipoemail: number,
		nome: string,
		auditor: undefined | null
}

export interface ISMSAliceFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ISMSAliceIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}