import { Auditor } from "./Auditor";

import { IAnexamentoRegistros } from "../AnexamentoRegistros/Interfaces/interface.AnexamentoRegistros";
export interface AnexamentoRegistros
{
    id: number;
	cliente : number;
	codigoreg : number;
	idreg : number;
	data : string;
	auditor?: Auditor | null;
}

export function AnexamentoRegistrosEmpty(): IAnexamentoRegistros {
// 20250125
    return {
        id: 0,
		cliente: 0,
		codigoreg: 0,
		idreg: 0,
		data: '',
		auditor: null
    };
}
