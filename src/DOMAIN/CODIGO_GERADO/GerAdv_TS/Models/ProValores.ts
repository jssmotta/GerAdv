import { Auditor } from "./Auditor";

import { IProValores } from "../ProValores/Interfaces/interface.ProValores";
export interface ProValores
{
    id: number;
	processo : number;
	tipovalorprocesso : number;
	indice : string;
	ignorar : boolean;
	data : string;
	valororiginal : number;
	percmulta : number;
	valormulta : number;
	percjuros : number;
	valororiginalcorrigidoindice : number;
	valormultacorrigido : number;
	valorjuroscorrigido : number;
	valorfinal : number;
	dataultimacorrecao : string;
	auditor?: Auditor | null;
}

export function ProValoresEmpty(): IProValores {
// 20250125
    return {
        id: 0,
		processo: 0,
		tipovalorprocesso: 0,
		indice: '',
		ignorar: false,
		data: '',
		valororiginal: 0,
		percmulta: 0,
		valormulta: 0,
		percjuros: 0,
		valororiginalcorrigidoindice: 0,
		valormultacorrigido: 0,
		valorjuroscorrigido: 0,
		valorfinal: 0,
		dataultimacorrecao: '',
		auditor: null
    };
}
