import { Auditor } from "./Auditor";

import { IProSucumbencia } from "../ProSucumbencia/Interfaces/interface.ProSucumbencia";
export interface ProSucumbencia
{
    id: number;
	processo : number;
	instancia : number;
	tipoorigemsucumbencia : number;
	data : string;
	nome : string;
	valor : number;
	percentual : string;
	auditor?: Auditor | null;
}

export function ProSucumbenciaEmpty(): IProSucumbencia {
// 20250125
    return {
        id: 0,
		processo: 0,
		instancia: 0,
		tipoorigemsucumbencia: 0,
		data: '',
		nome: '',
		valor: 0,
		percentual: '',
		auditor: null
    };
}
