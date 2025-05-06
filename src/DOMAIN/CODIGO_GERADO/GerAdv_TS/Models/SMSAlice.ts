import { Auditor } from "./Auditor";

import { ISMSAlice } from "../SMSAlice/Interfaces/interface.SMSAlice";
export interface SMSAlice
{
    id: number;
	operador : number;
	tipoemail : number;
	nome : string;
	auditor?: Auditor | null;
}

export function SMSAliceEmpty(): ISMSAlice {
// 20250125
    return {
        id: 0,
		operador: 0,
		tipoemail: 0,
		nome: '',
		auditor: null
    };
}
