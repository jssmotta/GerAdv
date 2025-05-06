"use client";
export interface IOperadorEMailPopup {
// 202501251
    id: number;
 
		operador: number,
		nome: string,
		senha: string,
		smtp: string,
		pop3: string,
		autenticacao: boolean,
		descricao: string,
		usuario: string,
		portasmtp: number,
		portapop3: number,
		assinatura: string,
		senha256: string,
		auditor: undefined | null
}

export interface IOperadorEMailPopupFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IOperadorEMailPopupIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}