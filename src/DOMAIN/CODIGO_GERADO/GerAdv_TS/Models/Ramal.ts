import { Auditor } from "./Auditor";

import { IRamal } from "../Ramal/Interfaces/interface.Ramal";
export interface Ramal
{
    id: number;
	nome : string;
	obs : string;
	auditor?: Auditor | null;
}

export function RamalEmpty(): IRamal {
// 20250125
    return {
        id: 0,
		nome: '',
		obs: '',
		auditor: null
    };
}
