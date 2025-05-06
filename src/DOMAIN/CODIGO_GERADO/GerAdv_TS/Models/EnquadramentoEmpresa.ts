import { Auditor } from "./Auditor";

import { IEnquadramentoEmpresa } from "../EnquadramentoEmpresa/Interfaces/interface.EnquadramentoEmpresa";
export interface EnquadramentoEmpresa
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function EnquadramentoEmpresaEmpty(): IEnquadramentoEmpresa {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
