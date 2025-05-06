import { Auditor } from "./Auditor";

import { IPoderJudiciarioAssociado } from "../PoderJudiciarioAssociado/Interfaces/interface.PoderJudiciarioAssociado";
export interface PoderJudiciarioAssociado
{
    id: number;
	justica : number;
	area : number;
	tribunal : number;
	foro : number;
	cidade : number;
	justicanome : string;
	areanome : string;
	tribunalnome : string;
	foronome : string;
	subdivisaonome : string;
	cidadenome : string;
	subdivisao : number;
	tipo : number;
	auditor?: Auditor | null;
}

export function PoderJudiciarioAssociadoEmpty(): IPoderJudiciarioAssociado {
// 20250125
    return {
        id: 0,
		justica: 0,
		area: 0,
		tribunal: 0,
		foro: 0,
		cidade: 0,
		justicanome: '',
		areanome: '',
		tribunalnome: '',
		foronome: '',
		subdivisaonome: '',
		cidadenome: '',
		subdivisao: 0,
		tipo: 0,
		auditor: null
    };
}
