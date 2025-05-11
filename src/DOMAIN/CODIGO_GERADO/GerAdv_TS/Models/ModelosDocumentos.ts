import { Auditor } from "./Auditor";

import { IModelosDocumentos } from "../ModelosDocumentos/Interfaces/interface.ModelosDocumentos";
export interface ModelosDocumentos
{
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

export function ModelosDocumentosEmpty(): IModelosDocumentos {
// 20250125
    return {
        id: 0,
		tipomodelodocumento: 0,
		nome: '',
		remuneracao: '',
		assinatura: '',
		header: '',
		footer: '',
		extra1: '',
		extra2: '',
		extra3: '',
		outorgante: '',
		outorgados: '',
		poderes: '',
		objeto: '',
		titulo: '',
		testemunhas: '',
		css: '',
		auditor: null
    };
}
