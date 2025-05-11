import { Auditor } from "./Auditor";

import { IDocsRecebidosItens } from "../DocsRecebidosItens/Interfaces/interface.DocsRecebidosItens";
export interface DocsRecebidosItens
{
    id: number;
	contatocrm : number;
	nome : string;
	devolvido : boolean;
	seradevolvido : boolean;
	observacoes : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function DocsRecebidosItensEmpty(): IDocsRecebidosItens {
// 20250125
    return {
        id: 0,
		contatocrm: 0,
		nome: '',
		devolvido: false,
		seradevolvido: false,
		observacoes: '',
		bold: false,
		auditor: null
    };
}
