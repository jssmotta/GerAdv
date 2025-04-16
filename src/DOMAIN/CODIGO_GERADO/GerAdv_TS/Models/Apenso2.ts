import { Auditor } from "./Auditor";

import { IApenso2 } from "../Apenso2/Interfaces/interface.Apenso2";
export interface Apenso2
{
    id: number;
	processo : number;
	apensado : number;
	auditor?: Auditor | null;
}

export function Apenso2Empty(): IApenso2 {
// 20250125
    return {
        id: 0,
		processo: 0,
		apensado: 0,
		auditor: null
    };
}
