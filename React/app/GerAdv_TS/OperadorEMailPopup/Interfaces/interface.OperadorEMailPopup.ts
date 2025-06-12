'use client';

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
}

export interface IOperadorEMailPopupFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IOperadorEMailPopupIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}