import { IParteOponente } from "../ParteOponente/Interfaces/interface.ParteOponente";
export interface ParteOponente
{
    id: number;
	oponente : number;
	processo : number;
}

export function ParteOponenteEmpty(): IParteOponente {
// 20250125
    return {
        id: 0,
		oponente: 0,
		processo: 0,
    };
}
