import { Auditor } from "./Auditor";

import { IApenso } from "../Apenso/Interfaces/interface.Apenso";
export interface Apenso
{
    id: number;
	processo : number;
	apensox : string;
	acao : string;
	dtdist : string;
	obs : string;
	valorcausa : number;
	auditor?: Auditor | null;
}

export function ApensoEmpty(): IApenso {
// 20250125
    return {
        id: 0,
		processo: 0,
		apensox: '',
		acao: '',
		dtdist: '',
		obs: '',
		valorcausa: 0,
		auditor: null
    };
}
