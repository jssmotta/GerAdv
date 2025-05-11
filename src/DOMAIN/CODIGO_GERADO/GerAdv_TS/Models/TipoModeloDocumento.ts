import { Auditor } from "./Auditor";

import { ITipoModeloDocumento } from "../TipoModeloDocumento/Interfaces/interface.TipoModeloDocumento";
export interface TipoModeloDocumento
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function TipoModeloDocumentoEmpty(): ITipoModeloDocumento {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
