import { Auditor } from "../../Models/Auditor";

export interface IOperadorEMailPopup {
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
