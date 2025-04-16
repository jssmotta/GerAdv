import { Auditor } from "./Auditor";

import { IOperadorEMailPopup } from "../OperadorEMailPopup/Interfaces/interface.OperadorEMailPopup";
export interface OperadorEMailPopup
{
    id: number;
	operador : number;
	nome : string;
	senha : string;
	smtp : string;
	pop3 : string;
	autenticacao : boolean;
	descricao : string;
	usuario : string;
	portasmtp : number;
	portapop3 : number;
	assinatura : string;
	senha256 : string;
	auditor?: Auditor | null;
}

export function OperadorEMailPopupEmpty(): IOperadorEMailPopup {
// 20250125
    return {
        id: 0,
		operador: 0,
		nome: '',
		senha: '',
		smtp: '',
		pop3: '',
		autenticacao: false,
		descricao: '',
		usuario: '',
		portasmtp: 0,
		portapop3: 0,
		assinatura: '',
		senha256: '',
		auditor: null
    };
}
