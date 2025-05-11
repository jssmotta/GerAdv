import { Auditor } from "./Auditor";

import { IDocumentos } from "../Documentos/Interfaces/interface.Documentos";
export interface Documentos
{
    id: number;
	processo : number;
	data : string;
	observacao : string;
	auditor?: Auditor | null;
}

export function DocumentosEmpty(): IDocumentos {
// 20250125
    return {
        id: 0,
		processo: 0,
		data: '',
		observacao: '',
		auditor: null
    };
}
