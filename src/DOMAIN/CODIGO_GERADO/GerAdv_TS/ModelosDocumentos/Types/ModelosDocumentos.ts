import { Auditor } from "../../Models/Auditor";

export interface IModelosDocumentos {
  id: number;
	tipomodelodocumento : number;
	nome : string;
	remuneracao : string;
	assinatura : string;
	header : string;
	footer : string;
	extra1 : string;
	extra2 : string;
	extra3 : string;
	outorgante : string;
	outorgados : string;
	poderes : string;
	objeto : string;
	titulo : string;
	testemunhas : string;
	css : string;
	auditor?: Auditor | null;
}
