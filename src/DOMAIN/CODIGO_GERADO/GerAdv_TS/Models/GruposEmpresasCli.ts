import { Auditor } from "./Auditor";

import { IGruposEmpresasCli } from "../GruposEmpresasCli/Interfaces/interface.GruposEmpresasCli";
export interface GruposEmpresasCli
{
    id: number;
	grupo : number;
	cliente : number;
	oculto : boolean;
	auditor?: Auditor | null;
}

export function GruposEmpresasCliEmpty(): IGruposEmpresasCli {
// 20250125
    return {
        id: 0,
		grupo: 0,
		cliente: 0,
		oculto: false,
		auditor: null
    };
}
