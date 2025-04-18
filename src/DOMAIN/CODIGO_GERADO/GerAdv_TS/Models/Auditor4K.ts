﻿import { Auditor } from "./Auditor";

import { IAuditor4K } from "../Auditor4K/Interfaces/interface.Auditor4K";
export interface Auditor4K
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function Auditor4KEmpty(): IAuditor4K {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
