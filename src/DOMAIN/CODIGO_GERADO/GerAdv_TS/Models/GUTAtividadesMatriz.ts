import { Auditor } from "./Auditor";

import { IGUTAtividadesMatriz } from "../GUTAtividadesMatriz/Interfaces/interface.GUTAtividadesMatriz";
export interface GUTAtividadesMatriz
{
    id: number;
	gutmatriz : number;
	gutatividade : number;
	auditor?: Auditor | null;
}

export function GUTAtividadesMatrizEmpty(): IGUTAtividadesMatriz {
// 20250125
    return {
        id: 0,
		gutmatriz: 0,
		gutatividade: 0,
		auditor: null
    };
}
