import { Auditor } from "./Auditor";

import { IProProcuradores } from "../ProProcuradores/Interfaces/interface.ProProcuradores";
export interface ProProcuradores
{
    id: number;
	advogado : number;
	processo : number;
	nome : string;
	data : string;
	substabelecimento : boolean;
	procuracao : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ProProcuradoresEmpty(): IProProcuradores {
// 20250125
    return {
        id: 0,
		advogado: 0,
		processo: 0,
		nome: '',
		data: '',
		substabelecimento: false,
		procuracao: false,
		bold: false,
		auditor: null
    };
}
