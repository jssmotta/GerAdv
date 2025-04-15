import { Auditor } from "./Auditor";

import { IContatoCRMOperador } from "../ContatoCRMOperador/Interfaces/interface.ContatoCRMOperador";
export interface ContatoCRMOperador
{
    id: number;
	contatocrm : number;
	operador : number;
	cargoesc : number;
	auditor?: Auditor | null;
}

export function ContatoCRMOperadorEmpty(): IContatoCRMOperador {
// 20250125
    return {
        id: 0,
		contatocrm: 0,
		operador: 0,
		cargoesc: 0,
		auditor: null
    };
}
